using SplashKitSDK;

namespace week4_light2
{
    public class LightSwitchFinal
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
        private LightBulb _light0;
        private LightBulb _light1;
        private LightBulb _light2;
        private LightSwitch _lightSwitch;
        private LightSwitch _lightSwitch2;

        public LightSimulator()
        {
            _light0 = new LightBulb(10, 10);
            _light1 = new LightBulb(200, 10);
            _light2 = new LightBulb(400, 10);

             _lightSwitch = new LightSwitch { ConnectedLight = _light0, X = 215, Y = 400 };
             _lightSwitch2 = new LightSwitch { X = 400, Y = 400 };
        }

        public void Draw()
        {
            _simWindow.Clear(Color.White);
            _light0.Draw();
            _light1.Draw();
            _light2.Draw();
            _lightSwitch.Draw();
            _lightSwitch2.Draw();
            _simWindow.Refresh(60);
        }

        private void CheckLight(LightBulb toCheck)
        {
            if (toCheck.IsUnderMouse && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                if (SplashKit.KeyDown(KeyCode.LeftShiftKey))
                {
                  _lightSwitch2.ConnectedLight = toCheck;
                }
                else
                {
                  _lightSwitch.ConnectedLight = toCheck;
                }
            }
        }

        private void CheckSwitch(LightSwitch toCheck)
        {
            if (toCheck.IsUnderMouse && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                toCheck.Switch();
            }
        }

        public void HandleInput()
        {
            SplashKit.ProcessEvents();

            CheckSwitch(_lightSwitch);
            CheckSwitch(_lightSwitch2);

            CheckLight(_light0);
            CheckLight(_light1);
            CheckLight(_light2);
        }

        public void Run()
        {
            _simWindow = new Window("My Lightroom", 600, 600);
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
            SplashKit.LoadBitmap("On", "./resources/medium-on-light.png");
            SplashKit.LoadBitmap("Off", "./resources/medium-off-light.png");
            SplashKit.LoadBitmap("OnSwitch", "./resources/switch-on.jpg");
            SplashKit.LoadBitmap("OffSwitch", "./resources/switch-off.jpg");
        }
    }

    public class LightBulb
    {
        private bool _isOn;

        public LightBulb(double x, double y)
        {
            X = x;
            Y = y;
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
          get {  return SplashKit.BitmapNamed(_isOn ? "On" : "Off"); }
        }

        public double X { get; set; }
        public double Y { get; set; }

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
            get { return Image.PointCollision(X, Y, SplashKit.MouseX(), SplashKit.MouseY()); }
        }

        public void Draw()
        {
            Image.Draw(X, Y);
        }
    }

    public class LightSwitch
    {
        private LightBulb _connectedLight;
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
            get { return SplashKit.BitmapNamed(_isOn ? "OnSwitch" : "OffSwitch"); }
        }

        public double X { get; set; }
        public double Y { get; set; }

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
          if (_connectedLight != null)
          {
            _connectedLight.TogglePower();
          }
           _isOn = !_isOn;
        }

        public bool IsUnderMouse
        {
            get { return Image.PointCollision(X, Y, SplashKit.MouseX(), SplashKit.MouseY()); }
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(Image, X, Y);
            if ( _connectedLight != null)
            {
              SplashKit.DrawLine(Color.LimeGreen, X + Width/2, Y, _connectedLight.X + _connectedLight.Width/2, _connectedLight.Y + _connectedLight.Height);
            }
        }
    }
}
