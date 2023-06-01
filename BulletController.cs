using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    public class BulletController
    {
        public static List<Bullet> Bullets;
        public static int maxCountBullet = 10;

        public static void MoveBullet()
        {
            for(int i = 0; i<Bullets.Count; i++)
            {
                Bullets[i].position.Y -= Bullets[i].speed;
                if (Bullets[i].position.Y < 0)
                    Bullets.RemoveAt(i);
            }
        }

        public static void CreateBullets(Player player)
        {
            if(Player.bulletCount != 0) 
            {
                Bullet bullet = new Bullet();
                bullet.position = new Point(player.x + player.size.Width / 2, player.y);
                Bullets.Add(bullet);
                Player.bulletCount -= 1;
            }
        }
    }
}
