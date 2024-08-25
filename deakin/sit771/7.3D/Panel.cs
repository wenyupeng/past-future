using SplashKitSDK;

namespace _7_3D
{
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
                bool collideFlag = e.CheckBulletCollideWithPlayer(_player);
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

}