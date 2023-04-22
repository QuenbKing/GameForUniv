using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public static class Controller
    {
        public static GameModel player;

        public static void Move(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    player.MoveRight();
                    player.currFrame = 1;
                    break;
                case "A":
                    player.MoveLeft();
                    player.currFrame = 0;
                    break;
                case "W":
                    player.MoveUp();
                    break;
                case "S":
                    player.MoveDown();
                    break;
   
            }
        }
    }
}
