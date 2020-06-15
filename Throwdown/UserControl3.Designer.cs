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
            this.P2CharBox = new System.Windows.Forms.PictureBox();
            this.P1CharBox = new System.Windows.Forms.PictureBox();
            this.healthBackdrop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.P2CharBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1CharBox)).BeginInit();
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
            this.continueButton.Margin = new System.Windows.Forms.Padding(4);
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
            this.quitButton.Margin = new System.Windows.Forms.Padding(4);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(189, 57);
            this.quitButton.TabIndex = 6;
            this.quitButton.TabStop = false;
            this.quitButton.Text = "QUIT?";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // P2CharBox
            // 
            this.P2CharBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2CharBox.BackColor = System.Drawing.Color.Transparent;
            this.P2CharBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P2CharBox.Location = new System.Drawing.Point(700, 150);
            this.P2CharBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.P2CharBox.Name = "P2CharBox";
            this.P2CharBox.Size = new System.Drawing.Size(160, 300);
            this.P2CharBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P2CharBox.TabIndex = 2;
            this.P2CharBox.TabStop = false;
            // 
            // P1CharBox
            // 
            this.P1CharBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1CharBox.BackColor = System.Drawing.Color.Transparent;
            this.P1CharBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P1CharBox.Location = new System.Drawing.Point(50, 160);
            this.P1CharBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.P1CharBox.Name = "P1CharBox";
            this.P1CharBox.Size = new System.Drawing.Size(160, 300);
            this.P1CharBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P1CharBox.TabIndex = 0;
            this.P1CharBox.TabStop = false;
            // 
            // healthBackdrop
            // 
            this.healthBackdrop.BackColor = System.Drawing.Color.Transparent;
            this.healthBackdrop.Location = new System.Drawing.Point(-7, 0);
            this.healthBackdrop.Name = "healthBackdrop";
            this.healthBackdrop.Size = new System.Drawing.Size(907, 60);
            this.healthBackdrop.TabIndex = 8;
            // 
            // gameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.healthBackdrop);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pauseScreen);
            this.Controls.Add(this.P1CharBox);
            this.Controls.Add(this.P2CharBox);
            this.Controls.Add(this.inputBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "gameScreen";
            this.Size = new System.Drawing.Size(900, 500);
            this.Load += new System.EventHandler(this.gameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.gameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.P2CharBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1CharBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.PictureBox P1CharBox;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.PictureBox P2CharBox;
        private System.Windows.Forms.Label pauseScreen;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label healthBackdrop;
    }
}
