using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using Throwdown.Properties;
using System.Diagnostics;

namespace Throwdown
{


    public partial class gameScreen : UserControl
    {
        //Creating instance of the brushes and pens that will be used
        SolidBrush healthBrush = new SolidBrush(Color.White);
        Pen linePen = new Pen(Color.Black, 8);

        //creating a stopwatch used for the first countdown
        Stopwatch stopWatch = new Stopwatch();

        #region keyDownVariables
        //boolean variables used for keydown events

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

        //boolean variables used for keypress event
        bool sPress = false;
        bool downArrowPress = false;

        #endregion

        #region GeneralVariables
        //NOTE:  ground is 50 pixels off screen bottom
        //use framedata for both hit stun and input lag?

        //Initializing player one variables
        int P1X, P1Y;
        int P1Width, P1Height;
        int P1HitX, P1HitY;
        int P1HitWidth, P1HitHeight;     
        
        int P1FrameData = 0;
        string P1Move;
        bool P1Blocking = false;
        bool P1Parry;
        int P1WalkCycle;
        int P1Health = 100;
        int P1Stun;

        //Initializing player two variables
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

        //asigning some general variables for rounds and points
        int round = 1;
        int storedRound = 1;
        int pointP1 = 0;
        int pointP2 = 0;

        //assgning variables for jump mechanics
        int P1Force = 0;
        int P2Force = 0;

        int P1JumpTimer = 0;
        int P2JumpTimer = 0;

        //setting the default draw state of each player character
        string P1Drawing = "passive";
        string P2Drawing = "passive";

        //boolean for weather the game is in a paused or unpaused state
        bool paused = false;

        #endregion


        public gameScreen()
        {
            //run initialization for the components on the form
            InitializeComponent();
        }

        private void gameScreen_Load(object sender, EventArgs e)
        {

            //This is technically an array usage, yep, this is it
            ((Form1)this.Parent).Controls.Find("inputCover", true)[0].Visible = true;

            //if player one character is hitbox
            if (Form1.P1Character == "Hitbox")
            {
                //set location and size for the character
                P1X = 50;
                P1Y = 150;
                P1Width = 160;
                P1Height = 300;
                P1WalkCycle = 35;
            }

            //if player one character is keycode
            if (Form1.P1Character == "Keycode")
            {
                //set location and size for the character
                P1X = 50;
                P1Y = 160;
                P1Width = 160;
                P1Height = 300;
                P1WalkCycle = 30;
            }

            //if player one character is void
            if (Form1.P1Character == "Void")
            {
                //set location and size for the character
                P1X = 50;
                P1Y = 150;
                P1Width = 160;
                P1Height = 300;
                P1WalkCycle = 45;
            }

            //if player two character is hitbox
            if (Form1.P2Character == "Hitbox")
            {
                //set location and size for the character
                P2X = 490;
                P2Y = 150;
                P2Width = 160;
                P2Height = 300;
                P2WalkCycle = 35;

            }

            //if player two character is keycode
            if (Form1.P2Character == "Keycode")
            {
                //set location and size for the character
                P2X = 490;
                P2Y = 160;
                P2Width = 160;
                P2Height = 300;
                P2WalkCycle = 30;
            }

            //if player two character is void
            if (Form1.P2Character == "Void")
            {
                //set location and size for the character
                P2X = 490;
                P2Y = 150;
                P2Width = 160;
                P2Height = 300;
                P2WalkCycle = 45;
                
            }

            //focus the input box to recieve player inputs
            this.inputBox.Focus();
        }

        //if continue button in pause menu is pressed
        private void continueButton_Click(object sender, EventArgs e)
        {
            //unpause
            paused = false;
            gametimer.Start();
        }

