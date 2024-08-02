using SplashKitSDK;


namespace RobotDodge
{
    public class Player
    {
        private Bitmap _PlayerBitmap;
        private Window _GameWindow;

        public double X
        {
            get;
            private set;
        }

        public double Y
        {
            get;
            private set;
        }

        public bool Quit{
            get;
            private set;
        }

        public int Width
        {
            get
            {
                return _PlayerBitmap.Width;
            }
        }

        public int Height
        {
            get
            {
                return _PlayerBitmap.Height;
            }
        }

        public Player(Window gameWindow)
        {
            _PlayerBitmap = new Bitmap("User", "Player.png");
            X = (gameWindow.Width - Width) / 2;
            Y = (gameWindow.Height - Height) / 2;
            // Console.WriteLine($"BitMap Width {Width}, Height {Height}; X {X}, Y {Y}");
            _GameWindow = gameWindow;
        }

        public void Draw()
        {
            _GameWindow.DrawBitmap(_PlayerBitmap, X, Y);
        }

        public void HandleInput(){
            
        }

        public void StayOnWindow(Window limit){

        }
    }
}