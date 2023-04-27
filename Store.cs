using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
            Width = 1920;
            Height = 1080;
            BackgroundImage = new Bitmap("D:\\GameForUniv\\Game\\StoreImg\\backImg.png");
        }
    }
}
