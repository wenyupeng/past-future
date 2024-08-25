using SplashKitSDK;

namespace _7_3D
{
    public class Bullet
    {
        private Bitmap _bulletBitmap;
        private double _X, _Y, _Angle;
        private bool _active = false;
        public Bullet(double x, double y, double angle)
        {
            _bulletBitmap = SplashKit.BitmapNamed("bullet");
            _Angle = angle;
            if (angle == 90)
            {
                _X = x + _bulletBitmap.Width / 2;
                _Y = y + _bulletBitmap.Height / 2;
                SplashKit.PointAt(X, Y);
            }
            else if (angle == 180)
            {
                _X = x - 10;
                _Y = y + _bulletBitmap.Height;
            }
            else if (angle == 270)
            {
                _X = x - _bulletBitmap.Width;
                _Y = y + _bulletBitmap.Height / 2 + 5;
            }
            else
            {
                _X = x - 10;
                _Y = y - _bulletBitmap.Height / 2;
            }
            _active = true;
        }

        public Bitmap BulletBitmap
        {
            get { return _bulletBitmap; }
        }

        public double X
        {
            get { return _X; }
        }
        public double Y
        {
            get { return _Y; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }


        public void Update(List<Block> blocks)
        {
            const int TOAST = 5;
            Vector2D movement = new Vector2D();
            Matrix2D rotation = SplashKit.RotationMatrix(_Angle);
            movement.Y -= TOAST;
            movement = SplashKit.MatrixMultiply(rotation, movement);
            _X += movement.X;
            _Y += movement.Y;

            if ((_X > SplashKit.ScreenWidth() || _X < 0) || _Y > SplashKit.ScreenHeight() || _Y < 0)
            {
                _active = false;
            }

            blocks.ForEach(block =>
            {
                bool flag = _bulletBitmap.BitmapCollision(X, Y, block.BlockBitmap, block.X, block.Y);
                if (flag)
                {
                    _active = false;
                }
            });

            if (Y < 50)
            {
                _active = false;
            }
        }

        public void Draw()
        {
            if (_active)
            {
                DrawingOptions options = SplashKit.OptionRotateBmp(_Angle + 270);
                _bulletBitmap.Draw(_X, _Y, options);
            }

        }
    }

}