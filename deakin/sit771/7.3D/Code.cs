using SplashKitSDK;

namespace _7_3_D
{
    public class Program
    {
        public static void Main()
        {
            Window? gameWindow = new Window("Tank Battle created by Chris 224212855", 800, 800);

            Panel panel = new Panel(gameWindow);

            while (!gameWindow.CloseRequested)
            {
                if (panel.Quit)
                {
                    break;
                }

                panel.HandleInput();
                panel.Update();
                panel.Draw();
            }

            gameWindow.Close();
            gameWindow = null;
        }
    }

    public class Panel
    {
        private Window _gameWindow;
        private Player _player;
        private int _score;
        private int _level;
        private int _initialEnemyCount = 5;
        private int _collisionsCount;
        const int _liveCircle = 30;
        private List<Block> _blocks = new List<Block>(9);
        private List<Enemy> _enemies = new List<Enemy>(10);

        public Panel(Window gameWindow)
        {
            SplashKit.LoadBitmap("player", "player.png");
            SplashKit.LoadBitmap("bullet", "fire.png");
            SplashKit.LoadBitmap("enemy", "enemy.png");
            SplashKit.LoadBitmap("block", "block.png");
            _gameWindow = gameWindow;
            _player = new Player(gameWindow);
        }

        public bool Quit { get; set; }


        public void DrawScore()
        {
            _level = Math.Max(_score / 10, 1);
            SplashKit.DrawText($"Score : {_score}  Level : {_level}", Color.Blue, 20, 20);
        }

        public void Draw()
        {
            _gameWindow.Clear(Color.Gray);
            DrawScore();
            DrawPlayerLives();

            Update();

            DrawBlocks();
            DrawEnemies();

            _player.Draw(_blocks);
            int count = _player.CheckBulletCollisionsWithEnemy(_enemies);
            if (count > 0)
            {
                _score += count;
            }
            _gameWindow.Refresh(60);
        }

        public void DrawPlayerLives()
        {
            if (_collisionsCount == 5)
            {
                Quit = true;
                return;
            }

            for (int i = 0; i < 5 - _collisionsCount; i++)
            {
                SplashKit.FillCircle(Color.Red, _gameWindow.Width - i * _liveCircle - _liveCircle / 2, _liveCircle / 2, _liveCircle / 3);
            }

            SplashKit.DrawLine(Color.Black, 0, 50, _gameWindow.Width, 50);
            SplashKit.DrawLine(Color.Black, 0, 49, _gameWindow.Width, 49);
        }

        public void DrawBlocks()
        {
            _blocks.ForEach(b => { b.Draw(); });
        }


        public void HandleInput()
        {
            _player.HandleInput(_blocks, _enemies);
            _player.StayOnWindow();
        }

        public void DrawEnemies()
        {
            int enemies = _initialEnemyCount + _level; ;
            if (_initialEnemyCount + _level > 15)
            {
                enemies = 15;
            }

            if (_enemies.Count < enemies)
            {
                HashSet<int> set = new HashSet<int>(8);
                while (set.Count < enemies - _enemies.Count)
                {
                    set.Add(SplashKit.Rnd(0, 20));
                }

                foreach (int idx in set)
                {
                    _enemies.Add(new Enemy(idx, _gameWindow));
                }
            }

            _enemies.ForEach(e =>
            {
                e.Update(_enemies, _blocks);
                e.StayOnWindow();
                bool collideFlag = e.checkBulletCollideWithPlayer(_player);
                if (collideFlag)
                {
                    _collisionsCount++;
                }
                e.Draw(_blocks);
            });

        }

        public void Update()
        {
            if (_blocks.Count < 9)
            {
                HashSet<int> set = new HashSet<int>(9);
                while (set.Count < 9)
                {
                    set.Add(SplashKit.Rnd(0, 65));
                }

                foreach (int idx in set)
                {
                    _blocks.Add(new Block(150 + idx % 8 * 50, 250 + idx / 8 * 50));
                }
            }

        }
    }

   public class Block
    {
        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        private Bitmap _blcokBitmap;

        public Bitmap BlockBitmap
        {
            get { return _blcokBitmap; }
        }


        public Block(double x, double y)
        {
            X = x;
            Y = y;
            _blcokBitmap = SplashKit.BitmapNamed("block");
        }

        public void Draw()
        {
            _blcokBitmap.Draw(X, Y);
        }
    }

