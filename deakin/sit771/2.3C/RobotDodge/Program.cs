using System;
using SplashKitSDK;

namespace RobotDodge
{
    public class Program
    {
        public static void Main()
        {
            Window gameWindow = new Window("RobotDodge created by Chris 224212855", 800, 800);

            Player player = new Player(gameWindow);
            player.Play();

        }
    }
}
