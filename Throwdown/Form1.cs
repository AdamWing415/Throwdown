using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Throwdown
{
    public partial class Form1 : Form
    {
        public static string P1Character = "unselected";
        public static string P2Character = "unselected";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            TitleScreen ts = new TitleScreen();
            Form1.Controls.Add(ts);
            ts.Location = new Point((Form1.Width - ts.Width) / 2, (Form1.Height - ts.Height) / 2);

            inputCover.Location = new Point((Form1.Width / 2) +430 , (Form1.Height / 2) + 220);
        }

    }
}
