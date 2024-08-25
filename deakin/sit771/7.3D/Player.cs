using SplashKitSDK;

namespace _7_3D
{
    public class Player : Tank
    {

        private List<Bullet> _bullets = new List<Bullet>(3);


        public Player(Window gameWindow) : base(gameWindow, SplashKit.BitmapNamed("player"))
        {
            X = 400;
            Y = 750;
        }
        public void HandleInput(List<Block> blocks, List<Enemy> enemies)
        {
            SplashKit.ProcessEvents();

            int reverseVal = -1;
            int vector = 5;
            if (SplashKit.KeyDown(KeyCode.UpKey) || SplashKit.KeyDown(KeyCode.WKey))
            {
                reverseVal = 0;
                Angle = 0;
                Move(-vector, 0, blocks);
            }
            else if (SplashKit.KeyDown(KeyCode.DownKey) || SplashKit.KeyDown(KeyCode.SKey))
            {
                reverseVal = 180;
                Angle = 180;
                Move(vector, 0, blocks);
            }
            else if (SplashKit.KeyDown(KeyCode.LeftKey) || SplashKit.KeyDown(KeyCode.AKey))
            {
                reverseVal = 270;
                Angle = 270;
                Move(0, -vector, blocks);
            }
            else if (SplashKit.KeyDown(KeyCode.RightKey) || SplashKit.KeyDown(KeyCode.DKey))
            {
                reverseVal = 90;
                Angle = 90;
                Move(0, vector, blocks);
            }
            else if (SplashKit.KeyReleased(KeyCode.SpaceKey))
            {
                if (_bullets.Count < 3)
                {
                    _bullets.Add(new Bullet(X, Y, Angle));
                }
            }
            else
            {

            }

            bool collideFlag = CheckCollisionsWithEnemy(enemies);

            if (collideFlag)
            {
                switch (reverseVal)
                {
                    case 0:
                        Angle = 0;
                        Move(vector, 0, blocks);
                        break;
                    case 1:
                        Angle = 180;
                        Move(-vector, 0, blocks);
                        break;
                    case 2:
                        Angle = 270;
                        Move(0, vector, blocks);
                        break;
                    case 3:
                        Angle = 90;
                        Move(0, -vector, blocks);
                        break;
                    default:
                        break;
                }
            }
        }

        public override void Draw(List<Block> blocks)
        {
            TankBitmap.Draw(X, Y, SplashKit.OptionRotateBmp(Angle));

            _bullets.RemoveAll(r => { return r.Active == false; });
            _bullets.ForEach(b =>
            {
                b.Update(blocks);
                b.Draw();
            });
        }

        private bool CheckCollisionsWithEnemy(List<Enemy> enemies)
        {
            bool flag = false;
            foreach (Enemy e in enemies)
            {
                bool collideFlag = TankBitmap.BitmapCollision(X, Y, e.TankBitmap, e.X, e.Y);
                if (collideFlag)
                {
                    flag = true;
                }
            }

            return flag;
        }

        public int CheckBulletCollisionsWithEnemy(List<Enemy> enemies)
        {
            int count = 0;
            List<Enemy> delList = new List<Enemy>(4);
            foreach (Bullet b in _bullets)
            {
                foreach (Enemy e in enemies)
                {
                    bool collideFlag = b.BulletBitmap.BitmapCollision(b.X, b.Y, e.TankBitmap, e.X, e.Y);
                    if (collideFlag && b.Active)
                    {
                        count++;
                        delList.Add(e);
                        b.Active = false;
                    }
                }
            }
            if (delList.Count > 0)
            {
                foreach (Enemy e in delList)
                {
                    enemies.Remove(e);
                }
            }

            return count;
        }
    }

}