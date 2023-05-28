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
        private Timer InvalidateTimer;
        private static List<Timer> timers;

        private int SpeedBoostTimerTickCount;

        private void IntializeTimers()
        {
            timers = new List<Timer>();

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
            CoinsTimer.Tick += CoinsAndBulletTimer_Tick;
            timers.Add(CoinsTimer);

            InvalidateTimer = new Timer
            {
                Interval = 1
            };
            InvalidateTimer.Tick += (s, e) => Invalidate();
            timers.Add(InvalidateTimer);

            CheckContactTimer = new Timer
            {
                Interval = 10
            };
            CheckContactTimer.Tick += CheckContactTimer_Tick;
            timers.Add(CheckContactTimer);

            SpeedBoostTimer = new Timer
            {
                Interval = 1
            };
            SpeedBoostTimer.Tick += SpeedBoostTimer_Tick;

            StartTimers();
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            GameView.StartDraw += 3;
            if (KeyAD.KeyData.ToString() != "None" || KeyWS.KeyData.ToString() != "None")
            {
                Controller.player = player;
                Controller.Move(KeyWS.KeyData.ToString(), KeyAD.KeyData.ToString());
            }
        }

        private void ObstaclesMoveTimer_Tick(object sender, EventArgs e)
        {
            ObstaclesController.MoveObstacles(player);
            if (ObstaclesController.checker == false)
                GameOver();
        }

        private void ObstaclesSpeedAndScoreTimer_Tick(object sender, EventArgs e)
        {
            ObstaclesController.score += 2;
            scores.Text = $"{ObstaclesController.score}";
            ObstaclesController.SpeedUp();
        }

        private void CoinsAndBulletTimer_Tick(object sender, EventArgs e)
        {
            CoinsController.CreateCoins();
            CoinsController.MoveCoins(player);
            BulletController.MoveBullet();
        }

        private void CheckContactTimer_Tick(object sender, EventArgs e)
        {
            ObstaclesController.CheckContactWithPlayer(player);
            if (BulletController.Bullets.Count != 0)
            for(int i = 0;  i < BulletController.Bullets.Count; i++)
                    ObstaclesController.CheckContactWithBullet(BulletController.Bullets[i]);
        }

        private void SpeedBoostTimer_Tick(object sender, EventArgs e)
        {
            if (SpeedBoostTimerTickCount == 750)
            {
                BoostActive = false;
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