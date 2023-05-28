using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private static KeyEventArgs KeyAD;
        private static KeyEventArgs KeyWS;

        private void Keyboard()
        {
            KeyAD = new KeyEventArgs(Keys.None);
            KeyWS = new KeyEventArgs(Keys.None);
            KeyDown += (s, e) => CheckKeyDown(e);
            KeyUp += (s, e) => CheckKeyUp(e);
        }

        private void CheckKeyDown(KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "W" || e.KeyData.ToString() == "S")
                KeyWS = e;
            else if (e.KeyData.ToString() == "A" || e.KeyData.ToString() == "D")
                KeyAD = e;
            if (e.KeyData.ToString() == "F")
                ActivateSpeedBoost();
            if (e.KeyData.ToString() == "E" && !BulletActive)
            {
                BulletActive = true;
                BulletController.CreateBullets(player);
                bullets.Text = $"Bullets: {player.bulletCount}";
            }
        }

        private void CheckKeyUp(KeyEventArgs e)
        {
            if ((e.KeyData.ToString() == "W" && KeyWS.KeyData.ToString() != "S") || (e.KeyData.ToString() == "S" && KeyWS.KeyData.ToString() != "W"))
                KeyWS = new KeyEventArgs(Keys.None);
            else if ((e.KeyData.ToString() == "A" && KeyAD.KeyData.ToString() != "D") || (e.KeyData.ToString() == "D" && KeyAD.KeyData.ToString() != "A"))
                KeyAD = new KeyEventArgs(Keys.None);
            if (e.KeyData.ToString() == "Escape" && !PauseActive)
                GoToPause();
            if(e.KeyData.ToString() == "E")
                BulletActive = false;
        }
    }
}