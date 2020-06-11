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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(characterSelectScreen));
            this.tempButton = new System.Windows.Forms.Button();
            this.HitboxSelect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.P1PreviewBox = new System.Windows.Forms.PictureBox();
            this.P2PreviewBox = new System.Windows.Forms.PictureBox();
            this.P1Label = new System.Windows.Forms.Label();
            this.P2Label = new System.Windows.Forms.Label();
            this.P1CharNameLabel = new System.Windows.Forms.Label();
            this.P2CharNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.P1PreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2PreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tempButton
            // 
            this.tempButton.Location = new System.Drawing.Point(396, 431);
            this.tempButton.Name = "tempButton";
            this.tempButton.Size = new System.Drawing.Size(103, 53);
            this.tempButton.TabIndex = 0;
            this.tempButton.Text = "Temporary";
            this.tempButton.UseVisualStyleBackColor = true;
            this.tempButton.Click += new System.EventHandler(this.tempButton_Click);
            // 
            // HitboxSelect
            // 
            this.HitboxSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HitboxSelect.Location = new System.Drawing.Point(325, 175);
            this.HitboxSelect.Name = "HitboxSelect";
            this.HitboxSelect.Size = new System.Drawing.Size(100, 100);
            this.HitboxSelect.TabIndex = 1;
            this.HitboxSelect.Text = "hitbox";
            this.HitboxSelect.UseVisualStyleBackColor = true;
            this.HitboxSelect.Click += new System.EventHandler(this.tempChar_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(475, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 2;
            this.button1.Text = "char 2";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Location = new System.Drawing.Point(475, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 3;
            this.button2.Text = "maybe char 4";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Location = new System.Drawing.Point(325, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 4;
            this.button3.Text = "char 3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // P1PreviewBox
            // 
            this.P1PreviewBox.BackColor = System.Drawing.Color.Transparent;
            this.P1PreviewBox.Location = new System.Drawing.Point(0, 133);
            this.P1PreviewBox.Name = "P1PreviewBox";
            this.P1PreviewBox.Size = new System.Drawing.Size(285, 367);
            this.P1PreviewBox.TabIndex = 5;
            this.P1PreviewBox.TabStop = false;
            // 
            // P2PreviewBox
            // 
            this.P2PreviewBox.BackColor = System.Drawing.Color.Transparent;
            this.P2PreviewBox.Location = new System.Drawing.Point(615, 133);
            this.P2PreviewBox.Name = "P2PreviewBox";
            this.P2PreviewBox.Size = new System.Drawing.Size(285, 367);
            this.P2PreviewBox.TabIndex = 6;
            this.P2PreviewBox.TabStop = false;
            // 
            // P1Label
            // 
            this.P1Label.BackColor = System.Drawing.Color.Transparent;
            this.P1Label.Font = new System.Drawing.Font("PMingLiU-ExtB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P1Label.Image = global::Throwdown.Properties.Resources.text_backdrop;
            this.P1Label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.P1Label.Location = new System.Drawing.Point(3, -8);
            this.P1Label.Name = "P1Label";
            this.P1Label.Size = new System.Drawing.Size(221, 77);
            this.P1Label.TabIndex = 7;
            this.P1Label.Text = "Player 1";
            this.P1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P2Label
            // 
            this.P2Label.BackColor = System.Drawing.Color.Transparent;
            this.P2Label.Font = new System.Drawing.Font("PMingLiU-ExtB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P2Label.Image = global::Throwdown.Properties.Resources.text_backdrop;
            this.P2Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.P2Label.Location = new System.Drawing.Point(679, -8);
            this.P2Label.Name = "P2Label";
            this.P2Label.Size = new System.Drawing.Size(221, 77);
            this.P2Label.TabIndex = 8;
            this.P2Label.Text = "Player 2";
            this.P2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P1CharNameLabel
            // 
            this.P1CharNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1CharNameLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1CharNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P1CharNameLabel.Image = global::Throwdown.Properties.Resources.text_backdrop;
            this.P1CharNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.P1CharNameLabel.Location = new System.Drawing.Point(3, 69);
            this.P1CharNameLabel.Name = "P1CharNameLabel";
            this.P1CharNameLabel.Size = new System.Drawing.Size(190, 61);
            this.P1CharNameLabel.TabIndex = 9;
            this.P1CharNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P2CharNameLabel
            // 
            this.P2CharNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.P2CharNameLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2CharNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P2CharNameLabel.Image = global::Throwdown.Properties.Resources.text_backdrop;
            this.P2CharNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.P2CharNameLabel.Location = new System.Drawing.Point(710, 69);
            this.P2CharNameLabel.Name = "P2CharNameLabel";
            this.P2CharNameLabel.Size = new System.Drawing.Size(190, 61);
            this.P2CharNameLabel.TabIndex = 10;
            this.P2CharNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("PMingLiU-ExtB", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(325, -21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 205);
            this.label1.TabIndex = 11;
            this.label1.Text = "Choose Your Fighter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // characterSelectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Throwdown.Properties.Resources.char_select_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.P2CharNameLabel);
            this.Controls.Add(this.P1CharNameLabel);
            this.Controls.Add(this.P2Label);
            this.Controls.Add(this.P1Label);
            this.Controls.Add(this.P2PreviewBox);
            this.Controls.Add(this.P1PreviewBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HitboxSelect);
            this.Controls.Add(this.tempButton);
            this.Name = "characterSelectScreen";
            this.Size = new System.Drawing.Size(900, 500);
            this.Load += new System.EventHandler(this.characterSelectScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.P1PreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2PreviewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tempButton;
        private System.Windows.Forms.Button HitboxSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox P1PreviewBox;
        private System.Windows.Forms.PictureBox P2PreviewBox;
        private System.Windows.Forms.Label P1Label;
        private System.Windows.Forms.Label P2Label;
        private System.Windows.Forms.Label P1CharNameLabel;
        private System.Windows.Forms.Label P2CharNameLabel;
        private System.Windows.Forms.Label label1;
    }
}
