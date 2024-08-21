using System.Runtime.CompilerServices;
using SplashKitSDK;

namespace _6_2D
{
    public class RobotDodge
    {
        private Window _GameWindow;
        private Player _Player;
        private List<Robot> _Robots = new List<Robot>();
        private int _RobotCount;
        private int _GameLevel;
        private int _CollisionCount;

        private SplashKitSDK.Timer _Timer = new SplashKitSDK.Timer("RobotDodge Timer");

        public bool Quit
        {
            get { return _Player.Quit; }
        }

        public RobotDodge(Window gameWindow)
        {
            _GameWindow = gameWindow;
            _Player = new Player(gameWindow);
            _RobotCount = 4;
            _GameLevel = 1;
            _Timer.Start();
        }

        public void HandleInput()
        {
            _Player.HandleInput();
            _Player.StayOnWindow(_GameWindow);

        }

        public void Update()
        {
            GeneratedRobot();

            List<Robot> deleteList = new List<Robot>();

            foreach (var robot in _Robots)
            {
                if (_Player.CollidedWith(robot) || robot.IsOffscreen(_GameWindow))
                {
                    deleteList.Add(robot);
                    if (_Player.CollidedWith(robot))
                    {
                        _CollisionCount++;
                    }
                }
                else if (_Player.BulletCollidedWith(robot))
                {
                    deleteList.Add(robot);
                    _Player.BulletDisappear();
                }
                else
                {
                    robot.Update();
                }
            }

            foreach (var item in deleteList)
            {
                _Robots.Remove(item);
            }
        }

        public void Draw()
        {
            _GameWindow.Clear(Color.DarkGray);
            _Player.DrawLives(_CollisionCount);
            RecordScore();

            Update();
            foreach (var robot in _Robots)
            {
                robot.Draw();
            }

            _Player.Draw();
            _Player.StayOnWindow(_GameWindow);
            _GameWindow.Refresh(60);
        }

        public void RecordScore()
        {
            int seconds = (int)(_Timer.Ticks / 1000);
            _GameLevel = (seconds / 10) % 10;
            if (_GameLevel < 1)
            {
                _GameLevel = 1;
            }
            if (_GameLevel >= 10)
            {
                _GameLevel = 10;
            }

            SplashKit.DrawText("SCORE : " + seconds +" LEVEL : "+ _GameLevel, Color.Blue, "NORMAL_FONT", 14, 30, 60);
        }

        public void GeneratedRobot()
        {
            int maxRobot = Math.Min(2 * _RobotCount, _RobotCount + _GameLevel);

            if (_Robots.Count < maxRobot)
            {
                for (int i = 0; i < maxRobot; i++)
                {
                    _Robots.Add(new Robot(_GameWindow, _Player));
                }
            }
        }
    }
}