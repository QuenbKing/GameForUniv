using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Button Continue;
        private Button Menu;
        private Label PauseBox;

        private void GoToPause()
        {
            StopTimers();
            MakePause();
        }

        private void MakePause()
        {
            PauseBox = new Label
            {
                BackColor = Color.Transparent,
                Image = new Bitmap("D:\\GameForUniv\\Game\\GamePause\\Pause2.png"),
                ImageAlign = ContentAlignment.TopCenter
            };
            PauseBox.Size = PauseBox.Image.Size;
            PauseBox.Location = new Point(Width/2 - PauseBox.Width/2, Height / 4 + PauseBox.Height);
            Continue = new Button
            {
                Size = new Size(PauseBox.Width / 2, PauseBox.Height),
                Text = "Continue",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            Continue.Location = new Point(PauseBox.Location.X + PauseBox.Width - Continue.Width * 3/2, PauseBox.Bottom + PauseBox.Height/2);
            Controls.Add(Continue);
            Continue.Click += (s, e) =>
            {
                StartTimers();
                Controls.Remove(PauseBox);
                Controls.Remove(Continue);
                Controls.Remove(Menu);
            };
            Menu = new Button
            {
                BackColor = Color.White,
                Size = new Size(PauseBox.Width / 2, PauseBox.Height),
                Text = "Exit to Menu",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Menu.Location = new Point(PauseBox.Location.X + PauseBox.Width - Continue.Width * 3 / 2, Continue.Bottom + Continue.Height/2);
            Controls.Add(Menu);
            Menu.Click += (s, e) =>
            {
                Controls.Clear();
                Dispose();
                StartScreen screen = new StartScreen();
                screen.ShowDialog();
            };
            Controls.Add(PauseBox);
        }
    }
}