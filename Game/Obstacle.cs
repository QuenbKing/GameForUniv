using System.Drawing;

namespace Game
{
    public class Obstacle
    {
        public Image obstacleImage;
        public int x, y;
        public Size size;
        public int speed;

        public Obstacle()
        {
            speed = 8;
        }

        public void DrawSprite(Graphics gr)
        {
            gr.DrawImage(obstacleImage, x, y, size.Width, size.Height);
        }

        public bool CheckContactWithPlayer(Player player)
        {
            if (x < player.x + player.size.Width
                && player.x < x + size.Width
                && y < player.y + player.size.Height
                && player.y < y + size.Height)
            {
                if (player.hearts.Count != 0)
                {
                    player.hearts.RemoveAt(player.hearts.Count - 1);
                    ObstaclesController.ReCreateImage(this, 0, 0, new System.Random());
                    return false;
                }
                else
                    return true;
            }
            return false;
        }
    }
}
