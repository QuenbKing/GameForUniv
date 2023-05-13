using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class StartScreen : Form
    {
        private static Label HighScore;
        private static Label Money;

        private void InitStatistics()
        {
            HighScore = new Label
            {
                Location = new Point(image.Location.X, exitButton.Bottom + Height / 20),
                Size = new Size(200, image.Height / 4),
                Text = $"HighScore:{ObstaclesController.maxScore}",
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                Font = new Font("Times New Roman", 20)
            };
            Controls.Add(HighScore);

            Money = new Label
            {
                //Image = Directory.sprites["Money.png"],
                Image = CreateImages.ResizeImage(Directory.sprites["Money.png"], new Size(Size.Width / 32, Size.Height / 17)),
                Location = new Point(image.Location.X, HighScore.Bottom),
                Size = new Size(160, image.Height / 4),
                Text = $":{CoinsController.money}",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Times New Roman", 20),
                ImageAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            Controls.Add(Money);
        }
    }
}