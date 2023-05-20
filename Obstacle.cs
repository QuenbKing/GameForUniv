using System.Drawing;
using System.Drawing.Drawing2D;

namespace Game
{
    public class Obstacle
    {
        public Image obstacleImage;
        public int x, y;
        public Size size;
        public int speed;
        public string fileName;
        public GraphicsPath path;
        public Region region;

        public Obstacle()
        {
            speed = 8;
        }

        public void DrawSprite(Graphics gr)
        {
            //Brush brush = new SolidBrush(Color.Black);
            //gr.FillRegion(brush, region);
            gr.DrawImage(obstacleImage, x, y, size.Width, size.Height);
        }

        public bool CheckContactWithPlayer(Player player)
        {
            if (region.IsVisible(new Point(player.x + player.size.Width / 4, player.y))
                || region.IsVisible(new Point(player.x + player.size.Width * 3 / 4, player.y))
                || region.IsVisible(new Point(player.x + player.size.Width * 3 / 4, player.y + player.size.Height * 4 / 5))
                || region.IsVisible(new Point(player.x + player.size.Width / 4, player.y + player.size.Height * 4 / 5))
                || region.IsVisible(new Point(player.x + player.size.Width / 2, player.y))
                || region.IsVisible(new Point(player.x + player.size.Width / 2, player.y + player.size.Height * 4 / 5))
                || region.IsVisible(new Point(player.x + player.size.Width / 2, player.y + player.size.Height / 2))
                || region.IsVisible(new Point(player.x + player.size.Width / 2, player.y + player.size.Height / 3))
                || region.IsVisible(new Point(player.x + player.size.Width / 2, player.y + (int)(player.size.Height / 1.5))))
            {
                return AliveOrDead(player);
            }
            return false;
            //if (x < player.x + player.size.Width
            //    && player.x < x + size.Width
            //    && y < player.y + player.size.Height
            //    && player.y < y + size.Height)
            //{
            //    player.hearts.RemoveAt(player.hearts.Count - 1);
            //    if (player.hearts.Count != 0)
            //    {
            //        ObstaclesController.ReCreateImage(this, 0, 0, new System.Random());
            //        return false;
            //    }
            //    else
            //        return true;
            //}
            //return false;

            //region.IsVisible(new Point(player.x + player.size.Width / 2, player.y))
            //    || region.IsVisible(new Point(player.x + player.size.Width / 2, player.y + player.size.Height))
            //    || region.IsVisible(new Point(player.x, player.y + player.size.Height / 2))
            //    || region.IsVisible(new Point(player.x + player.size.Width, player.y + player.size.Height / 2))

            //region.IsVisible(new Point(player.x, player.y))
            //    || region.IsVisible(new Point(player.x + player.size.Width, player.y))
            //    || region.IsVisible(new Point(player.x + player.size.Width, player.y + player.size.Height))
            //    || region.IsVisible(new Point(player.x, player.y + player.size.Height))
            //    || region.IsVisible(new Point(player.x + player.size.Width / 2, player.y))
        }

        private bool AliveOrDead(Player player)
        {
            if (player.hearts.Count > 1)
            {
                player.hearts.RemoveAt(player.hearts.Count - 1);
                ObstaclesController.ReCreateImage(this, 0, 0, new System.Random());
                return false;
            }
            else if (player.hearts.Count == 1)
            {
                player.hearts.RemoveAt(player.hearts.Count - 1);
                return true;
            }
            else
                return true;
        }

        public bool ContactWithBullet(Bullet bullet)
        {
            if (region.IsVisible(new Point(bullet.position.X + bullet.size.Width / 2, bullet.position.Y + bullet.size.Height/2)))
                return true;
            return false;
        }
    }
}