        //if the quit button is pressed or if the game has ended
        private void quitButton_Click(object sender, EventArgs e)
        {
            //unpause and go to main screen
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
            //if there is a user input set that boolean to true
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
            //on release of user input revert the boolean to false
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

        //when a game tick occurs
        private void gametimer_Tick(object sender, EventArgs e)
        {
            //start the stopwatch if it is not already started
            stopWatch.Start();

            //hide the countdown timer lable
            countWin.Hide();

            //if a players health reaches or drops below 0
            if (P1Health <=0 || P2Health <= 0)
            {
                //add one to round number
                round++;   

                //if the dead player is player 2
                if (P2Health <= 0)
                {
                    //player one recieves a point
                    pointP1++;

                    //reset both players health to the max
                    P2Health = 100;
                    P1Health = 100;
                }
                //else if the dead player is not player 2
                else
                {
                    //give player two one point
                    pointP2++;

                    //reset both players health to the max
                    P2Health = 100;
                    P1Health = 100;
                }

                //if player one has one point
                if (pointP1 == 1)
                {
                    //make the point be filled in
                    p1Point.Image = Properties.Resources.PointFull;
                }

                //if player two has one point
                if (pointP2 == 1)
                {
                    //fill in the point
                    p2Point.Image = Properties.Resources.PointFull;
                }

                //else if player 1 OR player 2 has two points
                else if (pointP1 == 2 || pointP2 == 2)
                {
                    //fill in the second point
                    winPoint.Image = Properties.Resources.PointFull;
                }

                //if 3 or more rounds have begun
                if (round >= 3)
                {
                    //if player one has more points than player two and has atleast two points
                    if (pointP1 > pointP2 && pointP1 >= 2)
                    {
                        //set text to player one wins
                        countWin.Text = "P1 Wins!!";
                    }

                    //if player two has more points than player one and has atleast two points
                    else if (pointP2 > pointP1 && pointP2 >= 2)
                    {
                        //set text to player two wins
                        countWin.Text = "P2 Wins!!";
                    }

                    //set round number text to "Game"
                    RoundLabel.Text = $"Game";

                    //Show countWin lable
                    countWin.Show();

                    //refresh the screen
                    Refresh();

                    //wait 5 seconds
                    Thread.Sleep(5000);

                    //run the quit function
                    quitButton_Click(sender, e);
                }

                //else if it is not >= round 3 display the round number
                else
                {
                    RoundLabel.Text = $"Round {round}";
                }
                

            }


            //if it is that start of the game or it is a new round
            if ((stopWatch.ElapsedMilliseconds < 1000 && round == 1 && P1Health == 100 && P2Health == 100) || round != storedRound)
            {
                //run the countdown
                countdown();
            }

            //if player 1 is hitbox run hitbox's for player one function
            if (Form1.P1Character == "Hitbox")
            {
                P1HitboxControls();
            }

            //if player 1 is keycode run keycode's for player one function
            if (Form1.P1Character == "Keycode")
            {
                P1KeycodeControls();
            }

            //if player 1 is void run void's for player one function
            if (Form1.P1Character == "Void")
            {
                P1VoidControls();
            }

            //if player 2 is hitbox run hitbox's for player two function
            if (Form1.P2Character == "Hitbox")
            {
                P2HitboxControls();
            }

            //if player 2 is keycode run keycode's for player two function
            if (Form1.P2Character == "Keycode")
            {
                P2KeycodeControls();
            }

            //if player 2 is void run void's for player two function
            if (Form1.P2Character == "Void")
            {
                P2VoidControls();
            }
           
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

            //if paused boolean has been set to true
            if (paused == true)
            {
                //pause the game and show pause menu
                escapeDown = false;
                continueButton.Visible = true;
                quitButton.Visible = true;
                pauseScreen.Visible = true;
                Task.Delay(100);
                Refresh();
                gametimer.Stop();
                continueButton.Focus();
            }

            //if the pause boolean has been set to false
            if (paused == false)
            {
                //hide the pause menu
                pauseScreen.Visible = false;
                continueButton.Visible = false;
                quitButton.Visible = false;
                inputBox.Focus();

                //if escape is pushed set paused to true
                if (escapeDown == true)
                {
                    paused = true;
                }
            }
            #endregion

        }

        //countdown function
        private void countdown()
        {

            //set the storedRound variable to the round number
            storedRound = round;

            //reset players to starting position
            P1X = 50;
            P2X = 490;

            //pause game and 3, 2, 1 , go text 
            gametimer.Stop();
            countWin.Show();
            countWin.Text = "3";
            Thread.Sleep(500);
            countWin.Refresh();
            countWin.Text = "2";
            Thread.Sleep(500);
            countWin.Refresh();
            countWin.Text = "1";
            Thread.Sleep(500);
            countWin.Refresh();
            countWin.Text = "GO!";
            Thread.Sleep(100);
            countWin.Refresh();

            //unpause game
            gametimer.Start();
        }

        //graphics & drawing & paint function
        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            //create healthbar
            e.Graphics.FillRectangle(healthBrush, 25, 25, P1Health * 2, 30);
            e.Graphics.FillRectangle(healthBrush, 635 - P2Health * 2, 25, P2Health * 2, 30);

            //create health bar outline
            e.Graphics.DrawRectangle(linePen, 25, 25, 200, 30);
            e.Graphics.DrawRectangle(linePen, 435, 25, 200, 30);

            //if p2 character is void draw image for character depending on state
            if (Form1.P2Character == "Void")
            {
                switch (P2Drawing)
                {
                   
                    case "walk":
                        e.Graphics.DrawImage(Properties.Resources.P2Void_walk, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "block":
                        e.Graphics.DrawImage(Properties.Resources.P2Void_block, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "parry":
                        e.Graphics.DrawImage(Properties.Resources.P2Void_parry, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "jump":
                        e.Graphics.DrawImage(Properties.Resources.P2void_jump, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "lightNeutral":
                        e.Graphics.DrawImage(Properties.Resources.P2void_neutral_light, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "lightForward":
                        e.Graphics.DrawImage(Properties.Resources.P2void_forward_light, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "neutralAerial":
                        e.Graphics.DrawImage(Properties.Resources.P2void_neutral_air, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "forwardAerial":
                        e.Graphics.DrawImage(Properties.Resources.P2void_forward_air, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "neutralHeavy":
                        e.Graphics.DrawImage(Properties.Resources.P2Void_neutral_heavy, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "forwardHeavy":
                        e.Graphics.DrawImage(Properties.Resources.P2Void_forward_heavy, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "hitstun":
                        e.Graphics.DrawImage(Properties.Resources.P2Void_hitstun, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "passive":
                        e.Graphics.DrawImage(Properties.Resources.P2Void_passive, P2X, P2Y, P2Width, P2Height);
                        break;
                }
            }

            //if p1 character is void draw image for character depending on state
            if (Form1.P1Character == "Void")
            {
                switch (P1Drawing)
                {

                    case "walk":
                        e.Graphics.DrawImage(Properties.Resources.Void_walk, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "block":
                        e.Graphics.DrawImage(Properties.Resources.Void_block, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "parry":
                        e.Graphics.DrawImage(Properties.Resources.Void_parry, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "jump":
                        e.Graphics.DrawImage(Properties.Resources.void_jump, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "lightNeutral":
                        e.Graphics.DrawImage(Properties.Resources.void_neutral_light, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "lightForward":
                        e.Graphics.DrawImage(Properties.Resources.void_forward_light, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "neutralAerial":
                        e.Graphics.DrawImage(Properties.Resources.void_neutral_air, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "forwardAerial":
                        e.Graphics.DrawImage(Properties.Resources.void_forward_air, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "neutralHeavy":
                        e.Graphics.DrawImage(Properties.Resources.Void_neutral_heavy, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "forwardHeavy":
                        e.Graphics.DrawImage(Properties.Resources.Void_forward_heavy, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "hitstun":
                        e.Graphics.DrawImage(Properties.Resources.Void_hitstun, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "passive":
                        e.Graphics.DrawImage(Properties.Resources.Void_passive, P1X, P1Y, P1Width, P1Height);
                        break;
                }
            }


            //if p2 character is hitbox draw image for character depending on state
            if (Form1.P2Character == "Hitbox")
            {
                switch (P2Drawing)
                {

                    case "walk":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_walk, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "block":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_block, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "parry":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_parry, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "jump":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_jump, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "lightNeutral":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_light_neutral, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "lightForward":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_light_side, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "neutralAerial":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_neutral_aerial, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "forwardAerial":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_forward_aerial, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "neutralHeavy":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_Neutral_Heavy, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "forwardHeavy":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_forward_heavy, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "hitstun":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_hitstun, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "passive":
                        e.Graphics.DrawImage(Properties.Resources.P2hitbox_passive, P2X, P2Y, P2Width, P2Height);
                        break;
                }
            }

            //if p1 character is hitbox draw image for character depending on state
            if (Form1.P1Character == "Hitbox")
            {
                switch (P1Drawing)
                {

                    case "walk":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_walk, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "block":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_block, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "parry":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_parry, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "jump":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_jump, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "lightNeutral":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_light_neutral, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "lightForward":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_light_side, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "neutralAerial":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_neutral_aerial, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "forwardAerial":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_forward_aerial, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "neutralHeavy":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_Neutral_Heavy, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "forwardHeavy":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_forward_heavy, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "hitstun":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_hitstun, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "passive":
                        e.Graphics.DrawImage(Properties.Resources.hitbox_passive, P1X, P1Y, P1Width, P1Height);
                        break;
                }
            }


            //if p2 character is keycode draw image for character depending on state
            if (Form1.P2Character == "Keycode")
            {
                switch (P2Drawing)
                {

                    case "walk":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_walk, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "block":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_block, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "parry":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_Parry, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "jump":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_jump, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "lightNeutral":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_light_neutral, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "lightForward":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_forward_light, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "neutralAerial":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_neutral_air, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "forwardAerial":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_forward_air, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "neutralHeavy":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_heavy_neutral, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "forwardHeavy":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_heavy_forward, P2X, P2Y, P2Width + 50, P2Height);
                        break;
                    case "hitstun":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_hitstun, P2X, P2Y, P2Width, P2Height);
                        break;
                    case "passive":
                        e.Graphics.DrawImage(Properties.Resources.P2Keycode_passive, P2X, P2Y, P2Width, P2Height);
                        break;
                }
            }

            //if p1 character is keycode draw image for character depending on state
            if (Form1.P1Character == "Keycode")
            {
                switch (P1Drawing)
                {

                    case "walk":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_walk, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "block":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_block, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "parry":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_Parry, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "jump":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_jump, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "lightNeutral":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_light_neutral, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "lightForward":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_forward_light, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "neutralAerial":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_neutral_air, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "forwardAerial":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_forward_air, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "neutralHeavy":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_heavy_neutral, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "forwardHeavy":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_heavy_forward, P1X, P1Y, P1Width + 50, P1Height);
                        break;
                    case "hitstun":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_hitstun, P1X, P1Y, P1Width, P1Height);
                        break;
                    case "passive":
                        e.Graphics.DrawImage(Properties.Resources.Keycode_passive, P1X, P1Y, P1Width, P1Height);
                        break;
                }
            }
        }

        //movement and attacks for hitbox player one
        public void P1HitboxControls()
        {
            if (P1Stun > 0)
            {
                P1FrameData = P1Stun;
            }

            //Draw the collision collider for the player
            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //if in blocking state 
            if (downArrowDown == true && P1FrameData == 0)
            {
                P1Blocking = true;
                P1Drawing = "block";
                P1FrameData = 1;
            }
            //if in parrying
            else if (downArrowPress == true && P1FrameData < 2)
            {
                P1Blocking = false;
                P1Parry = true;
                P1Drawing = "parry";
                P1FrameData = 20;
            }
            else
            {
                P1Parry = false;
                P1Drawing = "passive";
            }
            #endregion

            #region walking
            //if in walking forward state
            if (rArrowDown == true && P1X < 750 && P1FrameData == 0)
            {
                //move forward 7 pixels and play walking animation
                P1X += 7;
                if (P1WalkCycle > 17)
                {
                    P1Drawing = "walk";
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 35;
                }
                else
                {
                    P1Drawing = "passive";
                    P1WalkCycle--;
                }
            }
            //if in walking backwards state
            if (lArrowDown == true && P1X > 0 && P1FrameData == 0)
            {
                //move backwards 6 pixels and play walking animation
                P1X -= 6;
                if (P1WalkCycle > 17)
                {
                    P1Drawing = "walk";
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 35;
                }
                else
                {
                    P1Drawing = "passive";
                    P1WalkCycle--;
                }
            }
            #endregion

            #region Jump
            bool jump;
            //if jumping go up until a cerain high with acceleration 
            //set jump state to true to avoid double jumps 
            //go back down until on ground then set ju,p state to false 
            if (P1JumpTimer == 0 && P1Y <= 140)
            {
                jump = true;
                P1Y += 1 + P1Force;
                P1Force++;
                P1Drawing = "jump";
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

                P1Drawing = "jump";
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

            //Attack moves
            #region lightNeutral
            //if player preforms a light attack set them to lightneutral state
            if (mDown == true && rArrowDown == false && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 20;
                P1Move = "lightNeutral";
            }
            //Extend hitbox to be around the light attack
            if (P1Move == "lightNeutral" && P1FrameData <= 16 && P1FrameData >= 8)
            {
                P1Drawing = "lightNeutral";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 25;
                P1HitWidth = 80;
                P1HitHeight = 40;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                //if there is a collsion do damage and stun the opposing player
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
            //if stunned dont do attack
            if (P1Move == "lightNeutral" && P1FrameData < 8)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            //if a forward light attack is preformed set state to forward light attack
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 26;
                P1Move = "lightForward";
            }

            ////Extend hitbox to be around the attack
            if (P1Move == "lightForward" && P1FrameData <= 18 && P1FrameData >= 11)
            {
                P1Drawing = "lightForward";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 140;
                P1HitWidth = 70;
                P1HitHeight = 120;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                //if there is a collsion do damage and stun the opposing player
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
            //if stunned dont do attack
            if (P1Move == "lightForward" && P1FrameData < 11)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardAerial
            //if player preforms a aerial attack in the forward direction set state to ForwardAerial
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 19;
                P1Move = "ForwardAerial";
            }

            //Adjust hitbox to fit the attack
            if (P1Move == "ForwardAerial" && P1FrameData <= 16 && P1FrameData >= 11)
            {
                P1Drawing = "forwardAerial";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 250;
                P1HitWidth = 100;
                P1HitHeight = 60;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                //if there is a collsion do damage and stun the other player
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
            //if stunned dont do attack
            if (P1Move == "ForwardAerial" && P1FrameData < 11)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralAerial
            //if player inputs a neutral aerial attack set state to NeutralAerial
            if (mDown == true && rArrowDown == false && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 23;
                P1Move = "NeutralAerial";
            }

            //Adjust hitbox to fit the attack
            if (P1Move == "NeutralAerial" && P1FrameData <= 17 && P1FrameData >= 13)
            {
                P1Drawing = "neutralAerial";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 260;
                P1HitWidth = 100;
                P1HitHeight = 80;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                //if there is a collision do damage and stun the opposing player
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
            //if player is stunned they do not preform the attack
            if (P1Move == "NeutralAerial" && P1FrameData < 13)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralHeavy
            //if a neutral heavy attack is preformed set state to NeutralHeavy
            if (spaceDown == true && rArrowDown == false && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 27;
                P1Move = "NeutralHeavy";
            }

            //Adjust hitbox to fit the attack
            if (P1Move == "NeutralHeavy" && P1FrameData <= 22 && P1FrameData >= 16)
            {
                P1Drawing = "neutralHeavy";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 230;
                P1HitWidth = 100;
                P1HitHeight = 80;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                //if there is a collision do damage and stun
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

            //if player is stunned do not preform the attack
            if (P1Move == "NeutralHeavy" && P1FrameData < 16)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardHeavy
            //if player preforms a forward heavy attack set their state to ForwardHeavy
            if (spaceDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 33;
                P1Move = "ForwardHeavy";
            }

            //Adjust hitbox to fit the attack
            if (P1Move == "ForwardHeavy" && P1FrameData <= 27 && P1FrameData >= 19)
            {
                P1Drawing = "forwardHeavy";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y - 10;
                P1HitWidth = 70;
                P1HitHeight = 150;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                //if there is a collision do damage and stun the oposing player
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

            //if the player is stunned do not preform the attack
            if (P1Move == "ForwardHeavy" && P1FrameData < 19)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            //if player is stunned slightly decrease stun until no stun
            if (P1FrameData > 0)
            {
                P1FrameData--;
            }
            if (P1Stun > 0)
            {
                P1Stun--;
                P1Drawing = "hitstun";
            }
            if (P1FrameData == 0)
            {
                P1Move = "none";
            }
        }
        //movement and attacks for hitbox player two
        public void P2HitboxControls()
        {
            //Refer to P1Hitbox for detailed comments
            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (sDown == true && P2FrameData == 0)
            {
                P2Blocking = true;
                P2Drawing = "block";
                P2FrameData = 1;
            }
            else if (sPress == true && P2FrameData < 2)
            {
                P2Blocking = false;
                P2Parry = true;
                P2Drawing = "parry";
                P2FrameData = 20;
            }
            else
            {
                P2Parry = false;
                P2Drawing = "passive";
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
                    P2Drawing = "walk";

                    P2WalkCycle--;
                }
                else
                {
                    P2Drawing = "passive";

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
                    P2Drawing = "walk";

                    P2WalkCycle--;
                }

                else
                {
                    P2Drawing = "passive";

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
                P2Drawing = "jump";
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

                P2Drawing = "jump";

                P2JumpTimer--;
            }

            if (wDown == true && P2FrameData == 0 && P2Y >= 140 && jump == false)
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
                P2Drawing = "lightNeutral";

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
                P2Drawing = "passive";

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
                P2Drawing = "lightForward";

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
                P2Drawing = "passive";

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
                P2Drawing = "forwardAerial";

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
                P2Drawing = "passive";

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
                P2Drawing = "neutralAerial";

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
                P2Drawing = "passive";

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
                P2Drawing = "neutralHeavy";

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
                P2Drawing = "passive";

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
                P2Drawing = "forwardHeavy";

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
                P2Drawing = "passive";

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
                P2Drawing = "hitstun";
            }
            if (P2FrameData == 0)
            {
                P2Move = "none";
            }
        }

        //movement and attacks for keycode player one
        public void P1KeycodeControls()
        {
            //Refer to P1Hitbox for detailed comments
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
                P1Drawing = "block";
                P1FrameData = 1;
            }
            else if (downArrowPress == true && P1FrameData < 2)
            {
                P1Blocking = false;
                P1Parry = true;
                P1Drawing = "parry";
                P1FrameData = 20;
            }
            else
            {
                P1Parry = false;
                P1Drawing = "passive";
            }
            #endregion

            #region walking
            //walking forward
            if (rArrowDown == true && P1X < 750 && P1FrameData == 0)
            {
                P1X += 8;
                if (P1WalkCycle > 15)
                {
                    P1Drawing = "walk";
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 30;
                }
                else
                {
                    P1Drawing = "passive";
                    P1WalkCycle--;
                }
            }
            //walking backwards
            if (lArrowDown == true && P1X > 0 && P1FrameData == 0)
            {
                P1X -= 6;
                if (P1WalkCycle > 15)
                {
                    P1Drawing = "walk";
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 30;
                }
                else
                {
                    P1Drawing = "passive";
                    P1WalkCycle--;
                }
            }
            #endregion

            #region Jump
            bool jump;

            if (P1JumpTimer == 0 && P1Y <= 150)
            {
                jump = true;
                P1Drawing = "jump";
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

                P1Drawing = "jump";
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
                P1Drawing = "lightNeutral";

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
                P1Drawing = "passive";
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
                P1Drawing = "lightForward";

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
                P1Drawing = "passive";
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
                P1Drawing = "forwardAerial";

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
                P1Drawing = "passive";
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
                P1Drawing = "neutralAerial";

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
                    P2Stun = 7;
                }
            }
            if (P1Move == "NeutralAerial" && P1FrameData < 11)
            {
                P1Drawing = "passive";
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
                P1Drawing = "neutralHeavy";

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
                P1Drawing = "passive";
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
                P1Drawing = "forwardHeavy";

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
                P1Drawing = "passive";
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
                P1Drawing = "hitstun";
            }
            if (P1FrameData == 0)
            {
                P1Move = "none";
            }
        }
        //movement and attacks for keycode player two
        public void P2KeycodeControls()
        {
            //Refer to P1Hitbox for detailed comments
            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (sDown == true && P2FrameData == 0)
            {
                P2Blocking = true;
                P2Drawing = "block";
                P2FrameData = 1;
            }
            else if (sPress == true && P2FrameData < 2)
            {
                P2Blocking = false;
                P2Parry = true;
                P2Drawing = "parry";
                P2FrameData = 20;
            }
            else
            {
                P2Parry = false;
                P2Drawing = "passive";
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
                    P2Drawing = "walk";
                    P2WalkCycle--;
                }
                else
                {
                    P2Drawing = "passive";
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
                    P2Drawing = "walk";
                    P2WalkCycle--;
                }

                else
                {
                    P2Drawing = "passive";
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
                P2Drawing = "jump";
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

                P2Drawing = "jump";
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
                P2Drawing = "lightNeutral";

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
                P2Drawing = "passive";
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
                P2Drawing = "lightForward";

                P2HitX = P2X - 70;
                P2HitY = P2Y + 100;
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
                P2Drawing = "passive";
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
                P2Drawing = "forwardAerial";

                P2HitX = P2X - 70;
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
                P2Drawing = "passive";
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
                P2Drawing = "neutralAerial";

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
                P2Drawing = "passive";
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
                P2Drawing = "neutralHeavy";

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
                P2Drawing = "passive";
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
                P2Drawing = "forwardHeavy";

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
                P2Drawing = "passive";
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
                P2Drawing = "hitstun";
            }
            if (P2FrameData == 0)
            {
                P2Move = "none";
            }
        }

        //movement and attacks for void player one
        public void P1VoidControls()
        {
            //Refer to P1Hitbox for detailed comments
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
                P1Drawing = "block";
                P1FrameData = 1;
            }
            else if (downArrowPress == true && P1FrameData < 2)
            {
                P1Blocking = false;
                P1Parry = true;
                P1Drawing = "parry";
                P1FrameData = 20;
            }
            else
            {
                P1Parry = false;
                P1Drawing = "passive";
            }
            #endregion

            #region walking
            //walking forward
            if (rArrowDown == true && P1X < 750 && P1FrameData == 0)
            {
                P1X += 7;
                if (P1WalkCycle > 22)
                {
                    P1Drawing = "walk";
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 45;
                }
                else
                {
                    P1Drawing = "passive";
                    P1WalkCycle--;
                }
            }
            //walking backwards
            if (lArrowDown == true && P1X > 0 && P1FrameData == 0)
            {
                P1X -= 6;
                if (P1WalkCycle > 22)
                {
                    P1Drawing = "walk";
                    P1WalkCycle--;
                }
                else if (P1WalkCycle == 0)
                {
                    P1WalkCycle = 45;
                }
                else
                {
                    P1Drawing = "passive";
                    P1WalkCycle--;
                }
            }
            #endregion

            #region Jump
            bool jump;

            if (P1JumpTimer == 0 && P1Y <= 140)
            {
                jump = true;
                P1Drawing = "jump";
                P1Y += 1 + P1Force;
                P1Force++;

            }
            if (P1Y <= 140)
            {
                jump = true;

            }
            else
            {
                jump = false;
                P1Force = 24;
                P1Y = 150;
            }

            if (P1JumpTimer > 0)
            {
                P1Y -= P1Force + 1;
                P1Force -= 2;

                P1Drawing = "jump";
                P1JumpTimer--;
            }

            if (upArrowDown == true && P1FrameData == 0 && P1Y >= 150 && jump == false)
            {
                P1JumpTimer = 12;
            }
            if (nDown == true && P1FrameData == 0 && P1Y >= 150 && jump == false)
            {
                P1JumpTimer = 12;
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
                P1Drawing = "lightNeutral";

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
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 27;
                P1Move = "lightForward";
            }

            if (P1Move == "lightForward" && P1FrameData <= 19 && P1FrameData >= 13)
            {
                P1Drawing = "lightForward";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 100;
                P1HitWidth = 90;
                P1HitHeight = 90;
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
            if (P1Move == "lightForward" && P1FrameData < 13)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardAerial
            if (mDown == true && rArrowDown == true && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 21;
                P1Move = "ForwardAerial";
            }

            if (P1Move == "ForwardAerial" && P1FrameData <= 16 && P1FrameData >= 11)
            {
                P1Drawing = "forwardAerial";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 50;
                P1HitWidth = 50;
                P1HitHeight = 200;
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
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralAerial
            if (mDown == true && rArrowDown == false && P1FrameData == 0 && P1Y < 150)
            {
                P1FrameData = 23;
                P1Move = "NeutralAerial";
            }

            if (P1Move == "NeutralAerial" && P1FrameData <= 17 && P1FrameData >= 11)
            {
                P1Drawing = "neutralAerial";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 175;
                P1HitWidth = 75;
                P1HitHeight = 100;
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
            if (P1Move == "NeutralAerial" && P1FrameData < 11)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralHeavy
            if (spaceDown == true && rArrowDown == false && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 24;
                P1Move = "NeutralHeavy";
            }

            if (P1Move == "NeutralHeavy" && P1FrameData <= 20 && P1FrameData >= 14)
            {
                P1Drawing = "neutralHeavy";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 20;
                P1HitWidth = 110;
                P1HitHeight = 40;
                Rectangle P1Hitbox = new Rectangle(P1HitX, P1HitY, P1HitWidth, P1HitHeight);

                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == false && P2Stun == 0)
                {
                    P2Health -= 7;
                    P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Blocking == true && P2Stun == 0)
                {
                    P2Health -= 4;
                    P2Stun = 8;
                }
                if (P1Hitbox.IntersectsWith(P2Hurtbox) && P2Parry == true && P2Stun == 0)
                {
                    P2Health -= 0;
                    P2Stun = 8;
                }
            }
            if (P1Move == "NeutralHeavy" && P1FrameData < 14)
            {
                P1Drawing = "passive";
                Rectangle P1Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardHeavy
            if (spaceDown == true && rArrowDown == true && P1FrameData == 0 && P1Y >= 150)
            {
                P1FrameData = 31;
                P1Move = "ForwardHeavy";
            }
            if (P1Move == "ForwardHeavy" && P1FrameData <= 22 && P1FrameData >= 15)
            {
                P1X += 12;
                P1Drawing = "forwardHeavy";

                P1HitX = P1X + P1Width;
                P1HitY = P1Y + 40;
                P1HitWidth = 60;
                P1HitHeight = 75;
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
            if (P1Move == "ForwardHeavy" && P1FrameData < 15)
            {
                P1Drawing = "passive";
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
                P1Drawing = "hitstun";
            }
                if (P1FrameData == 0)
            {
                P1Move = "none";
            }
        }
        //movement and attacks for void player two
        public void P2VoidControls()
        {
            //Refer to P1Hitbox for detailed comments
            Rectangle P2Hurtbox = new Rectangle(P2X, P2Y, P2Width, P2Height);
            Rectangle P1Hurtbox = new Rectangle(P1X, P1Y, P1Width, P1Height);

            #region blocking
            //blocking
            if (sDown == true && P2FrameData == 0)
            {
                P2Blocking = true;
                P2Drawing = "block";
                P2FrameData = 1;
            }
            else if (sPress == true && P2FrameData < 2)
            {
                P2Blocking = false;
                P2Parry = true;
                P2Drawing = "parry";
                P2FrameData = 20;
            }
            else
            {
                P2Parry = false;
                P2Drawing = "passive";
            }
            #endregion

            #region walking
            //walking forwards
            if (aDown == true && P2X > 0 && P2FrameData == 0)
            {
                P2X -= 7;
                if (P2WalkCycle == 0)
                {
                    P2WalkCycle = 45;
                }
                else if (P2WalkCycle > 22)
                {
                    P2Drawing = "walk";

                    P2WalkCycle--;
                }
                else
                {
                    P2Drawing = "passive";

                    P2WalkCycle--;
                }
            }
            //walking backwards
            if (dDown == true && P2X < 750 && P2FrameData == 0)
            {
                P2X += 6;
                if (P2WalkCycle == 0)
                {
                    P2WalkCycle = 45;
                }
                else if (P2WalkCycle > 22)
                {
                    P2Drawing = "walk";

                    P2WalkCycle--;
                }

                else
                {
                    P2Drawing = "passive";

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
                P2Drawing = "jump";
            }
            if (P2Y <= 140)
            {
                jump = true;

            }
            else
            {
                jump = false;
                P2Force = 24;
                P2Y = 150;
            }

            if (P2JumpTimer > 0)
            {
                P2Y -= P2Force + 1;
                P2Force-=2;
                P2Drawing = "jump";
                P2JumpTimer--;
            }

            if (wDown == true && P2FrameData == 0 && P2Y >= 140 && jump == false)
            {
                P2JumpTimer = 12;
            }
            if (vDown == true && P2FrameData == 0 && P2Y >= 140 && jump == false)
            {
                P2JumpTimer = 12;
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
                P2Drawing = "lightNeutral";

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
                P2Drawing = "passive";

                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region Forwardlight
            if (xDown == true && aDown == true && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 27;
                P2Move = "lightForward";
            }

            if (P2Move == "lightForward" && P2FrameData <= 19 && P2FrameData >= 13)
            {
                P2Drawing = "lightForward";

                P2HitX = P2X - 90;
                P2HitY = P2Y + 100;
                P2HitWidth = 90;
                P2HitHeight = 90;
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
            if (P2Move == "lightForward" && P2FrameData < 13)
            {
                P2Drawing = "passive";
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardAerial
            if (xDown == true && aDown == true && P2FrameData == 0 && P2Y < 150)
            {
                P2FrameData = 21;
                P2Move = "ForwardAerial";
            }

            if (P2Move == "ForwardAerial" && P2FrameData <= 16 && P2FrameData >= 11)
            {
                P2Drawing = "forwardAerial";

                P2HitX = P2X - 50;
                P2HitY = P2Y + 50;
                P2HitWidth = 50;
                P2HitHeight = 200;
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
                P2Drawing = "passive";
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralAerial
            if (xDown == true && aDown == false && P2FrameData == 0 && P2Y < 150)
            {
                P2FrameData = 23;
                P2Move = "NeutralAerial";
            }

            if (P2Move == "NeutralAerial" && P2FrameData <= 17 && P2FrameData >= 11)
            {
                P1Drawing = "neutralAerial";

                P2HitX = P2X - 75;
                P2HitY = P2Y + 175;
                P2HitWidth = 75;
                P2HitHeight = 100;
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
            if (P2Move == "NeutralAerial" && P2FrameData < 11)
            {
                P1Drawing = "passive";
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region NeutralHeavy
            if (zDown == true && aDown == false && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 24;
                P2Move = "NeutralHeavy";
            }

            if (P2Move == "NeutralHeavy" && P2FrameData <= 20 && P2FrameData >= 14)
            {
                P2Drawing = "neutralHeavy";

                P2HitX = P2X - 110;
                P2HitY = P2Y + 20;
                P2HitWidth = 110;
                P2HitHeight = 40;
                Rectangle P2Hitbox = new Rectangle(P2HitX, P2HitY, P2HitWidth, P2HitHeight);

                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == false && P1Stun == 0)
                {
                    P1Health -= 7;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Blocking == true && P1Stun == 0)
                {
                    P1Health -= 4;
                    P1Stun = 8;
                }
                if (P2Hitbox.IntersectsWith(P1Hurtbox) && P1Parry == true && P1Stun == 0)
                {
                    P1Health -= 0;
                    P1Stun = 8;
                }
            }
            if (P2Move == "NeutralHeavy" && P2FrameData < 14)
            {
                P2Drawing = "passive";
                Rectangle P2Hitbox = new Rectangle(0, 500, 1, 1);
            }
            #endregion

            #region ForwardHeavy
            if (zDown == true && aDown == true && P2FrameData == 0 && P2Y >= 150)
            {
                P2FrameData = 31;
                P2Move = "ForwardHeavy";
            }

            if (P2Move == "ForwardHeavy" && P2FrameData <= 22 && P2FrameData >= 15)
            {
                P2X -= 12;
                P2Drawing = "forwardHeavy";

                P2HitX = P2X - 60;
                P2HitY = P2Y + 40;
                P2HitWidth = 60;
                P2HitHeight = 75;
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
            if (P2Move == "ForwardHeavy" && P2FrameData < 15)
            {
                P2Drawing = "passive";
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
                P2Drawing = "hitstun";
            }
            if (P2FrameData == 0)
            {
                P2Move = "none";
            }
        }
    }
}
