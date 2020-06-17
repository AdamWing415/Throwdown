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
            HitboxSelect.Focus();
        }

        private void FightButton_Click(object sender, EventArgs e)
        {

            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            gameScreen gs = new gameScreen();
            Form1.Controls.Add(gs);
            gs.Location = new Point((Form1.Width - gs.Width) / 2, (Form1.Height - gs.Height) / 2);


        }
        private void FightButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                Form1.P1Character = "unselected";
                Form1.P2Character = "unselected";
                FightButton.Hide();
                HitboxSelect.Focus();

                P1CharNameLabel.ResetText();
                P2CharNameLabel.ResetText();
                P1PreviewBox.Image = null;
                P2PreviewBox.Image = null;

                P1SelectionLabel.Hide();
                P2SelectionLabel.Hide();

                Refresh();
            }
        }
        private void tempChar_Click(object sender, EventArgs e)
        {
            if (Form1.P1Character == "unselected")
            {
                Form1.P1Character = "Hitbox";
                P1SelectionLabel.Visible = true;
                P1SelectionLabel.Location = new Point(275, 190);
                P1PreviewBox.Image = Properties.Resources.hitbox_passive;
                P1CharNameLabel.Text = "Hitbox";
                Refresh();
            }
            else if (Form1.P2Character == "unselected")
            {
                Form1.P2Character = "Hitbox";
                P2SelectionLabel.Visible = true;
                P2SelectionLabel.Location = new Point(275, 240);
                P2PreviewBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharNameLabel.Text = "Hitbox";
                Refresh();

                FightButton.Show();
                FightButton.Focus();
                FightButton.BringToFront();
            }
           
        }

        private void KeycodeSelect_Click(object sender, EventArgs e)
        {
            if (Form1.P1Character == "unselected")
            {
                Form1.P1Character = "Keycode";
                P1SelectionLabel.Visible = true;
                P1SelectionLabel.Location = new Point(585, 190);
                P1PreviewBox.Image = Properties.Resources.Keycode_passive;
                P1CharNameLabel.Text = "Keycode";
                Refresh();

            }
            else if (Form1.P2Character == "unselected")
            {
                Form1.P2Character = "Keycode";
                P2SelectionLabel.Visible = true;
                P2SelectionLabel.Location = new Point(585, 240);
                P2PreviewBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharNameLabel.Text = "Keycode";
                Refresh();

                FightButton.Show();
                FightButton.Focus(); 
                FightButton.BringToFront();
            }
        }

        private void VoidSelectButton_Click(object sender, EventArgs e)
        {
            if (Form1.P1Character == "unselected")
            {
                Form1.P1Character = "Void";
                P1SelectionLabel.Visible = true;
                P1SelectionLabel.Location = new Point(350, 340);
                P1PreviewBox.Image = Properties.Resources.Void_passive;
                P1CharNameLabel.Text = "Void";
                Refresh();
            }
            else if (Form1.P2Character == "unselected")
            {
                Form1.P2Character = "Void";
                P2SelectionLabel.Visible = true;
                P2SelectionLabel.Location = new Point(350, 390);
                P2PreviewBox.Image = Properties.Resources.P2Void_passive;
                P2CharNameLabel.Text = "Void";
                Refresh();

                FightButton.Show();
                FightButton.Focus();
                FightButton.BringToFront();
            }
        }

       
    }
}
