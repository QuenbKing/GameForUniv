using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Hearts
    {
        public Point location;
        public Size size;
        private readonly Image sprite;

        public Hearts()
        {
            sprite = Directory.sprites["Heart.png"];
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(sprite, location.X, location.Y, size.Width, size.Height);
        }
    }
}
