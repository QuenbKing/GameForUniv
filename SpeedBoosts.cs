using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class SpeedBoosts
    {
        public Point location;
        public Size size;
        private readonly Image sprite;

        public SpeedBoosts()
        {
            sprite = CreateImages.ResizeImage(Directory.sprites["speed.png"], new Size((int)(Screen.PrimaryScreen.Bounds.Width / 27.43), Screen.PrimaryScreen.Bounds.Height / 27));
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(sprite, location.X, location.Y, size.Width, size.Height);
        }
    }
}
