using System;
using SplashKitSDK;

namespace _6_2D
{
    delegate void Procedure();
    public class Program
    {
        public static void Method1()
        {
            Console.WriteLine("Method 1");
        }

        public static void Method2()
        {
            Console.WriteLine("Method 2");
        }

        public void Method3()
        {
            Console.WriteLine("Method 3");
        }
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
                robotDodge.Update();
                robotDodge.Draw();
            }

            gameWindow.Close();
            gameWindow = null;
        }

        public static void TestDelegate()
        {
            Procedure someProcs = null;

            someProcs += new Procedure(Program.Method1);
            someProcs += Program.Method1;
            someProcs += new Procedure(Method2);  // Example with omitted class name

            Program demo = new Program();

            someProcs += new Procedure(demo.Method3);
            someProcs();
        }
    }
}
