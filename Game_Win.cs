using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Label Win;
        private bool firstWin = true;

        private void YouWin()
        {
            foreach (var obstacle in ObstaclesController.obstacles)
            {
                ObstaclesController.ReCreateImage(obstacle, obstacle.size.Width, obstacle.size.Height, new Random());
            }
            foreach (var coin in CoinsController.coinsList)
            {
                CoinsController.CreatePosition(coin);
            }

            if (ObstaclesController.score > ObstaclesController.maxScore)
            {
                ObstaclesController.maxScore = ObstaclesController.score;
            }

            PauseActive = true;

            var winImage = Directory.sprites["win2.png"];

            Win = new Label
            {
                Location = new Point(Width / 2 - winImage.Width / 2, 0 - winImage.Height),
                Size = new Size(winImage.Width, winImage.Height),
                BackColor = Color.Transparent,
                Image = winImage
            };
            Controls.Add(Win);
        }
    }
}