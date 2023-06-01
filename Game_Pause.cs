using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Label PauseBox;
        private bool PauseActive;

        private void GoToPause()
        {
            StopSpecialTimers();
            if (ObstaclesController.score > ObstaclesController.maxScore)
            {
                ObstaclesController.maxScore = ObstaclesController.score;
            }
            MakePause();
            PauseActive = true;
        }

        private void MakePause()
        {
            //var menuImg = Directory.sprites["Pause2.png"];
            var menuImg = CreateImages.ResizeImage(Directory.sprites["Pause2.png"], new Size(Size.Width / 7, Size.Height / 20));
            MakeMenu(ref PauseBox, menuImg);
            MakeContinueButton(PauseBox);
            MakeExitToMenuButton(PauseBox, Continue);
            Controls.Add(PauseBox);
        }
    }
}