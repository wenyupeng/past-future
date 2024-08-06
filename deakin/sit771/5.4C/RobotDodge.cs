using SplashKitSDK;

namespace RobotDodge
{
    public class RobotDodge
    {
        private Player _Player;
        private Window _GameWindow;
        private List<Robot> _Robots = new List<Robot>();

        public bool Quit
        {
            get { return _Player.Quit; }
        }

        public RobotDodge(Window gameWindow)
        {
            _GameWindow = gameWindow;
            _Player = new Player(gameWindow);
        }

        public void HandleInput()
        {
            _Player.HandleInput();
            _Player.StayOnWindow(_GameWindow);

        }

        public void Update()
        {
            if (_Robots.Count < 5)
            {
                for (int i = 0; i < 5 - _Robots.Count; i++)
                {
                    _Robots.Add(RandomRobot());
                }
            }

            List<Robot> deleteList = new List<Robot>();

            foreach (var robot in _Robots)
            {
                if (_Player.CollidedWith(robot) || robot.IsOffscreen(_GameWindow))
                {
                    deleteList.Add(robot);
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
            foreach (var robot in _Robots)
            {
                robot.Draw();
            }
            _Player.Draw();
            _Player.StayOnWindow(_GameWindow);
            Update();
            _GameWindow.Refresh(60);
        }

        public Robot RandomRobot()
        {
            return new Robot(_GameWindow, _Player);
        }

    }
}