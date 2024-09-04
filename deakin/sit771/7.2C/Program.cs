using System;
using SplashKitSDK;

namespace _7_2C
{
    public class Program
    {
        public static void Main()
        {
            Window? gameWindow = new Window("RobotDodge created by Chris 224212855", 800, 800);

            RobotDodge robotDodge = new RobotDodge(gameWindow);

            while (!gameWindow.CloseRequested)
            {
                if (robotDodge.Quit)
                {
                    break;
                }
                robotDodge.HandleInput();
                robotDodge.CheckCollisions();
                robotDodge.Update();
                robotDodge.Draw();
            }

            gameWindow.Close();
            gameWindow = null;
        }
    }
}
