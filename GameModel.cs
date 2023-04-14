using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameModel
    {
        public Image playerImage;
        public int x, y;
        public Size size;
        public int currFrame;
        public int speed;

        public GameModel(Size currSize, int x, int y, Image playerImage)
        {
            size = currSize;
            this.x = x;
            this.y = y;
            this.playerImage = playerImage;
            speed = 8;
        }

        public void MoveLeft()
        {
            x -= speed;
        }

        public void MoveRight()
        {
            x+= speed;
        }

        public void MoveUp()
        {
            y-= speed;
        }

        public void MoveDown()
        {
            y+= speed;
        }
    }
}
