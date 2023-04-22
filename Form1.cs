using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Image playerImg;
        private static Image background;
        private static GameModel player;
        private static bool isPress;
        KeyEventArgs Key;
        int _startDraw;
        private static Label scores;
        private static Timer timer2;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Init();
            playerImg = new Bitmap("D:\\GameForUniv\\Game\\ImagesForGame\\VinniPuhSmall.png");
            this.Height = 1080;
            this.Width = 1920;
            player = new GameModel(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
            Resize += new EventHandler(MForm_Resize);
            background = new Bitmap("D:\\GameForUniv\\Game\\ImagesForGame\\oblaka2.png");
            StartDraw = 0;
            Paint += new PaintEventHandler(OnPaint);
            KeyDown += new KeyEventHandler(StartMove);
            KeyUp += new KeyEventHandler(StopMove);
            scores = new Label
            {
                Size = new Size(150, 30),
                Font = new Font("Tahoma", 20),
                Text = $"{ObstaclesController.score}",
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(0, 0),
                Image = new Bitmap("D:\\GameForUniv\\Game\\ImagesForGame\\scores.png"),
                ImageAlign = ContentAlignment.TopLeft,
                BackColor = Color.Transparent
            };
            Controls.Add(scores);

            var timer1 = new Timer
            {
                Interval = 15
            };
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            timer2 = new Timer
            {
                Interval = 10
            };
            timer2.Tick += Timer2_Tick;
            timer2.Start();

            var timer3 = new Timer
            {
                Interval = 1000
            };
            timer3.Tick += Timer3_Tick;
            timer3.Start();

            var timer4 = new Timer
            {
                Interval = 10
            };
            timer4.Tick += Timer4_Tick;
            timer4.Start();
        }


        public void Init()
        {
            ObstaclesController.obstacles = new List<Obstacle>();
            ObstaclesController.CreateObstacle();
            CoinsController.coinsList = new List<Coins>();
            CoinsController.CreateCoins();
        }

        int StartDraw
        {
            get => _startDraw;
            set
            {
                _startDraw = value;
                if (_startDraw > 0) _startDraw -= background.Height;
            }
        }

        private void MForm_Resize(object sender, EventArgs e)
        {
            player.x = Width / 2 - playerImg.Width / 2;
            player.y = Height / 2;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            for (int i = 0; i < 2; i++)
            {
                gr.DrawImage(background, 0, StartDraw + background.Height * i);
            }
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(100 * player.currFrame), player.size), GraphicsUnit.Pixel);
            foreach(var obs in ObstaclesController.obstacles)
            {
                obs.DrawSprite(gr);
            }
            if(CoinsController.coinsList.Count > 0)
            {
                for (int i = 0; i < CoinsController.coinsCount; i++)
                {
                    CoinsController.coinsList[i].DrawSprite(gr);
                }
            }
        }

        private void StopMove(object sender, KeyEventArgs e)
        {
            if (Key.KeyCode == e.KeyCode)
                isPress = false;
        }

        private void StartMove(object sender, KeyEventArgs e)
        {
            isPress = true;
            Key = e;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            StartDraw += 3;
            if (isPress)
            {
                Controller.player = player;
                Controller.Move(sender, Key);
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (ObstaclesController.checker == false)
            {
                timer2.Stop();
                ObstaclesController.checker = true;
                var res = MessageBox.Show("Вы проиграли!!!", "Game over", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    //Dispose();
                    //StartScreen screen = new StartScreen(); (очки будут копиться и деньги тоже)
                    //screen.ShowDialog(); 
                    Application.Restart();
                }
            }
            Invalidate();
            ObstaclesController.MoveObstacles(player);
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            ObstaclesController.score += 2;
            scores.Text = $"{ObstaclesController.score}";
            ObstaclesController.SpeedUp();
        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            CoinsController.CreateCoins();
            CoinsController.MoveCoins(player);
        }
    }
}