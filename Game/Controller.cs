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
                    if (player.y + player.size.Height < Form.ActiveForm.ClientSize.Height - player.size.Height * 0.3)
                    {
                        player.MoveDown();
                    }
                    break;
            }
            switch (KeyAD)
            {
                case "D":
                    if(player.x + player.size.Width < Form.ActiveForm.ClientSize.Width - player.size.Width * 0.3)
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

        //public static void ActivateSpeedBoost()
        //{
        //    if (player.speedBoosts.Count != 0)
        //    {
        //        player.speedBoosts.RemoveAt(player.speedBoosts.Count - 1);
        //        player.speed += 10;
        //        progressBar.Visible = true;
        //        var tickCount = 0;
        //        var timer = new Timer
        //        {
        //            Interval = 1
        //        };
        //        timer.Tick += (s, ev) =>
        //        {
        //            if (tickCount == 750 || ObstaclesController.checker == false)
        //            {
        //                progressBar.Value = 0;
        //                progressBar.Visible = false;
        //                player.speed = 10;
        //                timer.Stop();
        //            }
        //            else
        //            {
        //                progressBar.Value++;
        //                tickCount++;
        //            }
        //        };
        //        timer.Start();
        //    }
        //}
    }
}
