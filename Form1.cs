using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static Image PlayerImg;
        private static Image Background;
        private static readonly Controller controller = new Controller();
        private static bool IsPress;
        KeyEventArgs Key;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            PlayerImg = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\VinniPuh2.png");
            controller.box1 = new PictureBox
            {
                Location = new Point(Width / 2 - PlayerImg.Width / 2, Height/2),
            };
            Controls.Add(controller.box1);
            CreateBackground();
            GetTimer_1();
            GetMove();
            
        }

        private void CreateBackground()
        {
            Background = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\oblaka.png");
            var BackgroundNormally = new Bitmap(Background, new Size(Width, Height));
            BackgroundImage = BackgroundNormally;
        }

        static void Anim()
        {
            Bitmap part = new Bitmap(PlayerImg.Width/2, PlayerImg.Height);
            part.SetResolution(PlayerImg.HorizontalResolution, PlayerImg.VerticalResolution);
            Graphics g = Graphics.FromImage(part);
            controller.box1.BackColor = Color.Transparent;
            controller.box1.SizeMode = PictureBoxSizeMode.CenterImage;
            g.DrawImage(PlayerImg, 0, 0, new Rectangle(new Point(125 * controller.currFrame, 0), new Size(PlayerImg.Width/2, PlayerImg.Height)), GraphicsUnit.Pixel);
            controller.box1.Size = new Size(part.Width, part.Height);
            controller.box1.Image = part;
        }

        private void GetMove()
        {
            KeyDown += (s, e) =>
            {
                IsPress = true;
                Key = e;
            };
            KeyUp += (s, e) =>
            {
                if (Key.KeyCode == e.KeyCode)
                    IsPress = false;
            };
        }


        private void GetTimer_1()
        {
            var timer = new Timer
            {
                Interval = 1
            };
            timer.Tick += Timer1_Tick;
            timer.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Anim();
            if (IsPress)
            {
                controller.Move(sender, Key);
            }
        }


        static void Main()
        {
            Application.Run(new Form1());
        }
    }

    class Controller
    {
        public int currFrame;
        public PictureBox box1;
        public Controller()
        {
            box1= new PictureBox();
            currFrame=0;
        }

        public void Move(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    box1.Location = new Point(box1.Location.X + 3, box1.Location.Y);
                    currFrame = 1;
                    break;
                case "A":
                    box1.Location = new Point(box1.Location.X - 3, box1.Location.Y);
                    currFrame = 0;
                    break;
                case "W":
                    box1.Location = new Point(box1.Location.X, box1.Location.Y - 3);
                    break;
                case "S":
                    box1.Location = new Point(box1.Location.X, box1.Location.Y + 3);
                    break;
            }
        }
    }
}
