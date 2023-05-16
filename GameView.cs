using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class GameView
    {
        private static Image background;
        private static int _startDraw;

        public GameView()
        {
            StartDraw = 0;
            background = CreateImages.ResizeImage(Directory.sprites["oblaka2.png"], Screen.PrimaryScreen.Bounds.Size);
        }

        public static int StartDraw
        {
            get => _startDraw;
            set
            {
                _startDraw = value;
                if (_startDraw > 0) _startDraw -= background.Height;
            }
        }

        public void DrawPlayer(Player player, Graphics gr)
        {
            gr.DrawImage(player.playerImage, player.x, player.y, new Rectangle(new Point(player.playerImage.Size.Width / 2 * player.currFrame), player.size), GraphicsUnit.Pixel);
        }
        
        public void DrawObstacles(Graphics gr)
        {
            foreach (var obs in ObstaclesController.obstacles)
            {
                obs.DrawSprite(gr);
            }
        }

        public void DrawCoins(Graphics gr)
        {
            if (CoinsController.coinsList.Count > 0)
            {
                for (int i = 0; i < CoinsController.coinsCount; i++)
                {
                    CoinsController.coinsList[i].DrawSprite(gr);
                }
            }
        }

        public void DrawHearts(Graphics gr, Player player)
        {
            foreach (var heart in player.hearts)
            {
                heart.Draw(gr);
            }
        }

        public void DrawSpeedBoosts(Graphics gr, Player player)
        {
            foreach (var speedboost in player.speedBoosts)
            {
                speedboost.Draw(gr);
            }
        }

        public void DrawBackgroung(Graphics gr)
        {
            for (int i = 0; i < 2; i++)
            {
                gr.DrawImage(background, 0, StartDraw + background.Height * i);
            }
        }
    }
}
