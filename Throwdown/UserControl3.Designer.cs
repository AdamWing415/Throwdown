namespace Throwdown
{
    partial class gameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.inputBox = new System.Windows.Forms.TextBox();
            this.pauseScreen = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.healthBackdrop = new System.Windows.Forms.Label();
            this.P1Label = new System.Windows.Forms.Label();
            this.P2label = new System.Windows.Forms.Label();
            this.RoundLabel = new System.Windows.Forms.Label();
            this.p1Point = new System.Windows.Forms.PictureBox();
            this.p2Point = new System.Windows.Forms.PictureBox();
            this.winPoint = new System.Windows.Forms.PictureBox();
            this.countWin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p1Point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 20;
            this.gametimer.Tick += new System.EventHandler(this.gametimer_Tick);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(887, 475);
            this.inputBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(9, 22);
            this.inputBox.TabIndex = 1;
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyDown);
            this.inputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyUp);
            // 
            // pauseScreen
            // 
            this.pauseScreen.BackColor = System.Drawing.Color.DarkBlue;
            this.pauseScreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pauseScreen.Font = new System.Drawing.Font("MV Boli", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseScreen.ForeColor = System.Drawing.Color.Goldenrod;
            this.pauseScreen.Location = new System.Drawing.Point(250, 100);
            this.pauseScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pauseScreen.Name = "pauseScreen";
            this.pauseScreen.Size = new System.Drawing.Size(375, 236);
            this.pauseScreen.TabIndex = 4;
            this.pauseScreen.Text = "PAUSED...";
            this.pauseScreen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pauseScreen.Visible = false;
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.DarkBlue;
            this.continueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.ForeColor = System.Drawing.Color.White;
            this.continueButton.Location = new System.Drawing.Point(344, 162);
            this.continueButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(189, 57);
            this.continueButton.TabIndex = 5;
            this.continueButton.TabStop = false;
            this.continueButton.Text = "CONTINUE?";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Visible = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.DarkBlue;
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.White;
            this.quitButton.Location = new System.Drawing.Point(344, 242);
            this.quitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(189, 57);
            this.quitButton.TabIndex = 6;
            this.quitButton.TabStop = false;
            this.quitButton.Text = "QUIT?";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // healthBackdrop
            // 
            this.healthBackdrop.BackColor = System.Drawing.Color.Transparent;
            this.healthBackdrop.Location = new System.Drawing.Point(0, 0);
            this.healthBackdrop.Name = "healthBackdrop";
            this.healthBackdrop.Size = new System.Drawing.Size(907, 500);
            this.healthBackdrop.TabIndex = 8;
            // 
            // P1Label
            // 
            this.P1Label.BackColor = System.Drawing.Color.Transparent;
            this.P1Label.Font = new System.Drawing.Font("PMingLiU-ExtB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P1Label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.P1Label.Location = new System.Drawing.Point(5, 60);
            this.P1Label.Name = "P1Label";
            this.P1Label.Size = new System.Drawing.Size(167, 55);
            this.P1Label.TabIndex = 9;
            this.P1Label.Text = "Player 1";
            this.P1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P2label
            // 
            this.P2label.BackColor = System.Drawing.Color.Transparent;
            this.P2label.Font = new System.Drawing.Font("PMingLiU-ExtB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P2label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.P2label.Location = new System.Drawing.Point(731, 60);
            this.P2label.Name = "P2label";
            this.P2label.Size = new System.Drawing.Size(165, 55);
            this.P2label.TabIndex = 10;
            this.P2label.Text = "Player 2";
            this.P2label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoundLabel
            // 
            this.RoundLabel.BackColor = System.Drawing.Color.Transparent;
            this.RoundLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoundLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RoundLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RoundLabel.Location = new System.Drawing.Point(349, 10);
            this.RoundLabel.Name = "RoundLabel";
            this.RoundLabel.Size = new System.Drawing.Size(200, 55);
            this.RoundLabel.TabIndex = 11;
            this.RoundLabel.Text = "Round 1";
            this.RoundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1Point
            // 
            this.p1Point.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p1Point.Image = global::Throwdown.Properties.Resources.PointEmpty;
            this.p1Point.Location = new System.Drawing.Point(385, 59);
            this.p1Point.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.p1Point.Name = "p1Point";
            this.p1Point.Size = new System.Drawing.Size(40, 37);
            this.p1Point.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1Point.TabIndex = 12;
            this.p1Point.TabStop = false;
            // 
            // p2Point
            // 
            this.p2Point.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p2Point.Image = global::Throwdown.Properties.Resources.PointEmpty;
            this.p2Point.Location = new System.Drawing.Point(471, 59);
            this.p2Point.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.p2Point.Name = "p2Point";
            this.p2Point.Size = new System.Drawing.Size(40, 37);
            this.p2Point.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2Point.TabIndex = 13;
            this.p2Point.TabStop = false;
            // 
            // winPoint
            // 
            this.winPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.winPoint.Image = global::Throwdown.Properties.Resources.PointEmpty;
            this.winPoint.Location = new System.Drawing.Point(428, 59);
            this.winPoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.winPoint.Name = "winPoint";
            this.winPoint.Size = new System.Drawing.Size(40, 37);
            this.winPoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.winPoint.TabIndex = 14;
            this.winPoint.TabStop = false;
            // 
            // countWin
            // 
            this.countWin.BackColor = System.Drawing.Color.Transparent;
            this.countWin.Font = new System.Drawing.Font("PMingLiU-ExtB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countWin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.countWin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.countWin.Location = new System.Drawing.Point(349, 103);
            this.countWin.Name = "countWin";
            this.countWin.Size = new System.Drawing.Size(200, 55);
            this.countWin.TabIndex = 15;
            this.countWin.Text = "3";
            this.countWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Throwdown.Properties.Resources.gamescreen_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pauseScreen);
            this.Controls.Add(this.countWin);
            this.Controls.Add(this.winPoint);
            this.Controls.Add(this.p2Point);
            this.Controls.Add(this.p1Point);
            this.Controls.Add(this.RoundLabel);
            this.Controls.Add(this.P2label);
            this.Controls.Add(this.P1Label);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.healthBackdrop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "gameScreen";
            this.Size = new System.Drawing.Size(900, 500);
            this.Load += new System.EventHandler(this.gameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.gameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.p1Point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label pauseScreen;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label healthBackdrop;
        private System.Windows.Forms.Label P1Label;
        private System.Windows.Forms.Label P2label;
        private System.Windows.Forms.Label RoundLabel;
        private System.Windows.Forms.PictureBox p1Point;
        private System.Windows.Forms.PictureBox p2Point;
        private System.Windows.Forms.PictureBox winPoint;
        private System.Windows.Forms.Label countWin;
    }
}
