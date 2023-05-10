using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    public static class Controller
    {
        public static Player player;
        public static void Move(string KeyWS, string KeyAD)
        {
            switch (KeyWS)
            {
                case "W":
                    if (player.y > 0)
                    {
                        player.MoveUp();
                    }
                    break;
                case "S":
                    if (player.y + player.size.Height < Form.ActiveForm.ClientSize.Height)
                    {
                        player.MoveDown();
                    }
                    break;
            }
            switch (KeyAD)
            {
                case "D":
                    if(player.x + player.size.Width < Form.ActiveForm.ClientSize.Width)
                    {
                        player.MoveRight();
                        player.currFrame = 1;
                    }
                    break;
                case "A":
                    if(player.x > 0)
                    {
                        player.MoveLeft();
                        player.currFrame = 0;
                    }
                    break;
            }
        }
    }
}
