using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Bullet
    {
        public Point position;
        public Size size;
        public Image sprite;
        public int speed;

        public Bullet()
        {
            speed = 15;
            sprite = CreateImages.ResizeImage(Directory.sprites["bullet.png"], new Size((int)(Screen.PrimaryScreen.Bounds.Width / 3.22), (int)(Screen.PrimaryScreen.Bounds.Height / 3.4)));
            size = new Size(Screen.PrimaryScreen.Bounds.Width/128, Screen.PrimaryScreen.Bounds.Height/27);
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(sprite, position.X, position.Y, size.Width, size.Height);
        }
    }
}
