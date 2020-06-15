using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Throwdown.Properties;

namespace Throwdown
{


    public partial class gameScreen : UserControl
    {
        SolidBrush healthBrush = new SolidBrush(Color.White);
        Pen linePen = new Pen(Color.Black, 8);

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
        int P1WalkCycle;
        int P1Health = 100;
        int P1Stun;

        int P2X, P2Y;
        int P2Width, P2Height;
        int P2HitX, P2HitY;
        int P2HitWidth, P2HitHeight;
        int P2FrameData = 0;
        bool P2Blocking = false;
        bool P2Parry;
        string P2Move;
        int P2WalkCycle;
        int P2Health = 100;
        int P2Stun;

        int round;
        int R1Winner, R2Winner, R3Winner;

        int P1Force = 0;
        int P2Force = 0;

        int P1JumpTimer = 0;
        int P2JumpTimer = 0;

        bool paused = false;
        #endregion

       
        public gameScreen()
        {
            InitializeComponent();
            
        }

        private void gameScreen_Load(object sender, EventArgs e)
        {
            gameScreenbackground.SendToBack();
            gameScreenbackground.Visible = true;

            if (Form1.P1Character == "Hitbox")
            {
                P1X = 50;
                P1Y = 150;
                P1Width = 160;
                P1Height = 300;
                P1WalkCycle = 35;

                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Location = new Point(P1X, P1Y);
            }

            if (Form1.P1Character == "Keycode")
            {
                P1X = 50;
                P1Y = 160;
                P1Width = 160;
                P1Height = 300;
                P1WalkCycle = 30;

                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Location = new Point(P1X, P1Y);
            }

            if (Form1.P2Character == "Hitbox")
            {
                P2X = 690;
                P2Y = 150;
                P2Width = 160;
                P2Height = 300;
                P2WalkCycle = 35;

                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Location = new Point(P2X, P2Y);
            }

            if (Form1.P2Character == "Keycode")
            {
                P2X = 690;
                P2Y = 160;
                P2Width = 160;
                P2Height = 300;
                P2WalkCycle = 30;

                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Location = new Point(P2X, P2Y);
            }

                this.inputBox.Focus();
        }
        private void continueButton_Click(object sender, EventArgs e)
        {
            paused = false;
            gametimer.Start();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            paused = false;
            gametimer.Start();
            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);
            TitleScreen ts = new TitleScreen();
            Form1.Controls.Add(ts);
            ts.Location = new Point((Form1.Width - ts.Width) / 2, (Form1.Height - ts.Height) / 2);

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
            if (Form1.P1Character == "Keycode")
            {
                P1KeycodeControls();
            }

            if (Form1.P2Character == "Hitbox")
            {
                P2HitboxControls();
            }
            if (Form1.P2Character == "Keycode")
            {
                P2KeycodeControls();
            }
            P1CharBox.Location = new Point(P1X, P1Y);
            P2CharBox.Location = new Point(P2X, P2Y);

            //player collision
            #region Collision
            if (P1X + P1Width - 20 >= P2X && P1X > 0 && P2X < 750)
            {
                P1X -= 10;
                P2X += 10;
            }
            else if (P1X + P1Width - 20 >= P2X && P1X <= 0 && P2X < 750)
            {
                P2X += 10;
            }
            else if (P1X + P1Width - 20 >= P2X && P1X > 0 && P2X >= 750)
            {
                P1X -= 10;
            }

            Refresh();
            #endregion

            #region pausing
            if (paused == true)
            {
                escapeDown = false;
                continueButton.Visible = true;
                quitButton.Visible = true;
                pauseScreen.Visible = true;
                Task.Delay(100);
                Refresh();
                gametimer.Stop();
                continueButton.Focus();
            }
            if (paused == false)
            {
                pauseScreen.Visible = false;
                continueButton.Visible = false;
                quitButton.Visible = false;
                inputBox.Focus();
                if (escapeDown == true)
                {
                    paused = true;
                }
            }
            #endregion
        }
        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(healthBrush, 25, 25, P1Health * 3, 30);
            e.Graphics.FillRectangle(healthBrush, 875 - P2Health*3, 25, P2Health * 3, 30);

