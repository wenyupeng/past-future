using System.Numerics;
using SplashKitSDK;

namespace _6_2D
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

        private Vector2D Velocity
        {
            get;
            set;
        }

        private SplashKitSDK.Color _MainColor;

        private int _Width;
        private int _Height;

        public static int _FixedWidth = 50;

        public int Width
        {
            get { return 50; }
        }
        public int Height
        {
            get { return 50; }
        }
        private Circle _CollisionCircle;

        public Circle CollisionCircle
        {
            get { return _CollisionCircle; }
        }


        public Robot(Window gameWindow, Player player)
        {

            if (SplashKit.Rnd() < 0.5)
            {
                X = SplashKit.Rnd(gameWindow.Width);

                if (SplashKit.Rnd() < 0.5)
                {
                    Y = -Height;
                }
                else
                {
                    Y = gameWindow.Height;
                }
            }
            else
            {
                Y = SplashKit.Rnd(gameWindow.Height);

                if (SplashKit.Rnd() < 0.5)
                {
                    X = -Width;
                }
                else
                {
                    X = gameWindow.Width;
                }
            }

            _MainColor = Color.RandomRGB(200);

            const int SPEED = 2;
            Point2D fromPt = new Point2D()
            {
                X = _X,
                Y = _Y
            };

            Point2D toPt = new Point2D()
            {
                X = player.X,
                Y = player.Y
            };

            Vector2D dir;
            dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

            Velocity = SplashKit.VectorMultiply(dir, SPEED);
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

        public void Update()
        {
            X += Velocity.X;
            Y += Velocity.Y;
            _CollisionCircle = SplashKit.CircleAt(X + 25, Y + 25, 20);
        }

        public Boolean IsOffscreen(Window screen)
        {
            return X < -Width || X > screen.Width || Y < -Height || Y > screen.Height;
        }
    }
}