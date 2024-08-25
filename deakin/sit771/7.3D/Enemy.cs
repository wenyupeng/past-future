using SplashKitSDK;

namespace _7_3D
{
    public class Enemy : Tank
    {
        private Bullet _bullet;
        private SplashKitSDK.Timer _Timer = new SplashKitSDK.Timer("RobotDodge Timer");

        public Enemy(int idx, Window gameWindow) : base(gameWindow, SplashKit.BitmapNamed("enemy"))
        {
            int row = idx / 5;
            int col = idx % 4;
            switch (col)
            {
                case 1:
                    X = 100;
                    break;
                case 2:
                    X = 700;
                    break;
                case 3:
                    X = 750;
                    break;
                case 0:
                default:
                    X = 50;
                    break;
            }

            Y = 250 + row * 50;
            _Timer.Start();
        }

        public void Update(List<Enemy> enemies, List<Block> blocks)
        {
            int updateVal = SplashKit.Rnd(0, 2);
            int seconds = (int)(_Timer.Ticks / 1000);
            if (seconds % 4 != 1 && updateVal < 1)
            {
                return;
            }


            int randomVal = SplashKit.Rnd(0, 6);
            int vector = 5;
            EnemyMove(randomVal, vector, blocks);

            bool collideFlag = false;

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e1 = enemies[i];
                for (int j = i + 1; j < enemies.Count; j++)
                {
                    Enemy e2 = enemies[j];
                    collideFlag = e1.TankBitmap.BitmapCollision(e1.X, e1.Y, e2.TankBitmap, e2.X, e2.Y);
                }
            }

            if (collideFlag)
            {
                EnemyMove(randomVal, -vector, blocks);
            }

            int bulletVal = SplashKit.Rnd(0, 3);
            if (bulletVal < 2)
            {
                if (_bullet == null)
                {
                    _bullet = new Bullet(X, Y, Angle);
                }
            }

            if (_bullet != null && !_bullet.Active)
            {
                _bullet = null;
            }
        }

        private void EnemyMove(int randomVal, int vector, List<Block> blocks)
        {
            if (randomVal == 1)
            {
                Angle = 0;
                Move(-vector, 0, blocks);
            }
            else if (randomVal == 2)
            {
                Angle = 180;
                Move(vector, 0, blocks);
            }
            else if (randomVal == 3)
            {
                Angle = 270;
                Move(0, -vector, blocks);
            }
            else if (randomVal == 5)
            {
                Angle = 90;
                Move(0, vector, blocks);
            }
            else
            {
                //do nothing
            }
        }

        public override void Draw(List<Block> blocks)
        {
            TankBitmap.Draw(X, Y, SplashKit.OptionRotateBmp(Angle));
            if (_bullet != null)
            {
                _bullet.Update(blocks);
                _bullet.Draw();
            }
        }

        public bool CheckBulletCollideWithPlayer(Player player)
        {
            bool flag = false;
            if (_bullet != null)
            {
                bool collideFlag = _bullet.BulletBitmap.BitmapCollision(_bullet.X, _bullet.Y, player.TankBitmap, player.X, player.Y);
                if (collideFlag && _bullet.Active)
                {
                    flag = true;
                }

                if (collideFlag)
                {
                    _bullet.Active = false;
                }

            }
            return flag;
        }
    }

}