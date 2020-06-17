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
    public partial class TitleScreen : UserControl
    {
        public TitleScreen()
        {
            InitializeComponent();
            playButton.Focus();
        }

        private void TitleScreen_Load(object sender, EventArgs e)
        {
            //on load set selected character to nothing
            Form1.P1Character = "unselected";
            Form1.P2Character = "unselected";
        }

        //when quit button is pressed
        private void quitButton_Click(object sender, EventArgs e)
        {
            //close the program
            System.Windows.Forms.Application.Exit();
        }

        //when play button is pressed
        private void playButton_Click(object sender, EventArgs e)
        {
            //go to character selection user control
            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            characterSelectScreen css = new characterSelectScreen();
            Form1.Controls.Add(css);
            css.Location = new Point((Form1.Width - css.Width) / 2, (Form1.Height - css.Height) / 2);
        }

        //when control button is pressed
        private void controlsButton_Click(object sender, EventArgs e)
        {
            //show controls menu
            controlMenu.Show();
            controlMenu.Focus();

        }

        //if menu is open and there is a keydown event
        private void keyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if the key pressed is M
            if (e.KeyCode == Keys.M)
            {
                //hide menu and focus playbutton
                controlMenu.Hide();
                playButton.Focus();
            }
        }
    }
}