    public class Bullet
    {
        private Bitmap _bulletBitmap;
        private double _X, _Y, _Angle;
        private bool _active = false;
        public Bullet(double x, double y, double angle)
        {
            _bulletBitmap = SplashKit.BitmapNamed("bullet");
            _Angle = angle;
            if (angle == 90)
            {
                _X = x + _bulletBitmap.Width / 2;
                _Y = y + _bulletBitmap.Height / 2;
                SplashKit.PointAt(X, Y);
            }
            else if (angle == 180)
            {
                _X = x - 10;
                _Y = y + _bulletBitmap.Height;
            }
            else if (angle == 270)
            {
                _X = x - _bulletBitmap.Width;
                _Y = y + _bulletBitmap.Height / 2 + 5;
            }
            else
            {
                _X = x - 10;
                _Y = y - _bulletBitmap.Height / 2;
            }
            _active = true;
        }

        public Bitmap BulletBitmap
        {
            get { return _bulletBitmap; }
        }

        public double X
        {
            get { return _X; }
        }
        public double Y
        {
            get { return _Y; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }


        public void Update(List<Block> blocks)
        {
            const int TOAST = 5;
            Vector2D movement = new Vector2D();
            Matrix2D rotation = SplashKit.RotationMatrix(_Angle);
            movement.Y -= TOAST;
            movement = SplashKit.MatrixMultiply(rotation, movement);
            _X += movement.X;
            _Y += movement.Y;

            if ((_X > SplashKit.ScreenWidth() || _X < 0) || _Y > SplashKit.ScreenHeight() || _Y < 0)
            {
                _active = false;
            }

            blocks.ForEach(block =>
            {
                bool flag = _bulletBitmap.BitmapCollision(X, Y, block.BlockBitmap, block.X, block.Y);
                if (flag)
                {
                    _active = false;
                }
            });

            if (Y < 50)
            {
                _active = false;
            }
        }

        public void Draw()
        {
            if (_active)
            {
                DrawingOptions options = SplashKit.OptionRotateBmp(_Angle + 270);
                _bulletBitmap.Draw(_X, _Y, options);
            }

        }
    }

    public abstract class Tank
    {
        private Window _gameWindow;

        private Bitmap _bitmap;

        public const int GAP = 10;

        protected Tank(Window gameWindow, Bitmap bitmap)
        {
            _gameWindow = gameWindow;
            _bitmap = bitmap;
        }

        public Window GameWindow
        {
            get { return _gameWindow; }
        }

        public Bitmap TankBitmap
        {
            get { return _bitmap; }
        }

        public double Angle
        {
            get;
            protected set;
        }

        public double X
        {
            get;
            protected set;
        }

        public double Y
        {
            get;
            protected set;
        }
        public void Move(double forward, double strafe, List<Block> blocks)
        {

            Vector2D movement = new Vector2D();
            Matrix2D rotation = SplashKit.RotationMatrix(0);

            movement.Y += forward;
            movement.X += strafe;

            movement = SplashKit.MatrixMultiply(rotation, movement);
            X += movement.X;
            Y += movement.Y;
            if (CheckCollisionsWithBlocks(blocks))
            {
                X -= movement.X;
                Y -= movement.Y;
            }
        }

        public void StayOnWindow()
        {
            if (X < GAP)
            {
                X = GAP;
            }
            else if (Y < GAP + 50)
            {
                Y = GAP + 50;
            }
            else if (X + _bitmap.Width > GameWindow.Width - GAP)
            {
                X = GameWindow.Width - GAP - _bitmap.Width;
            }
            else if (Y + _bitmap.Height > GameWindow.Height - GAP)
            {
                Y = GameWindow.Height - GAP - _bitmap.Height;
            }
            else
            {

            }
        }

        public bool CheckCollisionsWithBlocks(List<Block> blocks)
        {
            bool flag = false;
            if (blocks != null && blocks.Count > 0)
            {
                blocks.ForEach(b =>
                {
                    bool collideFlag = _bitmap.BitmapCollision(X, Y, b.BlockBitmap, b.X, b.Y);
                    if (collideFlag)
                    {
                        flag = true;
                    }
                });
            }
            return flag;
        }

        public virtual void Draw(List<Block> blocks)
        {

        }

    }

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

        public bool checkBulletCollideWithPlayer(Player player)
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