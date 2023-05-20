using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Game
{
    public class Player
    {
        public Image playerImage;
        public int x, y;
        public Size size;
        public int currFrame;
        public int speed;
        public static int heartsCount = 1;
        public List<Hearts> hearts;
        public static int speedBoostCount = 1;
        public List<SpeedBoosts> speedBoosts;
        public int bulletCount;
        //public GraphicsPath path;
        //public Region region;

        public Player() { }
        public Player(Size currSize, int x, int y, Image playerImage)
        {
            size = currSize;
            this.x = x;
            this.y = y;
            this.playerImage = playerImage;
            hearts = new List<Hearts>();
            speedBoosts = new List<SpeedBoosts>();  
            speed = 10;
            bulletCount = 10;
        }

        //private void CreateRegion()
        //{
        //    path.AddPolygon(new Point[] { new Point(x, y), new Point(x, y + size.Height), new Point(x + size.Width, y + size.Height), new Point(x + size.Width, y) });
        //    region = new Region(path);
        //}

        public void MoveLeft()
        {
            x -= speed;
            //path = new GraphicsPath();
            //CreateRegion();
        }

        public void MoveRight()
        {
            x+= speed;
            //path = new GraphicsPath();
            //CreateRegion();
        }

        public void MoveUp()
        {
            y-= speed;
            //path = new GraphicsPath();
            //CreateRegion();
        }

        public void MoveDown()
        {
            y+= speed;
            //path = new GraphicsPath();
            //CreateRegion();
        }

        public void CreateHearts(int countHearts)
        {
            Hearts oldHeart = null;
            for(int i = 0; i<countHearts; i++)
            {
                var heart = new Hearts();
                heart.size = new Size(51, 50);
                if (i == 0)
                {
                    heart.location = new Point(Form.ActiveForm.ClientSize.Width - heart.size.Width, 0);
                    oldHeart = heart;
                }
                else
                {
                    heart.location = new Point(oldHeart.location.X - heart.size.Width, 0);
                    oldHeart = heart;
                }
                hearts.Add(heart);
            }
        }
        public void CreateBoosts(int countBoosts)
        {
            SpeedBoosts oldSpeedBoost = null;
            for( int i = 0; i < countBoosts; i++)
            {
                var speedBoost = new SpeedBoosts();
                speedBoost.size = new Size(70, 40);
                if(i == 0)
                {
                    speedBoost.location = new Point(0, Form.ActiveForm.ClientSize.Height - speedBoost.size.Height);
                    oldSpeedBoost = speedBoost;
                }
                else
                {
                    speedBoost.location = new Point(oldSpeedBoost.location.X + oldSpeedBoost.size.Width + speedBoost.size.Height, 
                        Form.ActiveForm.ClientSize.Height - speedBoost.size.Height);
                    oldSpeedBoost = speedBoost;
                }
                speedBoosts.Add(speedBoost);
            }
        }
    }
}
