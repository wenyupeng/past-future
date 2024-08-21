using SplashKitSDK;

namespace _6_2D
{
    public class Bullet
    {
        private Bitmap _BulletBitmap;
        private double _X, _Y, _Angle;
        private bool _active = false;
        public Bullet(double x, double y, double angle)
        {
            _BulletBitmap = SplashKit.BitmapNamed("Bullet");
            _X = x - _BulletBitmap.Width / 2;
            _Y = y - _BulletBitmap.Height / 2;
            _Angle = angle;
            _active = true;
        }

        public Bitmap BulletBitmap
        {
            get { return _BulletBitmap; }
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
            set { _active = value; }
        }


        public void Update()
        {
            const int TOAST = 8;
            Vector2D movement = new Vector2D();
            Matrix2D rotation = SplashKit.RotationMatrix(_Angle + 45 * 2);
            movement.Y -= TOAST;
            movement = SplashKit.MatrixMultiply(rotation, movement);
            _X += movement.X;
            _Y += movement.Y;

            if ((_X > SplashKit.ScreenWidth() || _X < 0) || _Y > SplashKit.ScreenHeight() || _Y < 0)
            {
                _active = false;
            }
        }

        public void Draw()
        {
            if (_active)
            {
                DrawingOptions options = SplashKit.OptionRotateBmp(_Angle);
                _BulletBitmap.Draw(_X, _Y, options);
            }

        }

    }
}