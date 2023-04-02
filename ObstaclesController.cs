using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class ObstaclesController
    {
        public static List<Obstacle> obstacles;
        public static int startPlatformPosY = 400;

        public static void AddPlatform(PointF position)
        {
            Obstacle obs = new Obstacle(position);
            obstacles.Add(obs);
        }

        public static void GenerateStartSequence()
        {
            Random r = new Random();
            for(int i = 0; i < 3; i++)
            {
                int x = r.Next(0, 800);
                int y = r.Next(0, 800);
                startPlatformPosY -= y;
                PointF pos = new PointF(x, startPlatformPosY);
                Obstacle obstacle = new Obstacle(pos);
                obstacles.Add(obstacle);
            }
        }

        public static void GenerateRandomObstaclePos()
        {
            ClearObstacles();
            Random r = new Random();
            int x = r.Next(0, 800);
            PointF pos = new Point(x, startPlatformPosY);
            Obstacle obstacle = new Obstacle(pos);
            obstacles.Add(obstacle);
        }

        public static void ClearObstacles()
        {
            for(int i = 0; i<obstacles.Count; i++)
            {
                if (obstacles[i].transform.position.Y >= 800)
                    obstacles.RemoveAt(i);
            }
        }
    }
}
