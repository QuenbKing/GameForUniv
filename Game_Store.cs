using System.Drawing;
using System;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private void OpenStore(object sender, EventArgs e)
        {
            Controls.Clear();
            GameView.background = CreateImages.ResizeImage(Directory.sprites["backImg4.png"], Screen.PrimaryScreen.Bounds.Size);
            BackgroundImage = GameView.background;
            InitStoreButtons();
        }

        private void InitStoreButtons()
        {

            var exit = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(Size.Width / 12, Size.Height / 27),
                Text = "back",
                BackColor = Color.White
            };
            Controls.Add(exit);
            exit.Click += (s, ev) => InitStartScreen();
            var hp = new Button
            {
                Location = new Point(Size.Width * 10 / 48, Size.Height / 36),
                Size = new Size(Size.Width / 19, Size.Height / 22),
                Text = "+ 1 heart",
                BackColor = Color.White
            };
            hp.Click += (s, ev) =>
            {
                if (CoinsController.money >= 250 && Player.heartsCount < 3)
                {
                    Player.heartsCount++;
                    CoinsController.money -= 250;
                }
            };
            Controls.Add(hp);
            var boost = new Button
            {
                Location = new Point(Size.Width * 50 / 79, Size.Height * 105 / 295),
                Size = new Size(Size.Width / 19, Size.Height / 22),
                Text = "+ 1 speedBoost",
                BackColor = Color.White
            };
            boost.Click += (s, ev) =>
            {
                if (CoinsController.money >= 400 && Player.speedBoostCount < 3)
                {
                    Player.speedBoostCount++;
                    CoinsController.money -= 400;
                }
            };
            Controls.Add(boost);
            var bulletsButton = new Button
            {
                Location = new Point(Size.Width * 21/100, Size.Height * 23 / 36),
                Size = new Size(Size.Width / 19, Size.Height / 22),
                Text = "+ 10 bullets",
                BackColor = Color.White
            };
            bulletsButton.Click += (s, ev) =>
            {
                if (CoinsController.money >= 500 && BulletController.maxCountBullet < 30)
                {
                    BulletController.maxCountBullet += 10;
                    CoinsController.money -= 500;
                }
            };
            Controls.Add(bulletsButton);
        }
    }
}