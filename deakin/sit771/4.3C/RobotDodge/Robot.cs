using SplashKitSDK;

namespace RobotDodge
{
    public class Robot
    {
        private double _X;
        public double X
        {
            get { return _X; }
            set { _X = value; }
        }

        private double _Y;
        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        private SplashKitSDK.Color _MainColor;

        private int _Width;
        private int _Height;

        public int Width
        {
            get { return 50; }
        }
        public int Height
        {
            get { return 50; }
        }
        private Circle _CollisionCircle;

        public Robot(Window gameWindow)
        {
            X = SplashKit.Rnd(gameWindow.Width - Width);
            Y = SplashKit.Rnd(gameWindow.Width - Width);
            _MainColor = Color.RandomRGB(200);
            _CollisionCircle = SplashKit.CircleAt(X + 25, Y + 25, 20);
        }

        public void Draw()
        {
            double leftX, rightX;
            double eyeY, mouthY;
            leftX = X + 12;
            rightX = X + 27;
            eyeY = Y + 10;
            mouthY = Y + 30;
            SplashKit.FillRectangle(Color.Gray, X, Y, 50, 50);
            SplashKit.FillRectangle(_MainColor, leftX, eyeY, 10, 10);
            SplashKit.FillRectangle(_MainColor, rightX, eyeY, 10, 10);
            SplashKit.FillRectangle(_MainColor, leftX, mouthY, 25, 10);
            SplashKit.FillRectangle(_MainColor, leftX + 2, mouthY + 2, 21, 6);
        }
    }
}