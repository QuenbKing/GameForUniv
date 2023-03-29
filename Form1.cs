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
        BufferedGraphicsContext bufferedGraphicsContext;
        BufferedGraphics bufferedGraphics;
        public Form1()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            InitializeComponent();
            Graphics graphics = this.CreateGraphics();
            PlayerImg = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\VinniPuh2.png");
            player = new GameModel(new Size(PlayerImg.Width / 2, PlayerImg.Height), Width / 2 - PlayerImg.Width / 2, Height / 2, PlayerImg);
            bufferedGraphicsContext = new BufferedGraphicsContext();
            bufferedGraphics = bufferedGraphicsContext.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            Background = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\oblaka.png");
            controller = new Controller(player);
            GetTimer_1();
            GetMove();
        }

        private void GetBackground(Graphics gr)
        {
            var BackgroundNormally = new Bitmap(Background, new Size(Width, Height));
            gr.DrawImage(BackgroundNormally, 0, 0, new Rectangle(new Point(0, 0), new Size(Width, Height)), GraphicsUnit.Pixel);
        }

        private void Anim(Graphics gr)
        {
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(125 * player.currFrame), player.size), GraphicsUnit.Pixel);      
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
            GetAnim();
            if (IsPress)
            {
                controller.Move(sender, Key);
            }
        }

        private void GetAnim()
        {
            bufferedGraphics.Graphics.Clear(Color.White);
            Anim(bufferedGraphics.Graphics);
            bufferedGraphics.Render();
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
