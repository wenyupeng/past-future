using SplashKitSDK;


namespace RobotDodge
{
    public class Player
    {
        private Bitmap _PlayerBitmap;
        private Window _gameWindow;

        public double X
        {
            get;
            private set;
        }

        public double Y
        {
            get;
            private set;
        }

        public int Width
        {
            get
            {
                return _PlayerBitmap.Width;
            }
        }

        public int Height
        {
            get
            {
                return _PlayerBitmap.Height;
            }
        }

        public Player(Window gameWindow)
        {
            _PlayerBitmap = new Bitmap("User", "Player.png");
            X = (gameWindow.Width - Width) / 2;
            Y = (gameWindow.Height - Height) / 2;
            // Console.WriteLine($"BitMap Width {Width}, Height {Height}; X {X}, Y {Y}");
            _gameWindow = gameWindow;
        }

        public void Play()
        {
            while (!_gameWindow.CloseRequested)
            {
                Draw();
                HandleInput();
            }

            _gameWindow.Close();

            _gameWindow = null;
            SplashKit.Delay(1000);
        }

        private void HandleInput()
        {
            SplashKit.ProcessEvents();

            int vector = 5;
            if (SplashKit.KeyDown(KeyCode.UpKey) || SplashKit.KeyDown(KeyCode.WKey))
            {
                Move(-vector, 0);
            }
            else if (SplashKit.KeyDown(KeyCode.DownKey) || SplashKit.KeyDown(KeyCode.SKey))
            {
                Move(vector, 0);
            }
            else if (SplashKit.KeyDown(KeyCode.LeftKey) || SplashKit.KeyDown(KeyCode.AKey))
            {
                Move(0, -vector);
            }
            else if (SplashKit.KeyDown(KeyCode.RightKey) || SplashKit.KeyDown(KeyCode.DKey))
            {
                Move(0, vector);
            }else{

            }
        }

        public void Draw()
        {
            _gameWindow.Clear(Color.SkyBlue);
            _gameWindow.DrawBitmap(_PlayerBitmap, X, Y);
            _gameWindow.Refresh(60);
        }

        public void Move(double forward, double strafe)
        {
            Vector2D movement = new Vector2D();
            Matrix2D rotation = SplashKit.RotationMatrix(0);

            movement.Y += forward;
            movement.X += strafe;

            movement = SplashKit.MatrixMultiply(rotation, movement);
            X += movement.X;
            Y += movement.Y;
        }
    }
}