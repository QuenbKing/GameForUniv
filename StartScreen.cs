using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class StartScreen : Form
    {
        private static PictureBox image;
        private static Image menuImage;
        private static int startFormCount = 1;
        public StartScreen()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            DoubleBuffered = true;
            MaximumSize = Screen.PrimaryScreen.Bounds.Size;
            MinimumSize = Screen.PrimaryScreen.Bounds.Size;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Controls.Clear();
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
            startButton.Click += new EventHandler(LoadGame);
            storeButton.Click += new EventHandler(OpenStore);
            exitButton.Click += new EventHandler(CloseGame);
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
            HighSroce.Location = new Point(Width / 2 - Width / 48, exitButton.Bottom + Height / 20);
            HighSroce.Size = new Size(160, image.Height / 4);
            Money.Location = new Point(Width / 2, HighSroce.Bottom);
            Money.Size = new Size(130, image.Height / 4);
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Controls.Clear();
            if(startFormCount == 1)
            {
                startFormCount++;
                BackgroundImage = Directory.sprites["Obuchenie.png"];
                var ok = new Button
                {
                    Location = new Point(Width / 2, Height * 5 / 6),
                    Size = new Size(150, 40),
                    Text = "OK",
                    BackColor = Color.White
                };
                Controls.Add(ok);
                ok.Click += (s, ev) =>
                {
                    StartPlay();
                };
            }
            else
                StartPlay();
        }

        private void StartPlay()
        {
            Hide();
            Form1 game = new Form1();
            game.ShowDialog();
            Dispose();
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
