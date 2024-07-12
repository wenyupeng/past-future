using System;
using SplashKitSDK;

namespace WorkingWithObjects
{
    /**
    * author: YUPENG WEN
    * date: 20240710
    */
    public class Program_Test
    {
        public static void Main()
        {
            // Declare some variables...
            Window helloWindow;
            Window anotherWindow;
            Window yetAnotherWindow;

            // Create some objects and save them
            helloWindow = new Window("Hello World", 800, 600);
            anotherWindow = new Window("Another Window", 300, 300);

            // Copy a reference
            yetAnotherWindow = helloWindow;
            
            // Ask objects to do things
            helloWindow.MoveTo(0, 0);
            anotherWindow.Clear(Color.Green);
            anotherWindow.Refresh(60);
            yetAnotherWindow.Clear(Color.Blue);
            yetAnotherWindow.Refresh(60);
            // Now work with images and sounds
            Bitmap pegasi = new Bitmap("Pegasi", "Pegasi.png");
            helloWindow.DrawBitmap(pegasi, 10, 50);
            anotherWindow.DrawBitmap(pegasi, 50, 10);
            helloWindow.Refresh(60);
            anotherWindow.Refresh(60);
            SoundEffect knock = new SoundEffect("Knock", "Knocking-84643603.wav");
            knock.Play();
            SplashKit.Delay(5000);

            Bitmap hello = new Bitmap("Hello", "Hello.png");
        }
    }
}
