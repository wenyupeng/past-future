using SplashKitSDK;

namespace _7_3D
{
    public abstract class Tank
    {
        private Window _gameWindow;

        private Bitmap _bitmap;

        public const int GAP = 10;

        protected Tank(Window gameWindow, Bitmap bitmap)
        {
            _gameWindow = gameWindow;
            _bitmap = bitmap;
        }

        public Window GameWindow
        {
            get { return _gameWindow; }
        }

        public Bitmap TankBitmap
        {
            get { return _bitmap; }
        }

        public double Angle
        {
            get;
            protected set;
        }

        public double X
        {
            get;
            protected set;
        }

        public double Y
        {
            get;
            protected set;
        }
        public void Move(double forward, double strafe, List<Block> blocks)
        {

            Vector2D movement = new Vector2D();
            Matrix2D rotation = SplashKit.RotationMatrix(0);

            movement.Y += forward;
            movement.X += strafe;

            movement = SplashKit.MatrixMultiply(rotation, movement);
            X += movement.X;
            Y += movement.Y;
            if (CheckCollisionsWithBlocks(blocks))
            {
                X -= movement.X;
                Y -= movement.Y;
            }
        }

        public void StayOnWindow()
        {
            if (X < GAP)
            {
                X = GAP;
            }
            else if (Y < GAP + 50)
            {
                Y = GAP + 50;
            }
            else if (X + _bitmap.Width > GameWindow.Width - GAP)
            {
                X = GameWindow.Width - GAP - _bitmap.Width;
            }
            else if (Y + _bitmap.Height > GameWindow.Height - GAP)
            {
                Y = GameWindow.Height - GAP - _bitmap.Height;
            }
            else
            {

            }
        }

        public bool CheckCollisionsWithBlocks(List<Block> blocks)
        {
            bool flag = false;
            if (blocks != null && blocks.Count > 0)
            {
                blocks.ForEach(b =>
                {
                    bool collideFlag = _bitmap.BitmapCollision(X, Y, b.BlockBitmap, b.X, b.Y);
                    if (collideFlag)
                    {
                        flag = true;
                    }
                });
            }
            return flag;
        }

        public virtual void Draw(List<Block> blocks)
        {

        }

    }

}