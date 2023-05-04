using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Timer MoveTimer;
        private Timer ObstaclesMoveTimer;
        private Timer ObstaclesSpeedAndScoreTimer;
        private Timer CoinsTimer;
        private Timer CheckContactTimer;
        private Timer CreateBoosts;
        private Timer SpeedBoostTimer;
        private int SpeedBoostTimerTickCount;

        private void IntializeTimers()
        {
            SpeedBoostTimerTickCount = 0;

            MoveTimer = new Timer
            {
                Interval = 10
            };
            MoveTimer.Tick += MoveTimer_Tick;
            timers.Add(MoveTimer);

            ObstaclesMoveTimer = new Timer
            {
                Interval = 10
            };
            ObstaclesMoveTimer.Tick += ObstaclesMoveTimer_Tick;
            timers.Add(ObstaclesMoveTimer);

            ObstaclesSpeedAndScoreTimer = new Timer
            {
                Interval = 1000
            };
            ObstaclesSpeedAndScoreTimer.Tick += ObstaclesSpeedAndScoreTimer_Tick;
            timers.Add(ObstaclesSpeedAndScoreTimer);

            CoinsTimer = new Timer
            {
                Interval = 10
            };
            CoinsTimer.Tick += CoinsTimer_Tick;
            timers.Add(CoinsTimer);

            CheckContactTimer = new Timer
            {
                Interval = 30
            };
            CheckContactTimer.Tick += CheckContactTimer_Tick;
            timers.Add(CheckContactTimer);

            SpeedBoostTimer = new Timer
            {
                Interval = 1
            };
            SpeedBoostTimer.Tick += SpeedBoostTimer_Tick;

            StartTimers();

            CreateBoosts = new Timer
            {
                Interval = 10
            };
            CreateBoosts.Tick += CreateBoostsTimer_Tick;
            CreateBoosts.Start();
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            StartDraw += 3;
            if (KeyAD.KeyData.ToString() != "Z" || KeyWS.KeyData.ToString() != "Z")
            {
                Controller.player = player;
                Controller.Move(KeyWS.KeyData.ToString(), KeyAD.KeyData.ToString());
            }
        }

        private void ObstaclesMoveTimer_Tick(object sender, EventArgs e)
        {
            ObstaclesController.MoveObstacles(player);
            Invalidate();
            if (ObstaclesController.checker == false)
            {
                GameOver();
            }
        }

        private void ObstaclesSpeedAndScoreTimer_Tick(object sender, EventArgs e)
        {
            ObstaclesController.score += 2;
            scores.Text = $"{ObstaclesController.score}";
            ObstaclesController.SpeedUp();
        }

        private void CoinsTimer_Tick(object sender, EventArgs e)
        {
            CoinsController.CreateCoins();
            CoinsController.MoveCoins(player);
        }

        private void CheckContactTimer_Tick(object sender, EventArgs e)
        {
            ObstaclesController.CheckContact(player);
        }

        private void CreateBoostsTimer_Tick(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                player.CreateHearts(Player.heartsCount);
                player.CreateBoosts(Player.speedBoostCount);
                CreateBoosts.Stop();
            }
        }

        private void SpeedBoostTimer_Tick(object sender, EventArgs e)
        {
            if (SpeedBoostTimerTickCount == 750)
            {
                SpeedBoostProgress.Value = 0;
                SpeedBoostProgress.Visible = false;
                player.speed = 10;
                SpeedBoostTimerTickCount = 0;
                timers.Remove(SpeedBoostTimer);
                SpeedBoostTimer.Stop();
            }
            else
            {
                SpeedBoostTimerTickCount++;
                SpeedBoostProgress.Value++;
            }
        }

        private void StartTimers()
        {
            foreach(var timer in timers)
                timer.Start();
        }

        private void StopTimers()
        {
            foreach(var timer in timers)
                timer.Stop();
        }
    }
}