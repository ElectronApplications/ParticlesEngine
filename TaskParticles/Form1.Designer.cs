﻿namespace TaskParticles
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.particlesBox = new System.Windows.Forms.PictureBox();
            this.particlesTimer = new System.Windows.Forms.Timer(this.components);
            this.simpleParticleButton = new System.Windows.Forms.Button();
            this.blackHoleButton = new System.Windows.Forms.Button();
            this.whiteHoleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.particlesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // particlesBox
            // 
            this.particlesBox.Location = new System.Drawing.Point(12, 12);
            this.particlesBox.Name = "particlesBox";
            this.particlesBox.Size = new System.Drawing.Size(797, 638);
            this.particlesBox.TabIndex = 0;
            this.particlesBox.TabStop = false;
            this.particlesBox.Paint += new System.Windows.Forms.PaintEventHandler(this.particlesBox_Paint);
            this.particlesBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.particlesBox_MouseDown);
            this.particlesBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.particlesBox_MouseMove);
            this.particlesBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.particlesBox_MouseUp);
            // 
            // particlesTimer
            // 
            this.particlesTimer.Enabled = true;
            this.particlesTimer.Interval = 15;
            this.particlesTimer.Tick += new System.EventHandler(this.particlesTimer_Tick);
            // 
            // simpleParticleButton
            // 
            this.simpleParticleButton.Location = new System.Drawing.Point(815, 12);
            this.simpleParticleButton.Name = "simpleParticleButton";
            this.simpleParticleButton.Size = new System.Drawing.Size(166, 23);
            this.simpleParticleButton.TabIndex = 1;
            this.simpleParticleButton.Text = "SimpleParticle";
            this.simpleParticleButton.UseVisualStyleBackColor = true;
            this.simpleParticleButton.Click += new System.EventHandler(this.simpleParticleButton_Click);
            // 
            // blackHoleButton
            // 
            this.blackHoleButton.Location = new System.Drawing.Point(815, 41);
            this.blackHoleButton.Name = "blackHoleButton";
            this.blackHoleButton.Size = new System.Drawing.Size(166, 23);
            this.blackHoleButton.TabIndex = 2;
            this.blackHoleButton.Text = "BlackHole";
            this.blackHoleButton.UseVisualStyleBackColor = true;
            this.blackHoleButton.Click += new System.EventHandler(this.blackHoleButton_Click);
            // 
            // whiteHoleButton
            // 
            this.whiteHoleButton.Location = new System.Drawing.Point(815, 70);
            this.whiteHoleButton.Name = "whiteHoleButton";
            this.whiteHoleButton.Size = new System.Drawing.Size(166, 23);
            this.whiteHoleButton.TabIndex = 3;
            this.whiteHoleButton.Text = "WhiteHole";
            this.whiteHoleButton.UseVisualStyleBackColor = true;
            this.whiteHoleButton.Click += new System.EventHandler(this.whiteHoleButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 662);
            this.Controls.Add(this.whiteHoleButton);
            this.Controls.Add(this.blackHoleButton);
            this.Controls.Add(this.simpleParticleButton);
            this.Controls.Add(this.particlesBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.particlesBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox particlesBox;
        private System.Windows.Forms.Timer particlesTimer;
        private Button simpleParticleButton;
        private Button blackHoleButton;
        private Button whiteHoleButton;
    }
}