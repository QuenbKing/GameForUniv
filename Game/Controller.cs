using System.Windows.Forms;

namespace Game
{
    public static class Controller
    {
        public static Player player;

        public static void Move(string KeyWS, string KeyAD, string KeyF)
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
                    if (player.y + player.size.Height < Form.ActiveForm.ClientSize.Height - player.size.Height * 0.5)
                    {
                        player.MoveDown();
                    }
                    break;
            }
            switch (KeyAD)
            {
                case "D":
                    if(player.x + player.size.Width < Form.ActiveForm.ClientSize.Width - player.size.Width * 0.5)
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
            if (KeyF == "F")
                ActivateSpeedBoost();
        }

        public static void ActivateSpeedBoost()
        {
            if (player.speedBoosts.Count != 0)
            {
                player.speedBoosts.RemoveAt(player.speedBoosts.Count - 1);
                player.speed += 10;
                var tickCount = 0;
                Timer tm = new Timer
                {
                    Interval = 500
                };
                tm.Tick += (s, ev) =>
                {
                    tickCount++;
                    if (tickCount == 15)
                    {
                        player.speed = 10;
                        tm.Stop();
                    }
                };
                tm.Start();
            }
        }
    }
}
