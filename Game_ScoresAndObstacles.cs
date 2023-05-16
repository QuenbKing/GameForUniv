using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Label scores;
        private static void InitObstaclesAndCoins()
        {
            ObstaclesController.obstacles = new List<Obstacle>();
            CoinsController.coinsList = new List<Coins>();
            ObstaclesController.CreateObstacle();
            CoinsController.CreateCoins();
        }

        private void InitScores()
        {
            ObstaclesController.limScore = 30;
            ObstaclesController.score = 0;

            scores = new Label
            {
                Size = new Size(Size.Width / 12, Size.Height / 36),
                Font = new Font("Tahoma", 20),
                Text = $"{ObstaclesController.score}",
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(0, 0),
                //Image = Directory.sprites["scores.png"],
                Image = CreateImages.ResizeImage(Directory.sprites["scores.png"], new Size(Size.Width / 40, Size.Height / 31)),
                ImageAlign = ContentAlignment.TopLeft,
                BackColor = Color.Transparent
            };
            Controls.Add(scores);
        }
    }
}