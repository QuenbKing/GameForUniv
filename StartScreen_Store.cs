using System.Drawing;
using System;
using System.Windows.Forms;

namespace Game
{
    public partial class StartScreen : Form
    {
        private void OpenStore(object sender, EventArgs e)
        {
            Controls.Clear();
            BackgroundImage = new Bitmap("D:\\GameForUniv\\Game\\StoreImg\\backImg3.png");
            InitStoreButtons();
        }

        private void InitStoreButtons()
        {
            var exit = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(150, 40),
                Text = "back",
                BackColor = Color.White
            };
            Controls.Add(exit);
            exit.Click += (s, ev) => Init();
            var hp = new Button
            {
                Location = new Point(400, 30),
                Size = new Size(100, 50),
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
                Location = new Point(1215, 365),
                Size = new Size(100, 50),
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
        }
    }
}