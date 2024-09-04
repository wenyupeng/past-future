using System.Runtime.CompilerServices;
using SplashKitSDK;

namespace _7_2C
{
    public class RobotDodge
    {
        private Player _player;
        private Window _gameWindow;
        private List<Robot> _robots = new List<Robot>();

        public bool Quit
        {
            get { return _player.Quit; }
        }

        public RobotDodge(Window gameWindow)
        {
            SplashKit.LoadBitmap("User", "Player.png");
            _gameWindow = gameWindow;
            _player = new Player(gameWindow);
        }

        public void HandleInput()
        {
            _player.HandleInput();
            _player.StayOnWindow(_gameWindow);
        }

        public void Update()
        {
            if (_robots.Count < 10)
            {
                for (int i = 0; i < 10 - _robots.Count; i++)
                {
                    _robots.Add(RandomRobot());
                }
            }

            if (_robots.Count > 0)
            {
                List<Robot> delList = new List<Robot>();
                foreach (Robot robot in _robots)
                {
                    if (_player.CollidedWith(robot) || robot.IsOffscreen(_gameWindow))
                    {
                        delList.Add(robot);
                    }
                }

                _robots.RemoveAll(delList.Contains);
                // Console.WriteLine(delList.Count);
            }

            UpdateRobots();
        }

        public void CheckCollisions()
        {
            bool collisionsFlag = false;
            for (int i = 0; i < _robots.Count; i++)
            {
                double x1 = _robots[i].X;
                double y1 = _robots[i].Y;

                for (int j = i + 1; j < _robots.Count; j++)
                {
                    double x2 = _robots[j].X;
                    double y2 = _robots[j].Y;

                    if (x2 > x1 && x2 < x1 + 50 && y2 > y1 && y2 < y1 + 50)
                    {
                        collisionsFlag = true;
                    }
                }
            }

        }

        public void UpdateRobots()
        {
            _robots.ForEach(robot =>
            {
                robot.Update();
            });
        }

        public void Draw()
        {
            _gameWindow.Clear(Color.DarkGray);

            _player.Draw();
            _robots.ForEach(r =>
            {
                r.Draw();
            });

            _gameWindow.Refresh(60);
        }

        public Robot RandomRobot()
        {
            int value = SplashKit.Rnd(0, 4);
            if (value <= 1)
            {
                return new Boxy(_gameWindow, _player);
            }
            else if (value <= 2)
            {
                return new Roundy(_gameWindow, _player);
            }
            else
            {
                return new Triangle(_gameWindow, _player);
            }
        }
    }
}