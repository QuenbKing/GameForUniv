using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Game
{
    public static class ObstaclesController
    {
        public static List<Obstacle> obstacles;
        public static bool checker = true;
        public static int score;
        public static int limScore;
        public static int maxScore;

        public static void MoveObstacles(Player player)
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.y += obstacle.speed;
                CreateRegion(obstacle, obstacle.fileName);
                if (obstacle.y >= Screen.PrimaryScreen.Bounds.Height)
                {
                    ReCreateImage(obstacle, 0, 0, new Random());
                }
            }
        }

        public static void CheckContactWithPlayer(Player player)
        {
            foreach(var obstacle in obstacles)
            {
                if (obstacle.CheckContactWithPlayer(player))
                {
                    //player.playerImage = new Bitmap("D:\\GameForUniv\\Game\\ImagesForGame\\vinniUmer.png");
                    checker = false;
                }
            }
        }

        public static void CheckContactWithBullet(Bullet bullet)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.ContactWithBullet(bullet))
                {
                    ReCreateImage(obstacle, 0, 0, new Random());
                    BulletController.Bullets.Remove(bullet);
                }
            }
        }

        public static void SpeedUp()
        {
            if(score == limScore)
            {
                for(int i = 0; i < obstacles.Count; i++)
                {
                    obstacles[i].speed++;
                }
                limScore += 30;
            };
        }

        public static void ReCreateImage(Obstacle obs, int width, int height, Random rnd)
        {
            Size newSize;
            Point newPoint;
            obs.fileName = rnd.Next(1, 4).ToString();
            switch (obs.fileName)
            {
                case "1":
                    //width = rnd.Next(102, 205);
                    //height = rnd.Next(31, 62);
                    width = rnd.Next(Screen.PrimaryScreen.Bounds.Width / 19, (int)(Screen.PrimaryScreen.Bounds.Width / 9.5));
                    height = rnd.Next(Screen.PrimaryScreen.Bounds.Height / 35, (int)(Screen.PrimaryScreen.Bounds.Height / 17.5));
                    break;
                case "2":
                    //width = rnd.Next(100, 160);
                    width = rnd.Next(Screen.PrimaryScreen.Bounds.Width / 19, Screen.PrimaryScreen.Bounds.Width / 12);
                    height = width;
                    break;
                case "3":
                    //width = rnd.Next(115, 200);
                    width = rnd.Next((int)(Screen.PrimaryScreen.Bounds.Width / 16.7), (int)(Screen.PrimaryScreen.Bounds.Width / 9.6));
                    height = width;
                    break;
            }
            obs.obstacleImage = Directory.sprites[$"{obs.fileName}" + ".png"];
            do
            {
                newSize = new Size(width, height);
                newPoint = new Point(rnd.Next(0, Screen.PrimaryScreen.Bounds.Width - width), 
                    -rnd.Next((int)(Screen.PrimaryScreen.Bounds.Height/5.4), (int)(Screen.PrimaryScreen.Bounds.Height/1.67)));
            } while (obstacles.Any(obstacle => newPoint.X + newSize.Width >= obstacle.x && newPoint.X <= obstacle.x + obstacle.size.Width));
            obs.size = newSize;
            obs.x = newPoint.X; obs.y = newPoint.Y;

            CreateRegion(obs, obs.fileName);
        }

        private static void CreateRegion(Obstacle obs, string fileName)
        {
            obs.path = new GraphicsPath();
            switch (fileName)
            {
                case "1":
                    obs.path.AddPolygon(new Point[] { new Point(obs.x, obs.y), new Point(obs.x, obs.y + obs.size.Height), new Point(obs.x + obs.size.Width, obs.y + obs.size.Height), new Point(obs.x + obs.size.Width, obs.y) });
                    obs.region = new Region(obs.path);
                    break;
                case "2":
                    obs.path.AddPolygon(new Point[] { new Point(obs.x, obs.y), new Point(obs.x + obs.size.Width / 2, obs.y + obs.size.Height), new Point(obs.x + obs.size.Width, obs.y) });
                    obs.region = new Region(obs.path);
                    break;
                case "3":
                    obs.path.AddEllipse(new Rectangle(new Point(obs.x, obs.y), obs.size));
                    obs.region = new Region(obs.path);
                    break;
            }
        }

        public static void CreateObstacle()
        {
            for (int i = 0; i < 5; i++)
            {
                var object1 = new Obstacle();
                ReCreateImage(object1, 0, 0, new Random());
                obstacles.Add(object1);
            }
        }

    }
}
