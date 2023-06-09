﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Coins
    {
        public Size size;
        public Point location;
        private static Image sprite;
        public int speed;

        public Coins()
        {
            size = new Size(100, 75);
            sprite = CreateImages.ResizeImage(Directory.sprites["Money.png"], new Size((int)(Screen.PrimaryScreen.Bounds.Width / 38.4), (int)(Screen.PrimaryScreen.Bounds.Height / 19.3)));
            speed = 14;
        }

        public void DrawSprite(Graphics gr)
        {
            gr.DrawImage(sprite, location.X, location.Y, size.Width, size.Height);
        }

        public bool CheckContactPlayerWithCoin(Player player)
        {
            if (location.X < player.x + player.size.Width
                && player.x < location.X + size.Width
                && location.Y < player.y + player.size.Height
                && player.y < location.Y + size.Height)
                return true;
            else return false;
        }
    }
}
