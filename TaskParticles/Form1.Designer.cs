namespace TaskParticles
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
            components = new System.ComponentModel.Container();
            particlesBox = new PictureBox();
            particlesTimer = new System.Windows.Forms.Timer(components);
            simpleParticleButton = new Button();
            blackHoleButton = new Button();
            ((System.ComponentModel.ISupportInitialize)particlesBox).BeginInit();
            SuspendLayout();
            // 
            // particlesBox
            // 
            particlesBox.Location = new Point(12, 12);
            particlesBox.Name = "particlesBox";
            particlesBox.Size = new Size(797, 638);
            particlesBox.TabIndex = 0;
            particlesBox.TabStop = false;
            particlesBox.Paint += particlesBox_Paint;
            particlesBox.MouseDown += particlesBox_MouseDown;
            particlesBox.MouseMove += particlesBox_MouseMove;
            particlesBox.MouseUp += particlesBox_MouseUp;
            // 
            // particlesTimer
            // 
            particlesTimer.Enabled = true;
            particlesTimer.Interval = 15;
            particlesTimer.Tick += particlesTimer_Tick;
            // 
            // simpleParticleButton
            // 
            simpleParticleButton.Location = new Point(815, 12);
            simpleParticleButton.Name = "simpleParticleButton";
            simpleParticleButton.Size = new Size(166, 23);
            simpleParticleButton.TabIndex = 1;
            simpleParticleButton.Text = "SimpleParticle";
            simpleParticleButton.UseVisualStyleBackColor = true;
            simpleParticleButton.Click += simpleParticleButton_Click;
            // 
            // blackHoleButton
            // 
            blackHoleButton.Location = new Point(815, 41);
            blackHoleButton.Name = "blackHoleButton";
            blackHoleButton.Size = new Size(166, 23);
            blackHoleButton.TabIndex = 2;
            blackHoleButton.Text = "BlackHole";
            blackHoleButton.UseVisualStyleBackColor = true;
            blackHoleButton.Click += blackHoleButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 662);
            Controls.Add(blackHoleButton);
            Controls.Add(simpleParticleButton);
            Controls.Add(particlesBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)particlesBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox particlesBox;
        private System.Windows.Forms.Timer particlesTimer;
        private Button simpleParticleButton;
        private Button blackHoleButton;
    }
}