using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Image playerImg;
        private static Image background;
        Controller controller;
        private static GameModel player;
        private static bool isPress;
        KeyEventArgs Key;
        int _startDraw;
        private List<PictureBox> objects;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            objects = new List<PictureBox>();
            CreateObstacle();
            playerImg = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\VinniPuh2.png");
            this.Height = 1080;
            this.Width = 1920;
            player = new GameModel(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
            background = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\oblaka2.png");
            controller = new Controller(player);
            StartDraw = 0;
            Paint += new PaintEventHandler(OnPaint);
            KeyDown += new KeyEventHandler(StartMove);
            KeyUp += new KeyEventHandler(StopMove);

            var timer1 = new Timer
            {
                Interval = 1
            };
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            var timer2 = new Timer
            {
                Interval = 1
            };
            timer2.Tick += Timer2_Tick;
            timer2.Start();
        }
        int StartDraw
        {
            get => _startDraw;
            set
            {
                _startDraw = value;
                if (_startDraw > 0) _startDraw -= background.Height;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            for (int i = 0; i < 3; i++)
            {
                gr.DrawImage(background, 0, StartDraw + background.Height * i);
            }
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(125 * player.currFrame), player.size), GraphicsUnit.Pixel);
        }

        private void StopMove(object sender, KeyEventArgs e)
        {
            if (Key.KeyCode == e.KeyCode)
                isPress = false;
        }

        private void StartMove(object sender, KeyEventArgs e)
        {
            isPress = true;
            Key = e;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            StartDraw += 3;
            if (isPress)
            {
                controller.Move(sender, Key);
            }
            Invalidate();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<PictureBox> Obstacles = objects.Take(rnd.Next(1, 5)).ToList();
            MoveObstacle(10, Obstacles);
        }

        private void MoveObstacle(int speed, List<PictureBox> obstacles)
        {
            var rnd = new Random();
            foreach (var obstacle in obstacles)
            {
                obstacle.Location = new Point(obstacle.Location.X, obstacle.Location.Y + speed);;
                if (obstacle.Location.Y >= this.Height)
                {
                    obstacle.Size = new Size(rnd.Next(55, 220), rnd.Next(55, 220));
                    obstacle.Location = new Point(rnd.Next(0, Width - obstacle.Width), -obstacle.Height);
                }
            }
        }

        private void CreateObstacle()
        {
            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                PictureBox newObject = new PictureBox();
                newObject.Image = Image.FromFile("E:\\GameForUniv\\Game\\ImagesForGame\\wall.png");
                newObject.SizeMode = PictureBoxSizeMode.StretchImage;
                newObject.Size = new Size(rnd.Next(55, 220), rnd.Next(55, 220));
                newObject.Location = new Point(rnd.Next(0, Width - newObject.Width), -newObject.Height);
                Controls.Add(newObject);
                objects.Add(newObject);
            }
        }

        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}