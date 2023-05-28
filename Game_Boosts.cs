using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static ProgressBar SpeedBoostProgress;
        private bool BoostActive;
        private void InitSpeedBoostProgress()
        {
            player.CreateHearts(Player.heartsCount);
            player.CreateBoosts(Player.speedBoostCount);
            BoostActive = false;
            SpeedBoostProgress = new ProgressBar
            {
                Location = new Point(0, (int)(Size.Height/1.1)),
                Size = new Size(Size.Width / 10, Size.Height / 54),
                Style = ProgressBarStyle.Blocks,
                Visible = false,
                Value = 0,
                Maximum = 750
            };
            Controls.Add(SpeedBoostProgress);
        }
        private void ActivateSpeedBoost()
        {
            if (player.speedBoosts.Count != 0 && BoostActive == false)
            {
                BoostActive = true;
                player.speedBoosts.RemoveAt(player.speedBoosts.Count - 1);
                player.speed += 10;
                SpeedBoostProgress.Visible = true;
                timers.Add(SpeedBoostTimer);
                SpeedBoostTimer.Start();
            }
        }
    }
}