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
            ((System.ComponentModel.ISupportInitialize)particlesBox).BeginInit();
            SuspendLayout();
            // 
            // particlesBox
            // 
            particlesBox.Location = new Point(12, 12);
            particlesBox.Name = "particlesBox";
            particlesBox.Size = new Size(969, 638);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 662);
            Controls.Add(particlesBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)particlesBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox particlesBox;
        private System.Windows.Forms.Timer particlesTimer;
    }
}