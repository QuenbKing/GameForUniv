using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public static class CreateImages
    {
        public static Bitmap ResizeImage(Image oldImage, Size size) => new Bitmap(oldImage, size);
    }
}
