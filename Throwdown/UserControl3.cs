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
   

    public partial class gameScreen : UserControl
    {
        #region keyDownVariables
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool lArrowDown = false;
        bool rArrowDown = false;

        bool bDown = false;
        bool nDown = false;
        bool mDown = false;
        bool spaceDown = false;

        bool cDown = false;
        bool zDown = false;
        bool xDown = false;
        bool vDown = false;

        bool escapeDown = false;
        #endregion

        #region keyPressVariable

        bool sPress = false;
        bool downArrowPress = false;

        #endregion
        public gameScreen()
        {
            InitializeComponent();
        }

        private void gameScreen_Load(object sender, EventArgs e)
        {
            if (Form1.P1Character == "Hitbox")
            {
                
            }
        }
 private void gameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;

                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    lArrowDown = true;
                    break;
                case Keys.Right:
                    rArrowDown = true;
                    break;
            }
        }
        private void gametimer_Tick(object sender, EventArgs e)
        {
            if (Form1.P1Character == "Hitbox")
            {
                P1HitboxControls();
            }
        }
       

        public void P1HitboxControls()
        {
            if ()
        }

        
    }
}
