using SplashKitSDK;
using System.Collections.Generic;

namespace LightStrip
{
    public class Program
    {
        public static void Main()
        {
            LightSimulator simulation = new LightSimulator();
            simulation.Run();
        }
    }

    public class LightSimulator
    {
        private Window _simWindow;
        private LightStrip _strip;

        public LightSimulator()
        {
            LoadResources();
            _strip = new LightStrip(5);
        }

        public void Draw()
        {
            _simWindow.Clear(Color.White);
            _strip.Draw();
            _simWindow.Refresh(60);
        }
        public void HandleInput()
        {
            SplashKit.ProcessEvents();
            _strip.HandleInput();
        }

        public void Run()
        {
            _simWindow = new Window("My Lightroom", 800, 400);
            LoadResources();

            while (!_simWindow.CloseRequested)
            {
                Draw();
                HandleInput();
            }

            _simWindow.Close();
        }

        private void LoadResources()
        {
            SplashKit.LoadBitmap("On", "medium-on-light.png");
            SplashKit.LoadBitmap("Off", "medium-off-light.png");
            SplashKit.LoadBitmap("OnSwitch", "switch-on.jpg");
            SplashKit.LoadBitmap("OffSwitch", "switch-off.jpg");
        }
    }

    public class LightStrip
    {
        private List<LightBulb> _bulbs;

        public LightStrip(int num)
        {
            const int LIGHT_Y = 50;

            _bulbs = new List<LightBulb>();
            int bulbWidth = SplashKit.BitmapNamed("On").Width;
            int bulbGap = bulbWidth + 5;

            for (int i = 0; i < num; i++)
            {
                LightBulb tmp = new LightBulb( bulbGap * i, LIGHT_Y );
                _bulbs.Add(tmp);
            }
        }

        public void Draw()
        {
            for(int i = 0; i < _bulbs.Count; i++)
            {
                _bulbs[i].Draw();
            }
        }

        public void HandleInput()
        {
            if ( SplashKit.MouseClicked(MouseButton.LeftButton) )
            {
                for(int i = 0; i < _bulbs.Count; i++)
                {
                    if (_bulbs[i].IsUnderMouse)
                        _bulbs[i].TogglePower();
                }
            }

            if ( SplashKit.KeyTyped(KeyCode.SpaceKey) ) TurnAllOn();
            if ( SplashKit.KeyTyped(KeyCode.EscapeKey) ) TurnAllOff();
            if ( SplashKit.KeyTyped(KeyCode.TKey) ) ToggleAll();
        }

        private void ToggleAll()
        {
            for (int i = 0; i < _bulbs.Count; i++)
            {
                _bulbs[i].TogglePower();
            }
        }

        private void TurnAllOff()
        {
            for (int i = 0; i < _bulbs.Count; i++)
            {
                if ( _bulbs[i].IsOn )
                    _bulbs[i].TogglePower();
            }
        }

        private void TurnAllOn()
        {

            for (int i = 0; i < _bulbs.Count; i++)
            {
                if ( !  _bulbs[i].IsOn )
                    _bulbs[i].TogglePower();
            }
        }
    }

    public class LightBulb
    {
        private double _x, _y;
        private bool _isOn;

        public LightBulb(double x, double y)
        {
            _x = x;
            _y = y;
            _isOn = false;
        }

        public bool IsOn
        {
            get { return _isOn; }
        }

        public void TogglePower()
        {
            _isOn = !_isOn;
        }

        public Bitmap Image
        {
            get
            {
                return SplashKit.BitmapNamed(_isOn ? "On" : "Off");
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

        public double Width
        {
            get { return Image.Width; }
        }

        public double Height
        {
            get { return Image.Height; }
        }

        public bool IsUnderMouse
        {
            get { return Image.PointCollision(_x, _y, SplashKit.MouseX(), SplashKit.MouseY()); }
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

        public double Width
        {
            get { return Image.Width; }
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

        public double Height
        {
            get { return Image.Height; }
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
            get { return Image.PointCollision(_x, _y, SplashKit.MouseX(), SplashKit.MouseY()); }
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(Image, _x, _y);
            SplashKit.DrawLine(Color.LimeGreen, _x + Width/2, _y, _connectedLight.X + _connectedLight.Width/2, _connectedLight.Y + _connectedLight.Height);
        }
    }
}
