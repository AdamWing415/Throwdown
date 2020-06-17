﻿namespace Throwdown
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
            this.FightButton = new System.Windows.Forms.Button();
            this.HitboxSelect = new System.Windows.Forms.Button();
            this.KeycodeSelect = new System.Windows.Forms.Button();
            this.VoidSelectButton = new System.Windows.Forms.Button();
            this.P1PreviewBox = new System.Windows.Forms.PictureBox();
            this.P2PreviewBox = new System.Windows.Forms.PictureBox();
            this.P1Label = new System.Windows.Forms.Label();
            this.P2Label = new System.Windows.Forms.Label();
            this.P1CharNameLabel = new System.Windows.Forms.Label();
            this.P2CharNameLabel = new System.Windows.Forms.Label();
            this.ChooseLabel = new System.Windows.Forms.Label();
            this.hitboxlabel = new System.Windows.Forms.Label();
            this.Keycodelabel = new System.Windows.Forms.Label();
            this.voidlabel = new System.Windows.Forms.Label();
            this.P1SelectionLabel = new System.Windows.Forms.Label();
            this.P2SelectionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.P1PreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2PreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FightButton
            // 
            this.FightButton.BackColor = System.Drawing.Color.DarkBlue;
            this.FightButton.BackgroundImage = global::Throwdown.Properties.Resources.title_background;
            this.FightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FightButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FightButton.FlatAppearance.BorderSize = 2;
            this.FightButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.FightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FightButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 79.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FightButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FightButton.Location = new System.Drawing.Point(3, 238);
            this.FightButton.Name = "FightButton";
            this.FightButton.Size = new System.Drawing.Size(894, 138);
            this.FightButton.TabIndex = 0;
            this.FightButton.Text = "FIGHT!";
            this.FightButton.UseVisualStyleBackColor = false;
            this.FightButton.Visible = false;
            this.FightButton.Click += new System.EventHandler(this.FightButton_Click);
            this.FightButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FightButton_KeyDown);
            // 
            // HitboxSelect
            // 
            this.HitboxSelect.BackColor = System.Drawing.Color.DarkBlue;
            this.HitboxSelect.BackgroundImage = global::Throwdown.Properties.Resources.hitbox_select_image;
            this.HitboxSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HitboxSelect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.HitboxSelect.FlatAppearance.BorderSize = 2;
            this.HitboxSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.HitboxSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HitboxSelect.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HitboxSelect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HitboxSelect.Location = new System.Drawing.Point(325, 190);
            this.HitboxSelect.Name = "HitboxSelect";
            this.HitboxSelect.Size = new System.Drawing.Size(103, 100);
            this.HitboxSelect.TabIndex = 1;
            this.HitboxSelect.UseVisualStyleBackColor = false;
            this.HitboxSelect.Click += new System.EventHandler(this.tempChar_Click);
            // 
            // KeycodeSelect
            // 
            this.KeycodeSelect.BackColor = System.Drawing.Color.DarkBlue;
            this.KeycodeSelect.BackgroundImage = global::Throwdown.Properties.Resources.Keycode_select_image;
            this.KeycodeSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.KeycodeSelect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.KeycodeSelect.FlatAppearance.BorderSize = 2;
            this.KeycodeSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.KeycodeSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeycodeSelect.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeycodeSelect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.KeycodeSelect.Location = new System.Drawing.Point(475, 190);
            this.KeycodeSelect.Name = "KeycodeSelect";
            this.KeycodeSelect.Size = new System.Drawing.Size(103, 100);
            this.KeycodeSelect.TabIndex = 2;
            this.KeycodeSelect.UseVisualStyleBackColor = false;
            this.KeycodeSelect.Click += new System.EventHandler(this.KeycodeSelect_Click);
            // 
            // VoidSelectButton
            // 
            this.VoidSelectButton.BackColor = System.Drawing.Color.DarkBlue;
            this.VoidSelectButton.BackgroundImage = global::Throwdown.Properties.Resources.Void_select_image;
            this.VoidSelectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VoidSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.VoidSelectButton.FlatAppearance.BorderSize = 2;
            this.VoidSelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.VoidSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VoidSelectButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoidSelectButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VoidSelectButton.Location = new System.Drawing.Point(400, 340);
            this.VoidSelectButton.Name = "VoidSelectButton";
            this.VoidSelectButton.Size = new System.Drawing.Size(103, 100);
            this.VoidSelectButton.TabIndex = 4;
            this.VoidSelectButton.UseVisualStyleBackColor = false;
            this.VoidSelectButton.Click += new System.EventHandler(this.VoidSelectButton_Click);
            // 
            // P1PreviewBox
            // 
            this.P1PreviewBox.BackColor = System.Drawing.Color.Transparent;
            this.P1PreviewBox.Location = new System.Drawing.Point(0, 133);
            this.P1PreviewBox.Name = "P1PreviewBox";
            this.P1PreviewBox.Size = new System.Drawing.Size(285, 367);
            this.P1PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P1PreviewBox.TabIndex = 5;
            this.P1PreviewBox.TabStop = false;
            // 
            // P2PreviewBox
            // 
            this.P2PreviewBox.BackColor = System.Drawing.Color.Transparent;
            this.P2PreviewBox.Location = new System.Drawing.Point(615, 133);
            this.P2PreviewBox.Name = "P2PreviewBox";
            this.P2PreviewBox.Size = new System.Drawing.Size(285, 367);
            this.P2PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.P2Label.Location = new System.Drawing.Point(671, -8);
            this.P2Label.Name = "P2Label";
            this.P2Label.Size = new System.Drawing.Size(229, 77);
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
            // ChooseLabel
            // 
            this.ChooseLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChooseLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChooseLabel.Image = ((System.Drawing.Image)(resources.GetObject("ChooseLabel.Image")));
            this.ChooseLabel.Location = new System.Drawing.Point(325, -21);
            this.ChooseLabel.Name = "ChooseLabel";
            this.ChooseLabel.Size = new System.Drawing.Size(250, 205);
            this.ChooseLabel.TabIndex = 11;
            this.ChooseLabel.Text = "Choose Your Fighter";
            this.ChooseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hitboxlabel
            // 
            this.hitboxlabel.BackColor = System.Drawing.Color.Transparent;
            this.hitboxlabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hitboxlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hitboxlabel.Image = global::Throwdown.Properties.Resources.text_backdrop;
            this.hitboxlabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.hitboxlabel.Location = new System.Drawing.Point(320, 290);
            this.hitboxlabel.Name = "hitboxlabel";
            this.hitboxlabel.Size = new System.Drawing.Size(118, 44);
            this.hitboxlabel.TabIndex = 12;
            this.hitboxlabel.Text = "Hitbox";
            this.hitboxlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Keycodelabel
            // 
            this.Keycodelabel.BackColor = System.Drawing.Color.Transparent;
            this.Keycodelabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keycodelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Keycodelabel.Image = global::Throwdown.Properties.Resources.text_backdrop;
            this.Keycodelabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Keycodelabel.Location = new System.Drawing.Point(464, 290);
            this.Keycodelabel.Name = "Keycodelabel";
            this.Keycodelabel.Size = new System.Drawing.Size(121, 44);
            this.Keycodelabel.TabIndex = 13;
            this.Keycodelabel.Text = "Keycode";
            this.Keycodelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voidlabel
            // 
            this.voidlabel.BackColor = System.Drawing.Color.Transparent;
            this.voidlabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voidlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.voidlabel.Image = global::Throwdown.Properties.Resources.text_backdrop;
            this.voidlabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.voidlabel.Location = new System.Drawing.Point(389, 441);
            this.voidlabel.Name = "voidlabel";
            this.voidlabel.Size = new System.Drawing.Size(117, 44);
            this.voidlabel.TabIndex = 14;
            this.voidlabel.Text = "Void";
            this.voidlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P1SelectionLabel
            // 
            this.P1SelectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1SelectionLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1SelectionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P1SelectionLabel.Image = ((System.Drawing.Image)(resources.GetObject("P1SelectionLabel.Image")));
            this.P1SelectionLabel.Location = new System.Drawing.Point(275, 190);
            this.P1SelectionLabel.Name = "P1SelectionLabel";
            this.P1SelectionLabel.Size = new System.Drawing.Size(45, 45);
            this.P1SelectionLabel.TabIndex = 15;
            this.P1SelectionLabel.Text = "P1";
            this.P1SelectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.P1SelectionLabel.Visible = false;
            // 
            // P2SelectionLabel
            // 
            this.P2SelectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.P2SelectionLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2SelectionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.P2SelectionLabel.Image = ((System.Drawing.Image)(resources.GetObject("P2SelectionLabel.Image")));
            this.P2SelectionLabel.Location = new System.Drawing.Point(274, 235);
            this.P2SelectionLabel.Name = "P2SelectionLabel";
            this.P2SelectionLabel.Size = new System.Drawing.Size(45, 45);
            this.P2SelectionLabel.TabIndex = 16;
            this.P2SelectionLabel.Text = "P2";
            this.P2SelectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.P2SelectionLabel.Visible = false;
            // 
            // characterSelectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Throwdown.Properties.Resources.char_select_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.FightButton);
            this.Controls.Add(this.P2SelectionLabel);
            this.Controls.Add(this.P1SelectionLabel);
            this.Controls.Add(this.voidlabel);
            this.Controls.Add(this.Keycodelabel);
            this.Controls.Add(this.hitboxlabel);
            this.Controls.Add(this.ChooseLabel);
            this.Controls.Add(this.P2CharNameLabel);
            this.Controls.Add(this.P1CharNameLabel);
            this.Controls.Add(this.P2Label);
            this.Controls.Add(this.P1Label);
            this.Controls.Add(this.P2PreviewBox);
            this.Controls.Add(this.P1PreviewBox);
            this.Controls.Add(this.VoidSelectButton);
            this.Controls.Add(this.KeycodeSelect);
            this.Controls.Add(this.HitboxSelect);
            this.Name = "characterSelectScreen";
            this.Size = new System.Drawing.Size(900, 500);
            this.Load += new System.EventHandler(this.characterSelectScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.P1PreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2PreviewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FightButton;
        private System.Windows.Forms.Button HitboxSelect;
        private System.Windows.Forms.Button KeycodeSelect;
        private System.Windows.Forms.Button VoidSelectButton;
        private System.Windows.Forms.PictureBox P1PreviewBox;
        private System.Windows.Forms.PictureBox P2PreviewBox;
        private System.Windows.Forms.Label P1Label;
        private System.Windows.Forms.Label P2Label;
        private System.Windows.Forms.Label P1CharNameLabel;
        private System.Windows.Forms.Label P2CharNameLabel;
        private System.Windows.Forms.Label ChooseLabel;
        private System.Windows.Forms.Label hitboxlabel;
        private System.Windows.Forms.Label Keycodelabel;
        private System.Windows.Forms.Label voidlabel;
        private System.Windows.Forms.Label P1SelectionLabel;
        private System.Windows.Forms.Label P2SelectionLabel;
    }
}
