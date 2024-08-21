using SplashKitSDK;


namespace _6_2D
{
    public class Player
    {
        private Bitmap _PlayerBitmap;
        private Window _GameWindow;
        private Bullet _Bullet;
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
            if (_Bullet != null)
            {
                _Bullet.Draw();
            }
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
            else if (SplashKit.MouseClicked(MouseButton.LeftButton) || SplashKit.MouseClicked(MouseButton.RightButton))
            {
                Point2D point2D = SplashKit.MousePosition();
                Shoot(SplashKit.PointPointAngle(SplashKit.PointAt(X, Y), point2D));
            }
            else
            {

            }

            if (_Bullet != null)
            {
                _Bullet.Update();
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

            Draw();
        }

        public bool CollidedWith(Robot other)
        {
            return _PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle);
        }

        public bool BulletCollidedWith(Robot robot)
        {
            if (_Bullet != null)
            {
                return _Bullet.BulletBitmap.CircleCollision(_Bullet.X, _Bullet.Y, robot.CollisionCircle);
            }
            return false;
        }

        public void DrawLives(int collisionCount)
        {
            if (collisionCount == 5)
            {
                Quit = true;
                return;
            }

            for (int i = 0; i < 5 - collisionCount; i++)
            {
                SplashKit.FillCircle(Color.Red, _GameWindow.Width - i * Robot._FixedWidth - Robot._FixedWidth / 2, Robot._FixedWidth / 2, Robot._FixedWidth / 3);
            }
        }

        public void Shoot(double angle)
        {
            Matrix2D anchorMatrix = SplashKit.TranslationMatrix(SplashKit.PointAt(_PlayerBitmap.Width / 2, _PlayerBitmap.Height / 2));

            // Move centre point of picture to origin
            Matrix2D result = SplashKit.MatrixMultiply(SplashKit.IdentityMatrix(), SplashKit.MatrixInverse(anchorMatrix));
            // Rotate around origin
            result = SplashKit.MatrixMultiply(result, SplashKit.RotationMatrix(angle));
            // Move it back...
            result = SplashKit.MatrixMultiply(result, anchorMatrix);

            // Now move to location on screen...
            result = SplashKit.MatrixMultiply(result, SplashKit.TranslationMatrix(X, Y));

            // Get right/centre
            Vector2D vector = new Vector2D();
            vector.X = _PlayerBitmap.Width;
            vector.Y = _PlayerBitmap.Height / 2;
            // Transform it...
            vector = SplashKit.MatrixMultiply(result, vector);
            _Bullet = new Bullet(vector.X, vector.Y, angle);
        }

         public void BulletDisappear(){
            _Bullet.Active = false;
        }
    }
}




