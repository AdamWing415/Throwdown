namespace Throwdown
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameScreenbackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreenbackground)).BeginInit();
            this.SuspendLayout();
            // 
            // gameScreenbackground
            // 
            this.gameScreenbackground.BackgroundImage = global::Throwdown.Properties.Resources.gamescreen_Background;
            this.gameScreenbackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameScreenbackground.Location = new System.Drawing.Point(-2, 0);
            this.gameScreenbackground.Name = "gameScreenbackground";
            this.gameScreenbackground.Size = new System.Drawing.Size(900, 500);
            this.gameScreenbackground.TabIndex = 0;
            this.gameScreenbackground.TabStop = false;
            this.gameScreenbackground.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.gameScreenbackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Throwdown";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameScreenbackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gameScreenbackground;
    }
}

