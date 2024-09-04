using System;
using SplashKitSDK;
/**
* author: Chris YUPENGWEN 224212855
* date: 20240714
*/
namespace MakingAScene
{
    public class ProgramTest
    {
        public static void Main()
        {
            Window w = new Window("sources from webcomic, edited by 224212855", 1000, 800);

            w.Clear(Color.White);
            double phi = (1 + Math.Sqrt(5)) / 2;
            // there is a loss of precision
            double x = 400 * phi, y = 400;
            // w.DrawRectangle(Color.Black, 0, 0, x, y);

            Point point = new Point(400, y);
            double r1 = 400;
            double r2 = r1 * phi - r1;
            double radius = 0L;
            bool flag = true;

            int i = 0;
            while (i < 3)
            {
                if (i == 0)
                {
                    radius = r1;
                }
                else if (i == 1)
                {
                    radius = r2;
                }
                else
                {
                    radius = r1 - r2;
                    r1 = r2;
                    r2 = radius;
                }

                double offset = r2 - (r1 - r2);

                switch (i % 4)
                {
                    case 0:
                        w.DrawRectangle(Color.Black, point.X - radius, point.Y - radius, radius, radius);
                        if (flag)
                        {
                            point = new Point(point.X, point.Y - (r1 - r2));
                            flag = false;
                        }
                        else
                        {
                            point = new Point(point.X, point.Y - offset);
                        }
                        break;
                    case 1:
                        w.DrawRectangle(Color.Black, point.X, point.Y - radius, radius, radius);
                        point = new Point(point.X + offset, point.Y);
                        break;
                    case 2:
                        w.DrawRectangle(Color.Black, point.X, point.Y, radius, radius);
                        point = new Point(point.X, point.Y + offset);
                        break;
                    case 3:
                        w.DrawRectangle(Color.Black, point.X - radius, point.Y, radius, radius);
                        point = new Point(point.X - offset, point.Y);
                        break;
                    default:
                        break;
                }
                i++;

            }
            w.Refresh(60);

            SplashKit.Delay(50000);

        }
    }

    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}