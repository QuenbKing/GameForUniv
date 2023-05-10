using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public static class CreateImages
    {
        public static int difSizeWidth;
        public static int difSizeHeight;

        static CreateImages()
        {
            difSizeWidth = Screen.PrimaryScreen.Bounds.Width / 1920;
            difSizeHeight = Screen.PrimaryScreen.Bounds.Height / 1080;
        }


    }
}
