using System;
using SplashKitSDK;

namespace _7_4H
{
    public class Program
    {
        public static void Main()
        {
            Window window = SplashKit.OpenWindow("interface", 800, 800);

            // define variables
            string user_message = "Default message!";

            // main loop
            while (!SplashKit.QuitRequested())
            {
                // get user events
                SplashKit.ProcessEvents();

                // clear screen
                SplashKit.ClearScreen(Color.White);

                // interface!
                user_message = SplashKit.TextBox(user_message, SplashKit.RectangleFrom(300, 220, 200, 24));

                if (SplashKit.Button("Write To Terminal!", SplashKit.RectangleFrom(300, 260, 200, 24)))
                {
                    SplashKit.WriteLine(user_message);
                }

                // finally draw interface, then refresh screen
                SplashKit.DrawInterface();

                SplashKit.RefreshScreen(60);
            }
        }


        public static void Input()
        {
            // Let's read into this string...
            string name = "unknown";

            // Open a window to show the user...
            Window window = new Window("Reading Input.", 800, 600);

            // Load a font for text rendering
            Font font = new Font("input", "arial.ttf");

            // Define the area where text should appear
            Rectangle rect = SplashKit.RectangleFrom(230.0, 50.0, 200.0, 30.0);

            // Start reading text in the rectagle area
            SplashKit.StartReadingText(rect);

            // Here is our game loop
            do
            {
                // Listen for input... this will update the text read
                SplashKit.ProcessEvents();

                // Click anywhere on the screen to trigger the text input
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Start reading text in the rectagle area
                    SplashKit.StartReadingText(rect);
                }

                // Looks like we finished reading text...
                if (!SplashKit.ReadingText())
                {
                    // Was input canceled?
                    if (SplashKit.TextEntryCancelled())
                    {
                        name = "unknown";
                    }
                    else
                    {
                        // Get the name from the text input
                        name = SplashKit.TextInput();
                    }
                }

                // Draw the screen...
                window.Clear(Color.White);
                window.DrawRectangle(Color.Black, rect);

                // If we are reading text... then show what it is
                if (SplashKit.ReadingText())
                {
                    SplashKit.DrawCollectedText(Color.Black, font, 18, SplashKit.OptionDefaults());
                }

                // Draw text instructions
                window.DrawText("Click anywhere to start reading text", Color.Red, font, 18, 200, 100);

                // Draw what we have in the name
                window.DrawText(name, Color.Black, font, 18, 10, 10);

                // Show it...
                window.Refresh(60);
            } while (!window.CloseRequested);

            SplashKit.CloseAllWindows();
        }
    }
}
