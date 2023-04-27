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
        private static Button storeButton;
        private static Image menuImage;
        private static Label HighSroce;
        private static Label Money;
        private static int scores;
        public StartScreen()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.Height = 1080;
            this.Width = 1920;
            Controls.Clear();
            Directory.sprites = new System.Collections.Generic.Dictionary<string, Bitmap>();
            Directory.MakeDir("StartFormImages");
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

            HighSroce = new Label
            {
                Location = new Point(image.Location.X, exitButton.Bottom + Height / 20),
                Size = new Size(image.Width, image.Height / 4),
                BackColor = Color.Transparent
            };
            Controls.Add(HighSroce);

            Money = new Label
            {
                Location = new Point(image.Location.X, HighSroce.Bottom + Height / 20),
                Size = new Size(image.Width, image.Height / 4),
                Text = $"Money:{CoinsController.money}",
                BackColor = Color.Transparent
            };
            Controls.Add(Money);



            startButton.Click += new EventHandler(LoadGame);
            storeButton.Click += new EventHandler(OpenStore);
            exitButton.Click += new EventHandler(CloseGame);
            Resize += new EventHandler(Form_Resize);

            CheckHigscore();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            image.Location = new Point(Width / 2 - menuImage.Width / 2, 0);
            image.Size = new Size(Width / 5, Height / 3);
            startButton.Location = new Point(image.Location.X, image.Bottom + Height / 20);
            startButton.Size = new Size(image.Width, image.Height / 3);
            exitButton.Location = new Point(image.Location.X, startButton.Bottom + Height / 20);
            exitButton.Size = new Size(image.Width, image.Height / 3);
            HighSroce.Location = new Point(image.Location.X, exitButton.Bottom + Height / 20);
            HighSroce.Size = new Size(image.Width, image.Height / 3);
            Money.Location = new Point(image.Location.X, HighSroce.Bottom + Height / 20);
            Money.Size = new Size(image.Width, image.Height / 3);
        }

        private void CheckHigscore()
        {
            if (ObstaclesController.score > scores)
                HighSroce.Text = $"HighScore:{ObstaclesController.score}";
            else
                HighSroce.Text = $"HighScore:{scores}";
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Hide();
            if(ObstaclesController.score > scores)
            {
                scores = ObstaclesController.score;
            }
            Form1 game = new Form1();
            game.ShowDialog();
            Close();
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenStore(object sender, EventArgs e)
        {
            Controls.Clear();
            BackgroundImage = new Bitmap("D:\\GameForUniv\\Game\\StoreImg\\backImg.png");
            var exit = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(150, 40),
                Text = "back",
                BackColor = Color.White
            };
            Controls.Add(exit);
            exit.Click += (s, ev) => Init();
            var hp = new Button
            {
                Location = new Point(420, 30),
                Size = new Size(100, 50),
                Text = "+ 1 heart",
                BackColor = Color.White
            };
            hp.Click += (s, ev) =>
            {
                if (CoinsController.money >= 100 && Player.heartsCount < 3)
                {
                    Player.heartsCount++;
                    CoinsController.money -= 100;
                }
            };
            Controls.Add(hp);
            var boost = new Button
            {
                Location = new Point(1215, 365),
                Size = new Size(100, 50),
                Text = "+ 1 speedBoost",
                BackColor = Color.White
            };
            boost.Click += (s, ev) =>
            {
                if (CoinsController.money >= 250 && Player.speedBoostCount < 3)
                {
                    Player.speedBoostCount++;
                    CoinsController.money -= 250;
                }
            };
            Controls.Add(boost);
        }
    }
}
