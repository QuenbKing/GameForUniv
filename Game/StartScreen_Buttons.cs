using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class StartScreen : Form
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

            storeButton = new Button
            {
                Location = new Point(image.Location.X, startButton.Bottom + Height / 20),
                Size = new Size(image.Width, image.Height / 4),
                Text = "Store",
                BackColor = Color.White
            };
            Controls.Add(storeButton);

            exitButton = new Button
            {
                Location = new Point(image.Location.X, storeButton.Bottom + Height / 20),
                Size = new Size(image.Width, image.Height / 4),
                Text = "Exit",
                BackColor = Color.White
            };
            Controls.Add(exitButton);
        }
    }
}