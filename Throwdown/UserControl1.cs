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
        }

        private void TitleScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            characterSelectScreen css = new characterSelectScreen();
            Form1.Controls.Add(css);
            css.Location = new Point((Form1.Width - css.Width) / 2, (Form1.Height - css.Height) / 2);
        }
    }
}
