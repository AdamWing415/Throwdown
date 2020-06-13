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
            this.P1CharBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.P2CharBox = new System.Windows.Forms.PictureBox();
            this.testlabel = new System.Windows.Forms.Label();
            this.pauseScreen = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.P1CharBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2CharBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 20;
            this.gametimer.Tick += new System.EventHandler(this.gametimer_Tick);
            // 
            // P1CharBox
            // 
            this.P1CharBox.BackColor = System.Drawing.Color.Transparent;
            this.P1CharBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P1CharBox.Location = new System.Drawing.Point(32, 132);
            this.P1CharBox.Margin = new System.Windows.Forms.Padding(2);
            this.P1CharBox.Name = "P1CharBox";
            this.P1CharBox.Size = new System.Drawing.Size(120, 244);
            this.P1CharBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P1CharBox.TabIndex = 0;
            this.P1CharBox.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(665, 386);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(8, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyUp);
            // 
            // P2CharBox
            // 
            this.P2CharBox.BackColor = System.Drawing.Color.Transparent;
            this.P2CharBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P2CharBox.Location = new System.Drawing.Point(516, 132);
            this.P2CharBox.Margin = new System.Windows.Forms.Padding(2);
            this.P2CharBox.Name = "P2CharBox";
            this.P2CharBox.Size = new System.Drawing.Size(120, 244);
            this.P2CharBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P2CharBox.TabIndex = 2;
            this.P2CharBox.TabStop = false;
            // 
            // testlabel
            // 
            this.testlabel.AutoSize = true;
            this.testlabel.Location = new System.Drawing.Point(300, 59);
            this.testlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testlabel.Name = "testlabel";
            this.testlabel.Size = new System.Drawing.Size(35, 13);
            this.testlabel.TabIndex = 3;
            this.testlabel.Text = "label1";
            // 
            // pauseScreen
            // 
            this.pauseScreen.BackColor = System.Drawing.Color.DarkBlue;
            this.pauseScreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pauseScreen.Font = new System.Drawing.Font("MV Boli", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseScreen.ForeColor = System.Drawing.Color.Goldenrod;
            this.pauseScreen.Location = new System.Drawing.Point(185, 84);
            this.pauseScreen.Name = "pauseScreen";
            this.pauseScreen.Size = new System.Drawing.Size(281, 192);
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
            this.continueButton.Font = new System.Drawing.Font("ROG Fonts", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.ForeColor = System.Drawing.Color.White;
            this.continueButton.Location = new System.Drawing.Point(258, 132);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(142, 46);
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
            this.quitButton.Font = new System.Drawing.Font("ROG Fonts", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.White;
            this.quitButton.Location = new System.Drawing.Point(258, 197);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(142, 46);
            this.quitButton.TabIndex = 6;
            this.quitButton.TabStop = false;
            this.quitButton.Text = "QUIT?";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // gameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pauseScreen);
            this.Controls.Add(this.testlabel);
            this.Controls.Add(this.P2CharBox);
            this.Controls.Add(this.P1CharBox);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "gameScreen";
            this.Size = new System.Drawing.Size(675, 406);
            this.Load += new System.EventHandler(this.gameScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.P1CharBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2CharBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.PictureBox P1CharBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox P2CharBox;
        private System.Windows.Forms.Label testlabel;
        private System.Windows.Forms.Label pauseScreen;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button quitButton;
    }
}
