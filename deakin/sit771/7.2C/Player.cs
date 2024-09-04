using SplashKitSDK;


namespace _7_2C
{
    public class Player
    {
        private Bitmap _PlayerBitmap;
        private Window _GameWindow;
        const int GAP = 10;
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

        public bool Quit
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
            Y = (gameWindow.Height - Height) * 2;
            _GameWindow = gameWindow;
            SplashKit.LoadBitmap("Bullet", "Fire.png");
        }

        public void Draw()
        {
            _GameWindow.DrawBitmap(_PlayerBitmap, X, Y);
        }

        public void HandleInput()
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
            }
            else
            {

            }
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

        public void StayOnWindow(Window limit)
        {
            if (X < GAP)
            {
                X = GAP;
            }
            else if (Y < GAP)
            {
                Y = GAP;
            }
            else if (X + _PlayerBitmap.Width > limit.Width - GAP)
            {
                X = limit.Width - GAP - _PlayerBitmap.Width;
            }
            else if (Y + _PlayerBitmap.Height > limit.Height - GAP)
            {
                Y = limit.Height - GAP - _PlayerBitmap.Height;
            }
            else
            {

            }
        }

        public bool CollidedWith(Robot other)
        {
            return _PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle);
        }

    }
}




