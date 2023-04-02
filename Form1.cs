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
        int _startDraw;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            PlayerImg = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\VinniPuh2.png");
            Init();
            this.Height = 800;
            this.Width = 800;
            player = new GameModel(new Size(PlayerImg.Width / 2, PlayerImg.Height), Width / 2 - PlayerImg.Width / 2, Height / 2, PlayerImg);
            Background = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\oblaka2.png");
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
                if (_startDraw > 0) _startDraw -= Background.Height;
            }
        }

        public void Init()
        {
            ObstaclesController.obstacles = new List<Obstacle>();
            ObstaclesController.AddPlatform(new PointF(100, 400));
            ObstaclesController.startPlatformPosY = 400;
            ObstaclesController.GenerateStartSequence();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            for(int i = 0; i < 3; i++)
            {
                gr.DrawImage(Background, 0, StartDraw + Background.Height*i);
            }
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(125 * player.currFrame), player.size), GraphicsUnit.Pixel);
            if(ObstaclesController.obstacles.Count > 0)
            {
                for (int i = 0; i < ObstaclesController.obstacles.Count; i++)
                    ObstaclesController.obstacles[i].DrawObstacle(gr);
            }
        }

        private void Follow()
        {
            int offset = 400 - player.y;
            for(int i = 0; i<ObstaclesController.obstacles.Count; i++)
            {
                var obstacle = ObstaclesController.obstacles[i];
                obstacle.transform.position.Y += offset;
            }
        }


        private void StopMove(object sender, KeyEventArgs e)
        {
            if (Key.KeyCode == e.KeyCode)
                IsPress = false;
        }

        private void StartMove(object sender, KeyEventArgs e)
        {
            IsPress = true;
            Key = e;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            StartDraw += 3;
            if (IsPress)
            {
                controller.Move(sender, Key);
            }
            Invalidate();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Follow();
            ObstaclesController.GenerateRandomObstaclePos();
            Invalidate();
        }

        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}