using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Bitmap playerImg;
        private Player player;
        private static KeyEventArgs KeyAD;
        private static KeyEventArgs KeyWS;
        private GameView view;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Init();
            Paint += new PaintEventHandler(OnPaint);
        }


        public void Init()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            Directory.sprites = new Dictionary<string, Bitmap>();
            Directory.MakeDir();
            InitObstaclesAndCoins();
            view = new GameView();
            //playerImg = Directory.sprites["VinniPuhSmall_2-transformed.png"];
            playerImg = CreateImages.ResizeImage(Directory.sprites["VinniPuhSmall_2-transformed.png"], new Size(Size.Width / 8, (int)(Size.Height / 4.5)));
            player = new Player(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
            Keyboard();
            InitScores();
            InitSpeedBoostProgress();
            IntializeTimers();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            view.DrawBackgroung(gr);
            view.DrawPlayer(player, gr);
            view.DrawObstacles(gr);
            view.DrawCoins(gr);
            view.DrawHearts(gr, player);
            view.DrawSpeedBoosts(gr, player);
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
    }
}