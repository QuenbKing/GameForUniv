using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class StartScreen : Form
    {
        private static PictureBox image;
        private static Bitmap menuImage;
        private static int startFormCount = 1;
        public StartScreen()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            DoubleBuffered = true;
            Controls.Clear();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            Directory.sprites = new System.Collections.Generic.Dictionary<string, Bitmap>();
            Directory.MakeDir();
            BackgroundImage = null;
            BackColor = Color.LightSkyBlue;
            menuImage = Directory.sprites["Med.png"];

            image = new PictureBox
            {
                Location = new Point(Width / 2 - menuImage.Width / 2, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(Width / 5, Height / 3),
                BackColor = Color.Transparent,
                Image = menuImage
            };
            Controls.Add(image);

            InitButtons();
            InitStatistics();
            Resize += new EventHandler(Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            image.Location = new Point(Width / 2 - menuImage.Width / 2, 0);
            image.Size = new Size(Width / 5, Height / 3);
            startButton.Location = new Point(image.Location.X, image.Bottom + Height / 30);
            startButton.Size = new Size(image.Width, image.Height / 4);
            storeButton.Location = new Point(image.Location.X, startButton.Bottom + Height / 20);
            storeButton.Size = new Size(image.Width, image.Height / 4);
            exitButton.Location = new Point(image.Location.X, storeButton.Bottom + Height / 20);
            exitButton.Size = new Size(image.Width, image.Height / 4);
            HighScore.Size = Size = new Size(200, image.Height / 4);
            HighScore.Location = new Point(image.Location.X, exitButton.Bottom + Height / 20);
            HighScore.Size = Size = new Size(200, image.Height / 4);
            Money.Location = new Point(image.Location.X, HighScore.Bottom);
            Money.Size = new Size(160, image.Height / 4);
            Money.Image = CreateImages.ResizeImage(Directory.sprites["Money.png"], new Size(Size.Width / 32, Size.Height / 17));
        }
    }
}
