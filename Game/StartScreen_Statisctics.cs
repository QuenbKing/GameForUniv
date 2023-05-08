using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class StartScreen : Form
    {
        private static Label HighSroce;
        private static Label Money;

        private void InitStatistics()
        {
            HighSroce = new Label
            {
                Size = new Size(200, image.Height / 4),
                Location = new Point(Width / 2 - Width / 48, exitButton.Bottom + Height / 20),
                Text = $"HighScore:{ObstaclesController.maxScore}",
                BackColor = Color.Transparent,
                Font = new Font("Times New Roman", 20)
            };
            Controls.Add(HighSroce);

            Money = new Label
            {
                Image = Directory.sprites["Money.png"],
                Location = new Point(Width / 2, HighSroce.Bottom),
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