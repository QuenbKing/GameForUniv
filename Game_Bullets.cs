using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form 
    {
        private Label bullets;
        private bool BulletActive;

        private void InitBullets()
        {
            BulletController.Bullets = new List<Bullet>();
            bullets = new Label
            {
                Location = new Point(0, scores.Bottom + scores.Height),
                Font = new Font("Times New Roman", 20),
                Text = $"Bullets: {player.bulletCount}",
                Size = new Size(Size.Width/13, Size.Height/11),
                BackColor = Color.Transparent
            };
            Controls.Add(bullets);
        }
    }
}