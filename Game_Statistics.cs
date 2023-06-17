using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Label HighScore;
        private static Label Money;

        private void InitStatistics()
        {
            HighScore = new Label
            {
                Location = new Point(image.Location.X, exitButton.Bottom + Height / 20),
                Size = new Size(Size.Width/10, image.Height / 4),
                Text = $"HighScore:{ObstaclesController.maxScore}",
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                Font = new Font("Times New Roman", 20)
            };
            Controls.Add(HighScore);

            Money = new Label
            {
                Image = CreateImages.ResizeImage(Directory.sprites["Money.png"], new Size(Size.Width / 32, Size.Height / 17)),
                Location = new Point(image.Location.X, HighScore.Bottom),
                Size = new Size(Size.Width/12, image.Height / 4),
                Text = $"{CoinsController.money}",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Times New Roman", 20),
                ImageAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            Controls.Add(Money);
        }
    }
}