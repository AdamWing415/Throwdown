namespace Throwdown
{
    partial class characterSelectScreen
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
            this.tempButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tempButton
            // 
            this.tempButton.Location = new System.Drawing.Point(300, 200);
            this.tempButton.Name = "tempButton";
            this.tempButton.Size = new System.Drawing.Size(240, 110);
            this.tempButton.TabIndex = 0;
            this.tempButton.Text = "Temporary";
            this.tempButton.UseVisualStyleBackColor = true;
            this.tempButton.Click += new System.EventHandler(this.tempButton_Click);
            // 
            // characterSelectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tempButton);
            this.Name = "characterSelectScreen";
            this.Size = new System.Drawing.Size(900, 506);
            this.Load += new System.EventHandler(this.characterSelectScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tempButton;
    }
}
