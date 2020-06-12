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
            this.P1CharBox.Location = new System.Drawing.Point(42, 162);
            this.P1CharBox.Name = "P1CharBox";
            this.P1CharBox.Size = new System.Drawing.Size(160, 300);
            this.P1CharBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P1CharBox.TabIndex = 0;
            this.P1CharBox.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(887, 475);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyUp);
            // 
            // P2CharBox
            // 
            this.P2CharBox.BackColor = System.Drawing.Color.Transparent;
            this.P2CharBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.P2CharBox.Location = new System.Drawing.Point(688, 162);
            this.P2CharBox.Name = "P2CharBox";
            this.P2CharBox.Size = new System.Drawing.Size(160, 300);
            this.P2CharBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P2CharBox.TabIndex = 2;
            this.P2CharBox.TabStop = false;
            // 
            // testlabel
            // 
            this.testlabel.AutoSize = true;
            this.testlabel.Location = new System.Drawing.Point(400, 73);
            this.testlabel.Name = "testlabel";
            this.testlabel.Size = new System.Drawing.Size(46, 17);
            this.testlabel.TabIndex = 3;
            this.testlabel.Text = "label1";
            // 
            // gameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.Controls.Add(this.testlabel);
            this.Controls.Add(this.P2CharBox);
            this.Controls.Add(this.P1CharBox);
            this.Controls.Add(this.textBox1);
            this.Name = "gameScreen";
            this.Size = new System.Drawing.Size(900, 500);
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
    }
}
