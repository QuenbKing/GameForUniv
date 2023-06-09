﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class Directory
    {
        public static Dictionary<string, Bitmap> sprites;

        public static void MakeDir(DirectoryInfo imagesDirectory = null)
        {
            var way = @"GameImages";
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo(way);
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                sprites[e.Name] = (Bitmap)Image.FromFile(e.FullName);
        }
    }
}
