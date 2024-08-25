using System;
using SplashKitSDK;

namespace _7_3D
{
    public class Program
    {
        public static void Main()
        {
            Window? gameWindow = new Window("Tank Battle created by Chris 224212855", 800, 800);

            Panel panel = new Panel(gameWindow);

            while (!gameWindow.CloseRequested)
            {
                if (panel.Quit)
                {
                    break;
                }
                
                panel.HandleInput();
                panel.Update();
                panel.Draw();
            }

            gameWindow.Close();
            gameWindow = null;
        }
    }

}
