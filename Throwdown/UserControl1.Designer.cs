namespace Throwdown
{
    partial class TitleScreen
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
            this.playButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.controlsButton = new System.Windows.Forms.Button();
            this.controlMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.controlMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatAppearance.BorderSize = 2;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playButton.Location = new System.Drawing.Point(262, 244);
            this.playButton.Margin = new System.Windows.Forms.Padding(2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(150, 41);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.FlatAppearance.BorderSize = 2;
            this.quitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quitButton.Location = new System.Drawing.Point(262, 339);
            this.quitButton.Margin = new System.Windows.Forms.Padding(2);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(150, 41);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TitleLabel.Location = new System.Drawing.Point(150, 24);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(375, 81);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Throwdown";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("PMingLiU-ExtB", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(150, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 81);
            this.label1.TabIndex = 3;
            this.label1.Text = "Throwdown";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // controlsButton
            // 
            this.controlsButton.BackColor = System.Drawing.Color.Transparent;
            this.controlsButton.FlatAppearance.BorderSize = 2;
            this.controlsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.controlsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlsButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.controlsButton.Location = new System.Drawing.Point(262, 291);
            this.controlsButton.Margin = new System.Windows.Forms.Padding(2);
            this.controlsButton.Name = "controlsButton";
            this.controlsButton.Size = new System.Drawing.Size(150, 41);
            this.controlsButton.TabIndex = 1;
            this.controlsButton.Text = "Controls";
            this.controlsButton.UseVisualStyleBackColor = false;
            this.controlsButton.Click += new System.EventHandler(this.controlsButton_Click);
            // 
            // controlMenu
            // 
            this.controlMenu.Image = global::Throwdown.Properties.Resources.controls;
            this.controlMenu.Location = new System.Drawing.Point(0, 0);
            this.controlMenu.Name = "controlMenu";
            this.controlMenu.Size = new System.Drawing.Size(675, 406);
            this.controlMenu.TabIndex = 4;
            this.controlMenu.TabStop = false;
            this.controlMenu.Visible = false;
            this.controlMenu.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keyDown);
            // 
            // TitleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::Throwdown.Properties.Resources.title_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.controlMenu);
            this.Controls.Add(this.controlsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.playButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TitleScreen";
            this.Size = new System.Drawing.Size(675, 406);
            this.Load += new System.EventHandler(this.TitleScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.controlMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button controlsButton;
        private System.Windows.Forms.PictureBox controlMenu;
    }
}
