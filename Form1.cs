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
        private static int score;
        private static Label scores;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Init();
            playerImg = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\VinniPuhSmall.png");
            this.Height = 1080;
            this.Width = 1920;
            player = new GameModel(new Size(playerImg.Width / 2, playerImg.Height), Width / 2 - playerImg.Width / 2, Height / 2, playerImg);
            Resize += new EventHandler(MForm_Resize);
            background = new Bitmap("E:\\GameForUniv\\Game\\ImagesForGame\\oblaka2.png");
            controller = new Controller(player);
            StartDraw = 0;
            Paint += new PaintEventHandler(OnPaint);
            KeyDown += new KeyEventHandler(StartMove);
            KeyUp += new KeyEventHandler(StopMove);

            scores = new Label
            {
                Size = new Size(120, 15),
                Text = $"scores: {score}",
                Location = new Point(0, 0),
                BackColor = Color.Green
            };
            Controls.Add(scores);

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

            var timer3 = new Timer
            {
                Interval = 1000
            };
            timer3.Tick += Timer3_Tick;
            timer3.Start();
        }


        public void Init()
        {
            ObstaclesController.obstacles = new List<Obstacle>();
            ObstaclesController.CreateObstacle();
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

        private void MForm_Resize(object sender, EventArgs e)
        {
            player.x = Width / 2 - playerImg.Width / 2;
            player.y = Height / 2;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            for (int i = 0; i < 2; i++)
            {
                gr.DrawImage(background, 0, StartDraw + background.Height * i);
            }
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(100 * player.currFrame), player.size), GraphicsUnit.Pixel);
            foreach(var obs in ObstaclesController.obstacles)
            {
                obs.DrawSprite(gr);
            }
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
            ObstaclesController.MoveObstacles(player);
            Invalidate();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            score += 2;
            scores.Text = $"scores: {score}";
        }
    }
}