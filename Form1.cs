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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

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
        private static List<PictureBox> objects;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            objects = new List<PictureBox>();
            playerImg = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\VinniPuhSmall.png");
            this.Height = 1080;
            this.Width = 1920;
            CreateObstacle();
            player = new GameModel(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
            background = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\oblaka2.png");
            controller = new Controller(player);
            StartDraw = 0;
            Paint += new PaintEventHandler(OnPaint);
            KeyDown += new KeyEventHandler(StartMove);
            KeyUp += new KeyEventHandler(StopMove);

            var timer1 = new Timer
            {
                Interval = 10
            };
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            var timer2 = new Timer
            {
                Interval = 10
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
            for (int i = 0; i < 2; i++)
            {
                gr.DrawImage(background, 0, StartDraw + background.Height * i);
            }
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(100 * player.currFrame), player.size), GraphicsUnit.Pixel);
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
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            MoveObstacles(10);
            Invalidate();
        }


        private void MoveObstacles(int speed)
        {
            var rnd = new Random();
            var e = new PictureBox();
            foreach (var obstacle in objects)
            {
                obstacle.Location = new Point(obstacle.Location.X, obstacle.Location.Y + speed);
                if (obstacle.Location.Y >= this.Height)
                {
                    ReCreateImage(obstacle, 0, 0);
                    obstacle.Location = new Point(GiveRndNumber(e), -rnd.Next(100, 600));
                }
                e = obstacle;
            }
        }

        private void ReCreateImage(PictureBox obstacle, int width, int height)
        {
            var rnd = new Random();
            string path = @"E:\GameForUniv\Game\Obstacles\";
            string fileName = rnd.Next(1, 4).ToString();
            switch (fileName)
            {
                case "1":
                    width = rnd.Next(102, 205);
                    height = rnd.Next(31, 62);
                    break;
                case "2":
                    width = rnd.Next(100, 200);
                    height = width;
                    break;
                case "3":
                    width = rnd.Next(115, 230);
                    height = width;
                    break;
            }
            obstacle.BackColor = Color.Transparent;
            obstacle.Image = new Bitmap(path + fileName + ".png");
            obstacle.Size = new Size(width, height);
        }

        private void CreateObstacle()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                PictureBox newObject = new PictureBox();
                newObject.SizeMode = PictureBoxSizeMode.StretchImage;
                ReCreateImage(newObject, 0, 0);
                if (i > 0)
                    newObject.Location = new Point(GiveRndNumber(objects[i-1]), -rnd.Next(100, 600));
                else
                    newObject.Location = new Point(rnd.Next(0, Width - newObject.Width), -rnd.Next(100, 600));
                Controls.Add(newObject);
                objects.Add(newObject);
            }
        }

        private int GiveRndNumber(PictureBox OldObject)
        {
            var exclude = new HashSet<int>();
            for (int j = OldObject.Location.X-300 ; j <= OldObject.Location.X + 300; j++)
            {
                exclude.Add(j);
            }
            var range = Enumerable.Range(0, Width - OldObject.Width).Where(i => !exclude.Contains(i));
            var rnd = new Random();
            int index = rnd.Next(0, Width - OldObject.Width - exclude.Count);
            return range.ElementAt(index);
        }

        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}