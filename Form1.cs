using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Bitmap playerImg;
        private Player player;
        private GameView view;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            InitStartScreen();
        }


        public void Init()
        {
            BulletActive = false;
            PauseActive = false;
            BackgroundImage = null;
            Controls.Clear();
            GameView.background = CreateImages.ResizeImage(Directory.sprites["oblaka2.png"], Screen.PrimaryScreen.Bounds.Size);
            InitObstaclesAndCoins();
            playerImg = CreateImages.ResizeImage(Directory.sprites["VinniPuhSmall_2-transformed.png"], new Size(Size.Width / 8, (int)(Size.Height / 4.5)));
            player = new Player(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
            InitScores();
            InitBullets();
            Keyboard();
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
            view.DrawBullets(gr);
        }
    }
}