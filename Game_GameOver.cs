using Game;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Label GameOverMenu;

        private void GameOver()
        {
            StopTimers();
            if(ObstaclesController.score > ObstaclesController.maxScore)
            {
                ObstaclesController.maxScore = ObstaclesController.score;
            }
            ObstaclesController.checker = true;
            MakeGameOverMenu();
        }

        private void MakeGameOverMenu()
        {
            //var menuImg = Directory.sprites["GameOver.png"];
            var menuImg = CreateImages.ResizeImage(Directory.sprites["GameOver.png"], new Size(Size.Width / 6, Size.Height / 20));
            MakeMenu(ref GameOverMenu, menuImg);
            MakeRestartButton(GameOverMenu);
            MakeExitToMenuButton(GameOverMenu, Restart);
            Controls.Add(GameOverMenu);
        }
    }
}