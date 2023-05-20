using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Button Restart;
        private Button Continue;
        private Button Menu;
        private void MakeRestartButton(Label PauseBox)
        {
            Restart = new Button
            {
                BackColor = Color.White,
                Size = new Size(PauseBox.Width / 2, PauseBox.Height),
                Text = "Restart",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Restart.Location = new Point(PauseBox.Location.X + PauseBox.Width - Restart.Width * 3 / 2, PauseBox.Bottom + PauseBox.Height / 2);
            Controls.Add(Restart);
            Restart.Click += (s, e) =>
            {
                Controls.Clear();
                Init();
            };
        }

        private void MakeMenu(ref Label PauseBox, Bitmap menuImage)
        {
            PauseBox = new Label
            {
                BackColor = Color.Transparent,
                Image = menuImage,
                ImageAlign = ContentAlignment.TopCenter
            };
            PauseBox.Size = PauseBox.Image.Size;
            PauseBox.Location = new Point(Width / 2 - PauseBox.Width / 2, Height / 4 + PauseBox.Height);
        }

        private void MakeContinueButton(Label PauseBox)
        {
            Continue = new Button
            {
                Size = new Size(PauseBox.Width / 2, PauseBox.Height),
                Text = "Continue",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            Continue.Location = new Point(PauseBox.Location.X + PauseBox.Width - Continue.Width * 3 / 2, PauseBox.Bottom + PauseBox.Height / 2);
            Controls.Add(Continue);
            Continue.Click += (s, e) =>
            {
                StartTimers();
                PauseActive = false;
                Controls.Remove(PauseBox);
                Controls.Remove(Continue);
                Controls.Remove(Menu);
            };
        }

        private void MakeExitToMenuButton(Label PauseBox, Button firstButton)
        {
            Menu = new Button
            {
                BackColor = Color.White,
                Size = new Size(PauseBox.Width / 2, PauseBox.Height),
                Text = "Exit to Menu",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Menu.Location = new Point(PauseBox.Location.X + PauseBox.Width - firstButton.Width * 3 / 2, firstButton.Bottom + firstButton.Height / 2);
            Controls.Add(Menu);
            Menu.Click += (s, e) =>
            {
                player.x = Screen.PrimaryScreen.Bounds.Width + player.size.Width;
                player.speedBoosts.Clear();
                player.hearts.Clear();
                ObstaclesController.obstacles.Clear();
                CoinsController.coinsList.Clear();
                BulletController.Bullets.Clear();
                Controls.Clear();
                InitStartScreen();
            };
        }
    }
}