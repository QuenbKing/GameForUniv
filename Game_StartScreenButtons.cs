using System.Drawing;
using System;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Button startButton;
        private static Button exitButton;
        private static Button storeButton;

        private void InitButtons()
        {
            startButton = new Button
            {
                Location = new Point(image.Location.X, image.Bottom + Height / 30),
                Size = new Size(image.Width, image.Height / 4),
                Text = "Start",
                BackColor = Color.White
            };
            Controls.Add(startButton);
            startButton.Click += new EventHandler(LoadGame);

            storeButton = new Button
            {
                Location = new Point(image.Location.X, startButton.Bottom + Height / 20),
                Size = new Size(image.Width, image.Height / 4),
                Text = "Store",
                BackColor = Color.White
            };
            Controls.Add(storeButton);
            storeButton.Click += new EventHandler(OpenStore);

            exitButton = new Button
            {
                Location = new Point(image.Location.X, storeButton.Bottom + Height / 20),
                Size = new Size(image.Width, image.Height / 4),
                Text = "Exit",
                BackColor = Color.White
            };
            Controls.Add(exitButton);
            exitButton.Click += new EventHandler(CloseGame);
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Controls.Clear();
            if (startFormCount == 1)
            {
                startFormCount++;
                BackgroundImage = CreateImages.ResizeImage(Directory.sprites["Obuchenie2.png"], Screen.PrimaryScreen.Bounds.Size);
                var ok = new Button
                {
                    Location = new Point(Width / 2, Height * 6 / 7),
                    Size = new Size(Size.Width / 12, Size.Height / 27),
                    Text = "OK",
                    BackColor = Color.White
                };
                Controls.Add(ok);
                ok.Click += (s, ev) =>
                {
                    Init();
                    Paint += new PaintEventHandler(OnPaint);
                };
            }
            else
                Init();
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}