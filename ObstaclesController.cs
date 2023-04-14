using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public static class ObstaclesController
    {
        public static List<Obstacle> obstacles;
        public static void MoveObstacles(GameModel player)
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.y += obstacle.speed;
                //if (obstacle.CheckContactWithPlayer(player))
                //    throw new ArgumentException();
                if (obstacle.y >= Screen.PrimaryScreen.Bounds.Height)
                {
                    ReCreateImage(obstacle, 0, 0, new Random());
                }
            }
        }
        private static void ReCreateImage(Obstacle obs, int width, int height, Random rnd)
        {
            Size newSize;
            Point newPoint;
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
            obs.obstacleImage = new Bitmap(path + fileName + ".png");
            do
            {
                newSize = new Size(width, height);
                newPoint = new Point(rnd.Next(0, Screen.PrimaryScreen.Bounds.Width - width), -rnd.Next(200, 650));
            }while(obstacles.Any(obstacle => newPoint.X + newSize.Width >= obstacle.x && newPoint.X <= obstacle.x + obstacle.size.Width));
            obs.size = newSize;
            obs.x = newPoint.X; obs.y = newPoint.Y;
        }

        public static void CreateObstacle()
        {
            var rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                var object1 = new Obstacle();
                ReCreateImage(object1, 0, 0, rnd);
                obstacles.Add(object1);
            }
        }

    }
}
