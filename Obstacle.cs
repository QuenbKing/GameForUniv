using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool CheckContactWithPlayer(GameModel player)
        {
            if (x < player.x + player.size.Width
                && player.x < x + size.Width
                && y < player.y + player.size.Height
                && player.y < y + size.Height)
                return true;
            else return false;
        }
    }
}
