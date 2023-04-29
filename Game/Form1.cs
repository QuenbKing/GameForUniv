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
        private Player player;
        private static KeyEventArgs KeyAD;
        private static KeyEventArgs KeyWS;
        private static KeyEventArgs KeyF;
        private static int _startDraw;
        private static Label scores;
        private static List<Timer> timers;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Init();
        }


        public void Init()
        {
            timers = new List<Timer>();
            this.Height = 1080;
            this.Width = 1920;
            Directory.sprites = new Dictionary<string, Bitmap>();
            Directory.MakeDir("ImagesForGame");
            ObstaclesController.obstacles = new List<Obstacle>();
            CoinsController.coinsList = new List<Coins>();
            ObstaclesController.CreateObstacle();
            CoinsController.CreateCoins();
            ObstaclesController.score = 0;
            playerImg = Directory.sprites["VinniPuhSmall 2.png"];
            player = new Player(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
            player.CreateHearts(Player.heartsCount);
            player.CreateBoosts(Player.speedBoostCount);
            Resize += new EventHandler(MForm_Resize);
            background = Directory.sprites["oblaka2.png"];
            StartDraw = 0;
            Paint += new PaintEventHandler(OnPaint);
            Keyboard();

            scores = new Label
            {
                Size = new Size(150, 30),
                Font = new Font("Tahoma", 20),
                Text = $"{ObstaclesController.score}",
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(0, 0),
                Image = Directory.sprites["scores.png"],
                ImageAlign = ContentAlignment.TopLeft,
                BackColor = Color.Transparent
            };
            Controls.Add(scores);

            var timer1 = new Timer
            {
                Interval = 10
            };
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            timers.Add(timer1);

            var timer2 = new Timer
            {
                Interval = 10
            };
            timer2.Tick += Timer2_Tick;
            timer2.Start();
            timers.Add(timer2);

            var timer3 = new Timer
            {
                Interval = 1000
            };
            timer3.Tick += Timer3_Tick;
            timer3.Start();
            timers.Add(timer3);

            var timer4 = new Timer
            {
                Interval = 10
            };
            timer4.Tick += Timer4_Tick;
            timer4.Start();
            timers.Add(timer4);


            var timer5 = new Timer
            {
                Interval = 50
            };
            timer5.Tick += Timer5_Tick;
            timer5.Start();
            timers.Add(timer5);
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
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(89 * player.currFrame), player.size), GraphicsUnit.Pixel);
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
            foreach (var heart in player.hearts)
            {
                heart.Draw(gr);
            }
            foreach(var speedboost in player.speedBoosts)
            {
                speedboost.Draw(gr);
            }
        }

        private void Keyboard()
        {
            KeyAD = new KeyEventArgs(Keys.Z);
            KeyWS = new KeyEventArgs(Keys.Z);
            KeyF = new KeyEventArgs (Keys.Z);
            KeyDown += (s, e) =>
            {
                if (e.KeyData.ToString() == "W" || e.KeyData.ToString() == "S")
                    KeyWS = e;
                else if (e.KeyData.ToString() == "A" || e.KeyData.ToString() == "D")
                    KeyAD = e;
                if (e.KeyData.ToString() == "F")
                    KeyF = e;
            };
            KeyUp += (s, e) =>
            {
                if ((e.KeyData.ToString() == "W" && KeyWS.KeyData.ToString() != "S") || (e.KeyData.ToString() == "S" && KeyWS.KeyData.ToString() != "W"))
                    KeyWS = new KeyEventArgs(Keys.Z);
                else if ((e.KeyData.ToString() == "A" && KeyAD.KeyData.ToString() != "D") || (e.KeyData.ToString() == "D" && KeyAD.KeyData.ToString() != "A"))
                    KeyAD = new KeyEventArgs(Keys.Z);
            };
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            StartDraw += 3;
            if (KeyAD.KeyData.ToString() != "Z" || KeyWS.KeyData.ToString() != "Z")
            {
                Controller.player = player;
                Controller.Move(KeyWS.KeyData.ToString(), KeyAD.KeyData.ToString(), KeyF.KeyData.ToString());
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (ObstaclesController.checker == false)
            {
                foreach(var timer in timers)
                    timer.Stop();
                ObstaclesController.checker = true;
                var res = MessageBox.Show("Вы проиграли!!!", "Game over", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    Dispose();
                    StartScreen screen = new StartScreen();
                    screen.ShowDialog();
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

        private void Timer5_Tick(object sender, EventArgs e)
        {
            ObstaclesController.CheckContact(player);
        }
    }
}