using System;
using SplashKitSDK;

namespace week4_light
{
    public class Program
    {
        public static void Main2()
        {
            LightSimulator simulator = new();
            simulator.Run();
        }
    }

    public class LightSimulator
    {
        private Window? _simWindow;
        private readonly LightBulb _light;
        private LightSwitch _lightSwitch;
        public LightSimulator()
        {
            _light = new LightBulb(10, 10);
            _lightSwitch = new LightSwitch { ConnectedLight = _light, X = 215, Y = 400 };
        }

        public void Run()
        {
            _simWindow = new Window("Lightroom", 600, 600);
            LoadResources();

            while (!_simWindow.CloseRequested)
            {
                Draw();
                HandleInput();
            }

            _simWindow.Close();
        }

        private void Draw()
        {
            _simWindow.Clear(Color.White);
            _light.Draw();
            _lightSwitch.Draw();
            _simWindow.Refresh(60);
        }

        private void HandleInput()
        {
            SplashKit.ProcessEvents();
            if (_lightSwitch.IsUnderMouse && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                _lightSwitch.Switch();
            }
        }

        private void LoadResources()
        {
            SplashKit.LoadBitmap("On", "./resources/medium-on-light.png");
            SplashKit.LoadBitmap("Off", "./resources/medium-off-light.png");
            SplashKit.LoadBitmap("OnSwitch", "./resources/switch-on.jpg");
            SplashKit.LoadBitmap("OffSwitch", "./resources/switch-off.jpg");
        }
    }

    public class LightBulb
    {
        private double _x, _y;
        private bool _power = false;

        public LightBulb(double x, double y)
        {
            _x = x;
            _y = y;
            _power = false;
        }

        public void TogglePower()
        {
            _power = !_power;
        }

        public Bitmap Image
        {
            get { return SplashKit.BitmapNamed(_power ? "On" : "Off"); }
        }

        public double X
        {
            set { _x = value; }
            get { return _x; }
        }

        public double Y
        {
            set { _y = value; }
            get { return _y; }
        }

        public void Draw()
        {
            Image.Draw(_x, _y);
        }
    }

    public class LightSwitch
    {
        private LightBulb _connectedLight;
        private double _x, _y;
        private bool _isOn;

        public LightSwitch()
        {
            _isOn = false;
        }
        public Bitmap Image
        {
            get
            {
                if (_isOn)
                {
                    return SplashKit.BitmapNamed("OnSwitch");
                }
                else
                {
                    return SplashKit.BitmapNamed("OffSwitch");
                }
            }
        }

        public double X
        {
            set { _x = value; }
            get { return _x; }
        }

        public double Y
        {
            set { _y = value; }
            get { return _y; }
        }

        public LightBulb ConnectedLight
        {
            set { _connectedLight = value; }
            get { return _connectedLight; }
        }

        public void Switch()
        {
           _connectedLight.TogglePower();
           _isOn = !_isOn;
        }

        public bool IsUnderMouse
        {
            get { 
                return Image.PointCollision(_x, _y, SplashKit.MouseX(), SplashKit.MouseY()); }
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(Image, _x, _y);
        }
    }
}
