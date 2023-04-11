using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class StartScreen : Form
    {
        private static PictureBox image;
        private static Button startButton;
        private static Button exitButton;
        private static Image menuImage;
        public StartScreen()
        {
            InitializeComponent();
            BackColor = Color.LightSkyBlue;
            this.Height = 1080;
            this.Width = 1920;
            menuImage = new Bitmap("E:\\GameForUniv\\Game\\StartFormImages\\Med.png");
            image = new PictureBox
            {
                Location = new Point(Width / 2 - menuImage.Width / 2, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(Width/5, Height/3),
                BackColor = Color.Transparent,
                Image = menuImage
            };
            Controls.Add(image);

            startButton = new Button
            {
                Location = new Point(image.Location.X, image.Bottom + Height/20),
                Size = new Size(image.Width, image.Height/3),
                Text = "Start",
                BackColor = Color.White
            };
            Controls.Add(startButton);

            exitButton = new Button
            {
                Location = new Point(image.Location.X, startButton.Bottom + Height/20),
                Size = new Size(image.Width, image.Height/3),
                Text = "Exit",
                BackColor= Color.White
            };
            Controls.Add(exitButton);

            startButton.Click += new EventHandler(LoadGame);
            exitButton.Click += new EventHandler(CloseGame);
            Resize += new EventHandler(Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            image.Location = new Point(Width / 2 - menuImage.Width / 2, 0);
            image.Size = new Size(Width / 5, Height / 3);
            startButton.Location = new Point(image.Location.X, image.Bottom + Height / 20);
            startButton.Size = new Size(image.Width, image.Height / 3);
            exitButton.Location = new Point(image.Location.X, startButton.Bottom + Height / 20);
            exitButton.Size = new Size(image.Width, image.Height / 3);
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Form1 gameWindow = new Form1();
            gameWindow.ShowDialog();
            this.Close();
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Close();
        }
    }
}
