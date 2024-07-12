using System;
using SplashKitSDK;

namespace WorkingWithObjects
{
    /**
    * author: YUPENG WEN
    * date: 20240710
    */
    public class Program
    {
        // public static void Main()
        // {
        //     DrawingPictureExample();
        //     DrawingMyPicture();

        //     SplashKit.Delay(50000);
        // }

        public static void DrawingMyPicture()
        {
            Window shapesWindow = new Window("Shapes by Chris(224212855)", 800, 600);

            shapesWindow.Clear(Color.White);


            // my picture: I want to draw a smile
            // draw the face
            shapesWindow.FillCircle(Color.Yellow, 400, 300, 300);

            // draw the eyes
            shapesWindow.FillCircle(Color.Black, 300, 200, 50);
            shapesWindow.FillCircle(Color.Black, 500, 200, 50);

            // draw the mouth
            shapesWindow.DrawEllipse(Color.Black, 240, 300, 320, 200);
            shapesWindow.FillRectangle(Color.Yellow, 240, 300, 320, 100);

            shapesWindow.Refresh();
        }

        public static void DrawingPictureExample()
        {
            Window shapesWindow = new Window("Shapes by Chris(224212855)", 800, 600);
            shapesWindow.FillEllipse(Color.BrightGreen, 0, 400, 800, 400);
            shapesWindow.FillRectangle(Color.Gray, 300, 300, 200, 200);
            shapesWindow.FillTriangle(Color.Red, 250, 300, 400, 150, 550, 300);
            shapesWindow.DrawCircle(Color.Red, 50, 100, 25);
            shapesWindow.FillCircle(Color.Red, 70, 50, 20);
            shapesWindow.Refresh();

            // shapesWindow.DrawRectangle(Color.Green, 100, 150, 30, 60);
            // shapesWindow.Refresh();
            // shapesWindow.FillRectangle(Color.Green, 100, 160, 10, 40);
            // shapesWindow.DrawTriangle(Color.Blue, 150, 100, 150, 200, 175, 200);
            // shapesWindow.FillTriangle(Color.Blue, 155, 135, 155, 195, 170, 195);
            // shapesWindow.DrawEllipse(Color.Black, 200, 100, 50, 160);
            // shapesWindow.FillEllipse(Color.Black, 210, 110, 30, 140);
            // shapesWindow.DrawLine(Color.Magenta, 0, 300, 800, 300);
        }
    }
}
