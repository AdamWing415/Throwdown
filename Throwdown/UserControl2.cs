using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Throwdown
{
    
    public partial class characterSelectScreen : UserControl
    {

        public characterSelectScreen()
        {
            InitializeComponent();

        }

        private void characterSelectScreen_Load(object sender, EventArgs e)
        {
        }

        private void tempButton_Click(object sender, EventArgs e)
        {

            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            gameScreen gs = new gameScreen();
            Form1.Controls.Add(gs);
            gs.Location = new Point((Form1.Width - gs.Width) / 2, (Form1.Height - gs.Height) / 2);

        }

        private void tempChar_Click(object sender, EventArgs e)
        {
            Form1.P1Character = "Hitbox";
            Form1.P2Character = "Hitbox";
        }

        private void KeycodeSelect_Click(object sender, EventArgs e)
        {
            Form1.P1Character = "Keycode";
            Form1.P2Character = "Keycode";
        }

        private void VoidSelectButton_Click(object sender, EventArgs e)
        {
            Form1.P1Character = "Void";
            Form1.P2Character = "Void";
        }
    }
}
