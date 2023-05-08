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
        private static int _startDraw;
        private static Label scores;
        private static ProgressBar SpeedBoostProgress;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Init();
        }


        public void Init()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Directory.sprites = new Dictionary<string, Bitmap>();
            Directory.MakeDir();
            ObstaclesController.obstacles = new List<Obstacle>();
            CoinsController.coinsList = new List<Coins>();
            ObstaclesController.limScore = 30;
            ObstaclesController.CreateObstacle();
            CoinsController.CreateCoins();
            ObstaclesController.score = 0;
            playerImg = Directory.sprites["VinniPuhSmall_2-transformed.png"];
            player = new Player(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
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

            SpeedBoostProgress = new ProgressBar
            {
                Location = new Point(0, scores.Bottom + scores.Height),
                Size = new Size(200, 20),
                Style = ProgressBarStyle.Blocks,
                Visible = false,
                Value = 0,
                Maximum = 750
            };
            Controls.Add(SpeedBoostProgress);

            IntializeTimers();
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

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            for (int i = 0; i < 2; i++)
            {
                gr.DrawImage(background, 0, StartDraw + background.Height * i);
            }
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(80 * player.currFrame), player.size), GraphicsUnit.Pixel);
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
            KeyDown += (s, e) =>
            {
                if (e.KeyData.ToString() == "W" || e.KeyData.ToString() == "S")
                    KeyWS = e;
                else if (e.KeyData.ToString() == "A" || e.KeyData.ToString() == "D")
                    KeyAD = e;
                if (e.KeyData.ToString() == "F")
                    ActivateSpeedBoost();
            };
            KeyUp += (s, e) =>
            {
                if ((e.KeyData.ToString() == "W" && KeyWS.KeyData.ToString() != "S") || (e.KeyData.ToString() == "S" && KeyWS.KeyData.ToString() != "W"))
                    KeyWS = new KeyEventArgs(Keys.Z);
                else if ((e.KeyData.ToString() == "A" && KeyAD.KeyData.ToString() != "D") || (e.KeyData.ToString() == "D" && KeyAD.KeyData.ToString() != "A"))
                    KeyAD = new KeyEventArgs(Keys.Z);
                if (e.KeyData.ToString() == "Escape" && !PauseActive)
                    GoToPause();
            };
        }

        private void ActivateSpeedBoost()
        {
            if (player.speedBoosts.Count != 0)
            {
                player.speedBoosts.RemoveAt(player.speedBoosts.Count - 1);
                player.speed += 10;
                SpeedBoostProgress.Visible = true;
                timers.Add(SpeedBoostTimer);
                SpeedBoostTimer.Start();
            }
        }
    }
}