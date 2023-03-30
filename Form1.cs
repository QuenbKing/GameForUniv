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
        private static Image PlayerImg;
        private static Image Background;
        Controller controller;
        private static GameModel player;
        private static bool IsPress;
        KeyEventArgs Key;
        public Form1()
        {
            DoubleBuffered= true;
            InitializeComponent();
            PlayerImg = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\VinniPuh2.png");
            player = new GameModel(new Size(PlayerImg.Width / 2, PlayerImg.Height), Width / 2 - PlayerImg.Width / 2, Height / 2, PlayerImg);
            Background = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\oblaka2.png");
            controller = new Controller(player);
            SetBackground();
            Paint += new PaintEventHandler(OnPaint);
            GetTimer_1();
            GetMove();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(125 * player.currFrame), player.size), GraphicsUnit.Pixel);
        }

        private void SetBackground()
        {
            var BackgroundNormally = new Bitmap(Background, new Size(Width, Height));
            BackgroundImage = BackgroundNormally;
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
            if (IsPress)
            {
                controller.Move(sender, Key);
            }
            Invalidate();
        }

        static void Main()
        {
            Application.Run(new Form1());
        }
    }

    class Controller
    {
        public GameModel player;
        public Controller(GameModel model)
        {
            player = model;
        }

        public void Move(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    player.MoveRight();
                    player.currFrame = 1;
                    break;
                case "A":
                    player.MoveLeft();
                    player.currFrame = 0;
                    break;
                case "W":
                    player.MoveUp();
                    break;
                case "S":
                    player.MoveDown();
                    break;
            }
        }
    }
}
