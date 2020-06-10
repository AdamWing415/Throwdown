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

        #region GeneralVariables
        //NOTE:  ground is 50 pixels off screen bottom
        int P1X, P1Y;
        int P1Width, P1Height;
        int P1HitX, P1HitY;
        int P1HitWidth, P1HitHeight;
        //use framedata for both hit stun and input lag?
        int P1FrameData = 0;
        string P1Move;
        bool P1Blocking = false;
        bool P1Parry;

        int P2X, P2Y;
        int P2Width, P2Height;
        int P2HitX, P2HitY;
        int P2HitWidth, P2HitHeight;
        int P2FrameData = 0;

        bool P2Blocking = false;
        bool P2Parry;
        string P2Move;

        int round;
        int R1Winner, R2Winner, R3Winner;

        #endregion

        public gameScreen()
        {
            InitializeComponent();
        }

        private void gameScreen_Load(object sender, EventArgs e)
        {
            

            if (Form1.P1Character == "Hitbox")
            {
                P1X = 50;
                P1Y = 150;
                P1Width = 160;
                P1Height = 300;


                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Location = new Point(P1X, P1Y);

                
            }

            this.textBox1.Focus();
        }
        private void gameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //p1 keys
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

                case Keys.B:
                    bDown = true;
                    break;
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;

                //p2 keys
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

                case Keys.Z:
                    zDown = true;
                    break;
                case Keys.X:
                    xDown = true;
                    break;
                case Keys.C:
                    cDown = true;
                    break;
                case Keys.V:
                    vDown = true;
                    break;

                //pause press
                case Keys.Escape:
                    escapeDown = true;
                    break;
            }
        }
        private void gameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //p1 keys
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;

                case Keys.B:
                    bDown = false;
                    break;
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;

                //p2 keys
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    lArrowDown = false;
                    break;
                case Keys.Right:
                    rArrowDown = false;
                    break;

                case Keys.Z:
                    zDown = false;
                    break;
                case Keys.X:
                    xDown = false;
                    break;
                case Keys.C:
                    cDown = false;
                    break;
                case Keys.V:
                    vDown = false;
                    break;

                //pause press
                case Keys.Escape:
                    escapeDown = false;
                    break;
            }
        }
        
        private void gametimer_Tick(object sender, EventArgs e)
        {

            if (Form1.P1Character == "Hitbox")
            {
                P1HitboxControls();
            }
            
            P1CharBox.Location = new Point(P1X, P1Y);
            Refresh();
        }


        public void P1HitboxControls()
        {
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (downArrowDown == true && P1FrameData == 0)
            {
                P1Blocking = true;
                P1CharBox.Image = Properties.Resources.hitbox_block;
                Refresh();
                P1FrameData = 1;
            }
            else if (downArrowPress == true && P1FrameData < 2)
            {
                P1Blocking = false;
                P1Parry = true;
                P1FrameData = 45;
            }
            else
            {
                P1Parry = false;
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                Refresh();
            }
#endregion

            #region walking
            //walking forward
            if (rArrowDown == true && P1X < 750 && P1FrameData == 0)
            {
                P1X += 8;
                //add walking frames
            }
            //walking backwards
            if (lArrowDown == true && P1X > 0 && P1FrameData == 0)
            {
                P1X -= 7;
            //add walking frames
            }
            #endregion
            //put all moves here
            #region lightNeutral
            if (mDown == true && rArrowDown == false && lArrowDown == false && P1FrameData == 0)
            {
                P1FrameData = 20;
                P1Move = "lightNeutral";
            }

            if (P1Move == "lightNeutral" && P1FrameData <= 16 && P1FrameData >= 8)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_light_neutral;
                Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 25;
                P1HitWidth = 80;
                P1HitHeight = 40;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);
                //fix when P2 is added
                /*if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false)
                {
                    P2health -= 3;
                    
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true)
                {
                //usually half damage but is odd
                    P2health -= 2;
                    
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true)
                {
                    P2health -= 0;
                    set p2 image to parry
                }
                */
            }
            if (P1Move == "lightNeutral" && P1FrameData < 8)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            if (mDown == true && rArrowDown == true && lArrowDown == false && P1FrameData == 0)
            {
                P1FrameData = 26;
                P1Move = "lightForward";
            }

            if (P1Move == "lightForward" && P1FrameData <= 18 && P1FrameData >= 11)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_light_side;
                Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 140;
                P1HitWidth = 50;
                P1HitHeight = 120;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);
                //fix when P2 is added
                /*if (P1Hitbox.IntersectsWith(P2Hurtbox))
                {
                    P2health -= 4;
                    
                }
                 if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true)
                {
                //usually half damage but is odd
                    P2health -= 2;
                    
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && sUp == true)
                {
                    P2health -= 0;
                    
                }
                */
            }
            if (P1Move == "lightForward" && P1FrameData < 11)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            if (P1FrameData > 0)
            {
                P1FrameData--;
            }

            Refresh();
        }


    }
}