            e.Graphics.DrawRectangle(linePen, 25, 25, 300, 30);
            e.Graphics.DrawRectangle(linePen, 575, 25, 300, 30);
        }

        public void P1HitboxControls()
        {
            if (P1Stun > 0)
            {
                P1FrameData = P1Stun;
            }


            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (downArrowDown == true && P1FrameData == 0)
            {
                P1Blocking = true;
                P1CharBox.Image = Properties.Resources.hitbox_block;
                P1CharBox.Refresh();
                P1FrameData = 1;
            }
            else if (downArrowPress == true && P1FrameData < 2)
            {
                P1Blocking = false;
                P1Parry = true;
                P1CharBox.Image = Properties.Resources.hitbox_parry;
                P1CharBox.Refresh();
                P1FrameData = 20;
            }
            else
            {
                P1Parry = false;
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
            }
            #endregion

            #region walking
            //walking forward
            if (rArrowDown == true && P1X < 750 && P1FrameData == 0)
            {
                P1X += 7;
                if (P1WalkCycle > 17)
                {
                    P1CharBox.Image = Properties.Resources.hitbox_walk;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 35;
                }
                else
                {
                    P1CharBox.Image = Properties.Resources.hitbox_passive;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
            }
            //walking backwards
            if (lArrowDown == true && P1X > 0 && P1FrameData == 0)
            {
                P1X -= 6;
                if (P1WalkCycle > 17)
                {
                    P1CharBox.Image = Properties.Resources.hitbox_walk;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 35;
                }
                else
                {
                    P1CharBox.Image = Properties.Resources.hitbox_passive;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
            }
            #endregion

            #region Jump
            bool jump;
           
            if (P1JumpTimer == 0 && P1Y <= 140)
            {
                jump = true;
                P1Y += 1 + P1Force;
                P1Force++;
                P1CharBox.Image = Properties.Resources.hitbox_jump;
                P1CharBox.Refresh();
            }
            if (P1Y <= 140)
            {
                jump = true;
                
            }
            else
            {
                jump = false;
                P1Force = 15;
                P1Y = 150;
            }

            if (P1JumpTimer > 0)
            {
                P1Y -= P1Force + 1;
                P1Force--;

                P1CharBox.Image = Properties.Resources.hitbox_jump;
                P1CharBox.Refresh();
                P1JumpTimer--;
            }

            if (upArrowDown == true && P1FrameData == 0 && P1Y >= 140 && jump == false)
            {
                P1JumpTimer = 15;
            }
            if (nDown == true && P1FrameData == 0 && P1Y >= 140 && jump == false)
            {
                P1JumpTimer = 15;
            }
            #endregion

            //put all moves here
            #region lightNeutral
            if (mDown == true && rArrowDown == false && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 20;
                P1Move = "lightNeutral";
            }

            if (P1Move == "lightNeutral" && P1FrameData <= 16 && P1FrameData >= 8)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_light_neutral;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 25;
                P1HitWidth = 80;
                P1HitHeight = 40;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 3;
                    P2Stun = 9;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 2;
                    P2Stun = 9;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 9;
                }

            }
            if (P1Move == "lightNeutral" && P1FrameData < 8)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 26;
                P1Move = "lightForward";
            }

            if (P1Move == "lightForward" && P1FrameData <= 18 && P1FrameData >= 11)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_light_side;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 140;
                P1HitWidth = 70;
                P1HitHeight = 120;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 4;
                    P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 2;
                    P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 8;
                }

            }
            if (P1Move == "lightForward" && P1FrameData < 11)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardAerial
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 19;
                P1Move = "ForwardAerial";
            }

            if (P1Move == "ForwardAerial" && P1FrameData <= 16 && P1FrameData >= 11)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_forward_aerial;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 250;
                P1HitWidth = 100;
                P1HitHeight = 60;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 5;
                    P2Stun = 7;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 3;
                    P2Stun = 7;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 7;
                }
            }
            if (P1Move == "ForwardAerial" && P1FrameData < 11)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralAerial
            if (mDown == true && rArrowDown == false && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 23;
                P1Move = "NeutralAerial";
            }

            if (P1Move == "NeutralAerial" && P1FrameData <= 17 && P1FrameData >= 13)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_neutral_aerial;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 260;
                P1HitWidth = 100;
                P1HitHeight = 80;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 3;
                    P2Stun = 5;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 2;
                    P2Stun = 5;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 5;
                }
            }
            if (P1Move == "NeutralAerial" && P1FrameData < 13)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralHeavy
            if (spaceDown == true && rArrowDown == false && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 27;
                P1Move = "NeutralHeavy";
            }

            if (P1Move == "NeutralHeavy" && P1FrameData <= 22 && P1FrameData >= 16)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_Neutral_Heavy;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 230;
                P1HitWidth = 100;
                P1HitHeight = 80;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 8;
                    P2Stun = 9;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {

                    P2Health -= 4;
                    P2Stun = 9;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 9;
                }
            }
            if (P1Move == "NeutralHeavy" && P1FrameData < 16)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardHeavy
            if (spaceDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 33;
                P1Move = "ForwardHeavy";
            }

            if (P1Move == "ForwardHeavy" && P1FrameData <= 27 && P1FrameData >= 19)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_forward_heavy;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 10;
                P1HitWidth = 70;
                P1HitHeight = 150;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 9;
                    P2Stun = 10;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {

                    P2Health -= 5;
                    P2Stun = 10;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 9;
                }
            }
            if (P1Move == "ForwardHeavy" && P1FrameData < 19)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            if (P1FrameData > 0)
            {
                P1FrameData--;
            }
            if (P1Stun > 0)
            {
                P1Stun--;
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.hitbox_hitstun;
                P1CharBox.Refresh();
            }
            if (P1FrameData == 0)
            {
                P1Move = "none";
            }
        }
        public void P2HitboxControls()
        {
            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (sDown == true && P2FrameData == 0)
            {
                P2Blocking = true;
                P2CharBox.Image = Properties.Resources.P2hitbox_block;
                P2CharBox.Refresh();
                P2FrameData = 1;
            }
            else if (sPress == true && P2FrameData < 2)
            {
                P2Blocking = false;
                P2Parry = true;
                P2CharBox.Image = Properties.Resources.P2hitbox_parry;
                P2CharBox.Refresh();
                P2FrameData = 20;
            }
            else
            {
                P2Parry = false;
                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Refresh();
            }
            #endregion

            #region walking
            //walking forwards
            if (aDown == true && P2X > 0 && P2FrameData == 0)
            {
                P2X -= 7;
                if (P2WalkCycle == 0)
                {
                    P2WalkCycle = 35;
                }
                else if (P2WalkCycle > 17)
                {
                    P2CharBox.Image = Properties.Resources.P2hitbox_walk;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }
                else
                {
                    P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }
            }
            //walking backwards
            if (dDown == true && P2X < 750 && P2FrameData == 0)
            {
                P2X += 6;
                if (P2WalkCycle == 0)
                {
                    P2WalkCycle = 35;
                }
                else if (P2WalkCycle > 17)
                {
                    P2CharBox.Image = Properties.Resources.P2hitbox_walk;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }

                else
                {
                    P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }
            }
            #endregion

            #region Jump
            bool jump;

            if (P2JumpTimer == 0 && P2Y <= 140)
            {
                jump = true;
                P2Y += 1 + P2Force;
                P2Force++;
                P2CharBox.Image = Properties.Resources.P2hitbox_jump;
                P2CharBox.Refresh();
            }
            if (P2Y <= 140)
            {
                jump = true;

            }
            else
            {
                jump = false;
                P2Force = 15;
                P2Y = 150;
            }

            if (P2JumpTimer > 0)
            {
                P2Y -= P2Force + 1;
                P2Force--;

                P2CharBox.Image = Properties.Resources.P2hitbox_jump;
                P2CharBox.Refresh();
                P2JumpTimer--;
            }

            if (wDown == true  && P2FrameData == 0 && P2Y >= 140 && jump == false)
            {
                P2JumpTimer = 15;
            }
            if (vDown == true && P2FrameData == 0 && P2Y >= 140 && jump == false)
            {
                P2JumpTimer = 15;
            }
            #endregion

            //put all moves here
            #region lightNeutral
            if (xDown == true && aDown == false && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 20;
                P2Move = "lightNeutral";
            }

            if (P2Move == "lightNeutral" && P2FrameData <= 16 && P2FrameData >= 8)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_light_neutral;
                P2CharBox.Refresh();

                P2HitX = P2X - 80;
                P2HitY = P2Y - 25;
                P2HitWidth = 80;
                P2HitHeight = 40;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 3;
                    P1Stun = 9;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {

                    P1Health -= 2;
                    P1Stun = 9;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 9;
                }
            }
            if (P2Move == "lightNeutral" && P2FrameData < 8)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            if (xDown == true && aDown == true && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 26;
                P2Move = "lightForward";
            }

            if (P2Move == "lightForward" && P2FrameData <= 18 && P2FrameData >= 11)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_light_side;
                P2CharBox.Refresh();

                P2HitX = P2X - 70;
                P2HitY = P2Y - 140;
                P2HitWidth = 70;
                P2HitHeight = 120;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 4;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {

                    P1Health -= 2;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 8;
                }
            }
            if (P2Move == "lightForward" && P2FrameData < 11)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardAerial
            if (xDown == true && aDown == true && P2FrameData == 0 && P2Y < 150)
            {
                P2FrameData = 19;
                P2Move = "ForwardAerial";
            }

            if (P2Move == "ForwardAerial" && P2FrameData <= 16 && P2FrameData >= 11)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_forward_aerial;
                P2CharBox.Refresh();

                P2HitX = P2X - 100;
                P2HitY = P2Y + 250;
                P2HitWidth = 100;
                P2HitHeight = 60;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 5;
                    P1Stun = 7;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {

                    P1Health -= 3;
                    P1Stun = 7;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 7;
                }
            }
            if (P2Move == "ForwardAerial" && P2FrameData < 11)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralAerial
            if (xDown == true && aDown == false && P2FrameData == 0 && P2Y < 150)
            {
                P2FrameData = 23;
                P2Move = "NeutralAerial";
            }

            if (P2Move == "NeutralAerial" && P2FrameData <= 17 && P2FrameData >= 13)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_neutral_aerial;
                P2CharBox.Refresh();

                P2HitX = P2X - 100;
                P2HitY = P2Y + 260;
                P2HitWidth = 80;
                P2HitHeight = 100;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 3;
                    P1Stun = 5;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {

                    P1Health -= 2;
                    P1Stun = 5;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 5;
                }
            }
            if (P2Move == "NeutralAerial" && P2FrameData < 13)
            {
                P1CharBox.Image = Properties.Resources.hitbox_passive;
                P1CharBox.Refresh();
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralHeavy
            if (zDown == true && aDown == false && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 27;
                P2Move = "NeutralHeavy";
            }

            if (P2Move == "NeutralHeavy" && P2FrameData <= 22 && P2FrameData >= 16)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_Neutral_Heavy;
                P2CharBox.Refresh();

                P2HitX = P2X - 100;
                P2HitY = P2Y + 230;
                P2HitWidth = 100;
                P2HitHeight = 80;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 8;
                    P1Stun = 9;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {

                    P1Health -= 4;
                    P1Stun = 9;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 9;
                }
            }
            if (P2Move == "NeutralHeavy" && P2FrameData < 16)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardHeavy
            if (zDown == true && aDown == true && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 33;
                P2Move = "ForwardHeavy";
            }

            if (P2Move == "ForwardHeavy" && P2FrameData <= 27 && P2FrameData >= 19)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_forward_heavy;
                P2CharBox.Refresh();

                P2HitX = P2X - 70;
                P2HitY = P2Y - 10;
                P2HitWidth = 70;
                P2HitHeight = 150;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 9;
                    P1Stun = 10;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {

                    P1Health -= 5;
                    P1Stun = 10;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 9;
                }
            }
            if (P2Move == "ForwardHeavy" && P2FrameData < 19)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            if (P2FrameData > 0)
            {
                P2FrameData--;
            }
            if (P2Stun > 0)
            {
                P2Stun--;
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2hitbox_hitstun;
                P2CharBox.Refresh();
            }
            if (P2FrameData == 0)
            {
                P2Move = "none";
            }
        }

        public void P1KeycodeControls()
        {
            if (P1Stun > 0)
            {
                P1FrameData = P1Stun;
            }


            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (downArrowDown == true && P1FrameData == 0)
            {
                P1Blocking = true;
                P1CharBox.Image = Properties.Resources.Keycode_block;
                P1CharBox.Refresh();
                P1FrameData = 1;
            }
            else if (downArrowPress == true && P1FrameData < 2)
            {
                P1Blocking = false;
                P1Parry = true;
                P1CharBox.Image = Properties.Resources.Keycode_Parry;
                P1CharBox.Refresh();
                P1FrameData = 20;
            }
            else
            {
                P1Parry = false;
                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Refresh();
            }
            #endregion

            #region walking
            //walking forward
            if (rArrowDown == true && P1X < 750 && P1FrameData == 0)
            {
                P1X += 8;
                if (P1WalkCycle > 15)
                {
                    P1CharBox.Image = Properties.Resources.Keycode_walk;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 30;
                }
                else
                {
                    P1CharBox.Image = Properties.Resources.Keycode_passive;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
            }
            //walking backwards
            if (lArrowDown == true && P1X > 0 && P1FrameData == 0)
            {
                P1X -= 6;
                if (P1WalkCycle > 15)
                {
                    P1CharBox.Image = Properties.Resources.Keycode_walk;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 30;
                }
                else
                {
                    P1CharBox.Image = Properties.Resources.Keycode_passive;
                    P1CharBox.Refresh();
                    P1WalkCycle--;
                }
            }
            #endregion

            #region Jump
            bool jump;

            if (P1JumpTimer == 0 && P1Y <= 150)
            {
                jump = true;
                P1CharBox.Image = Properties.Resources.Keycode_jump;
                P1CharBox.Refresh();
                P1Y += 1 + P1Force;
                P1Force++;
                
            }
            if (P1Y <= 150)
            {
                jump = true;

            }
            else
            {
                jump = false;
                P1Force = 17;
                P1Y = 160;
            }

            if (P1JumpTimer > 0)
            {
                P1Y -= P1Force + 1;
                P1Force--;

                P1CharBox.Image = Properties.Resources.Keycode_jump;
                P1CharBox.Refresh();
                P1JumpTimer--;
            }

            if (upArrowDown == true && P1FrameData == 0 && P1Y >= 150 && jump == false)
            {
                P1JumpTimer = 17;
            }
            if (nDown == true && P1FrameData == 0 && P1Y >= 150 && jump == false)
            {
                P1JumpTimer = 17;
            }
            #endregion

            //put all moves here
            #region lightNeutral
            if (mDown == true && rArrowDown == false && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 18;
                P1Move = "lightNeutral";
            }

            if (P1Move == "lightNeutral" && P1FrameData <= 15 && P1FrameData >= 9)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_light_neutral;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 30;
                P1HitWidth = 80;
                P1HitHeight = 40;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 3;
                    P2Stun = 7;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {

                    P2Health -= 2;
                    P2Stun = 7;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 7;
                }

            }
            if (P1Move == "lightNeutral" && P1FrameData < 9)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 25;
                P1Move = "lightForward";
            }

            if (P1Move == "lightForward" && P1FrameData <= 18 && P1FrameData >= 11)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_forward_light;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 100;
                P1HitWidth = 70;
                P1HitHeight = 120;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 4;
                         P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 2;
                    P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 8;
                }

            }
            if (P1Move == "lightForward" && P1FrameData < 11)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardAerial
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 19;
                P1Move = "ForwardAerial";
            }

            if (P1Move == "ForwardAerial" && P1FrameData <= 16 && P1FrameData >= 11)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_forward_air;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 250;
                P1HitWidth = 70;
                P1HitHeight = 70;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 5;
                    P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 3;
                    P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 8;
                }
            }
            if (P1Move == "ForwardAerial" && P1FrameData < 11)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralAerial
            if (mDown == true && rArrowDown == false && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 20;
                P1Move = "NeutralAerial";
            }

            if (P1Move == "NeutralAerial" && P1FrameData <= 16 && P1FrameData >= 11)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_neutral_air;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 100;
                P1HitWidth = 50;
                P1HitHeight = 180;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 3;
                    P2Stun = 7;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 2;
                    P2Stun = 7;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2CharBox.Refresh();
                    P2Stun = 7;
                }
            }
            if (P1Move == "NeutralAerial" && P1FrameData < 11)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralHeavy
            if (spaceDown == true && rArrowDown == false && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 26;
                P1Move = "NeutralHeavy";
            }

            if (P1Move == "NeutralHeavy" && P1FrameData <= 20 && P1FrameData >= 13)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_heavy_neutral;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 210;
                P1HitWidth = 100;
                P1HitHeight = 100;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 8;
                    P2Stun = 9;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 4;
                    P2Stun = 9;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 9;
                }
            }
            if (P1Move == "NeutralHeavy" && P1FrameData < 13)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardHeavy
            if (spaceDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 29;
                P1Move = "ForwardHeavy";
            }

            if (P1Move == "ForwardHeavy" && P1FrameData <= 22 && P1FrameData >= 16)
            {
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_heavy_forward;
                P1CharBox.Refresh();

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 40;
                P1HitWidth = 100;
                P1HitHeight = 60;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 9;
                    P2Stun = 10;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 5;
                    P2Stun = 10;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 9;
                }
            }
            if (P1Move == "ForwardHeavy" && P1FrameData < 16)
            {
                P1CharBox.Size = new Size(P1Width, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_passive;
                P1CharBox.Refresh();
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            if (P1FrameData > 0)
            {
                P1FrameData--;
            }
            if (P1Stun > 0)
            {
                P1Stun--;
                P1CharBox.Size = new Size(P1Width + 50, P1Height);
                P1CharBox.Image = Properties.Resources.Keycode_hitstun;
                P1CharBox.Refresh();
            }
            if (P1FrameData == 0)
            {
                P1Move = "none";
            }
        }
        public void P2KeycodeControls()
        {
            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (sDown == true && P2FrameData == 0)
            {
                P2Blocking = true;
                P2CharBox.Image = Properties.Resources.P2Keycode_block;
                P2CharBox.Refresh();
                P2FrameData = 1;
            }
            else if (sPress == true && P2FrameData < 2)
            {
                P2Blocking = false;
                P2Parry = true;
                P2CharBox.Image = Properties.Resources.P2Keycode_Parry;
                P2CharBox.Refresh();
                P2FrameData = 20;
            }
            else
            {
                P2Parry = false;
                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Refresh();
            }
            #endregion

            #region walking
            //walking forwards
            if (aDown == true && P2X > 0 && P2FrameData == 0)
            {
                P2X -= 8;
                if (P2WalkCycle == 0)
                {
                    P2WalkCycle = 35;
                }
                else if (P2WalkCycle > 15)
                {
                    P2CharBox.Image = Properties.Resources.P2Keycode_walk;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }
                else
                {
                    P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }
            }
            //walking backwards
            if (dDown == true && P2X < 750 && P2FrameData == 0)
            {
                P2X += 6;
                if (P2WalkCycle == 0)
                {
                    P2WalkCycle = 30;
                }
                else if (P2WalkCycle > 15)
                {
                    P2CharBox.Image = Properties.Resources.P2Keycode_walk;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }

                else
                {
                    P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                    P2CharBox.Refresh();
                    P2WalkCycle--;
                }
            }
            #endregion

            #region Jump
            bool jump;

            if (P2JumpTimer == 0 && P2Y <= 150)
            {
                jump = true;
                P2Y += 1 + P2Force;
                P2Force++;
                P2CharBox.Image = Properties.Resources.P2Keycode_jump;
                P2CharBox.Refresh();
            }
            if (P2Y <= 150)
            {
                jump = true;

            }
            else
            {
                jump = false;
                P2Force = 17;
                P2Y = 160;
            }

            if (P2JumpTimer > 0)
            {
                P2Y -= P2Force + 1;
                P2Force--;

                P2CharBox.Image = Properties.Resources.P2Keycode_jump;
                P2CharBox.Refresh();
                P2JumpTimer--;
            }

            if (wDown == true && P2FrameData == 0 && P2Y >= 150 && jump == false)
            {
                P2JumpTimer = 17;
            }
            if (vDown == true && P2FrameData == 0 && P2Y >= 150 && jump == false)
            {
                P2JumpTimer = 17;
            }
            #endregion

            //put all moves here
            #region lightNeutral
            if (xDown == true && aDown == false && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 18;
                P2Move = "lightNeutral";
            }

            if (P2Move == "lightNeutral" && P2FrameData <= 15 && P2FrameData >= 9)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_light_neutral;
                P2CharBox.Refresh();

                P2HitX = P2X - 80;
                P2HitY = P2Y + 30;
                P2HitWidth = 80;
                P2HitHeight = 40;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 3;
                    P1Stun = 7;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {

                    P1Health -= 2;
                    P1Stun = 7;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 7;
                }
            }
            if (P2Move == "lightNeutral" && P2FrameData < 9)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            if (xDown == true && aDown == true && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 25;
                P2Move = "lightForward";
            }

            if (P2Move == "lightForward" && P2FrameData <= 18 && P2FrameData >= 11)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_forward_light;
                P2CharBox.Refresh();

                P2HitX = P2X - 70;
                P2HitY = P2Y +100;
                P2HitWidth = 70;
                P2HitHeight = 120;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 4;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {
                    P1Health -= 2;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 8;
                }
            }
            if (P2Move == "lightForward" && P2FrameData < 11)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardAerial
            if (xDown == true && aDown == true && P2FrameData == 0 && P2Y < 150)
            {
                P2FrameData = 19;
                P2Move = "ForwardAerial";
            }

            if (P2Move == "ForwardAerial" && P2FrameData <= 16 && P2FrameData >= 11)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_forward_air;
                P2CharBox.Refresh();

                P2HitX = P2X - 70 ;
                P2HitY = P2Y + 250;
                P2HitWidth = 70;
                P2HitHeight = 70;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 5;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {
                    P1Health -= 3;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 8;
                }
            }
            if (P2Move == "ForwardAerial" && P2FrameData < 11)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralAerial
            if (xDown == true && aDown == false && P2FrameData == 0 && P2Y < 150)
            {
                P2FrameData = 20;
                P2Move = "NeutralAerial";
            }

            if (P2Move == "NeutralAerial" && P2FrameData <= 16 && P2FrameData >= 11)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_neutral_air;
                P2CharBox.Refresh();

                P2HitX = P2X - 50;
                P2HitY = P2Y + 100;
                P2HitWidth = 50;
                P2HitHeight = 180;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 3;
                    P1Stun = 7;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {
                    P1Health -= 2;
                    P1Stun = 7;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 7;
                }
            }
            if (P2Move == "NeutralAerial" && P2FrameData < 11)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralHeavy
            if (zDown == true && aDown == false && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 26;
                P2Move = "NeutralHeavy";
            }

            if (P2Move == "NeutralHeavy" && P2FrameData <= 20 && P2FrameData >= 13)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_heavy_neutral;
                P2CharBox.Refresh();

                P2HitX = P2X - 100;
                P2HitY = P2Y + 210;
                P2HitWidth = 100;
                P2HitHeight = 100;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 8;
                    P1Stun = 9;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {
                    P1Health -= 4;
                    P1Stun = 9;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 9;
                }
            }
            if (P2Move == "NeutralHeavy" && P2FrameData < 13)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardHeavy
            if (zDown == true && aDown == true && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 29;
                P2Move = "ForwardHeavy";
            }

            if (P2Move == "ForwardHeavy" && P2FrameData <= 22 && P2FrameData >= 16)
            {
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_heavy_forward;
                P2CharBox.Refresh();

                P2HitX = P2X - 100;
                P2HitY = P2Y + 10;
                P2HitWidth = 100;
                P2HitHeight = 60;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 9;
                    P1Stun = 10;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {
                    P1Health -= 5;
                    P1Stun = 10;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 9;
                }
            }
            if (P2Move == "ForwardHeavy" && P2FrameData < 16)
            {
                P2CharBox.Size = new Size(P2Width, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_passive;
                P2CharBox.Refresh();
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            if (P2FrameData > 0)
            {
                P2FrameData--;
            }
            if (P2Stun > 0)
            {
                P2Stun--;
                P2CharBox.Size = new Size(P2Width + 50, P2Height);
                P2CharBox.Image = Properties.Resources.P2Keycode_hitstun;
                P2CharBox.Refresh();
            }
            if (P2FrameData == 0)
            {
                P2Move = "none";
            }
        }
    }
}
