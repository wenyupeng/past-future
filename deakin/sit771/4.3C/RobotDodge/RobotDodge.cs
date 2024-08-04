using SplashKitSDK;

namespace RobotDodge
{
    public class RobotDodge
    {
        private Player _Player;
        private Window _GameWindow;
        private Robot _TestRobot;

        public bool Quit
        {
            get { return _Player.Quit; }
        }

        public RobotDodge(Window gameWindow)
        {
            _GameWindow = gameWindow;
            _Player = new Player(gameWindow);
            _TestRobot = new Robot(gameWindow);
        }

        public void HandleInput()
        {
            _Player.HandleInput();
            _Player.StayOnWindow(_GameWindow);

        }

        public void Update()
        {
            if (_Player.CollidedWith(_TestRobot))
            {
                _TestRobot = this.RandomRobot();
            }
        }

        public void Draw()
        {
            _GameWindow.Clear(Color.DarkGray);
            _TestRobot.Draw();
            _Player.Draw();
            _Player.StayOnWindow(_GameWindow);
            Update();
            _GameWindow.Refresh(60);
        }

        public Robot RandomRobot()
        {
            return new Robot(_GameWindow);
        }

    }
}