using SplashKitSDK;

namespace _7_3D
{
    public class Block
    {
        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        private Bitmap _blcokBitmap;

        public Bitmap BlockBitmap
        {
            get { return _blcokBitmap; }
        }


        public Block(double x, double y)
        {
            X = x;
            Y = y;
            _blcokBitmap = SplashKit.BitmapNamed("block");
        }

        public void Draw()
        {
            _blcokBitmap.Draw(X, Y);
        }
    }

}