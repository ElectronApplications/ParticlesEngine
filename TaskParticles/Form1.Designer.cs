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
            whiteHoleButton = new Button();
            particlesLabel = new Label();
            debugLabel = new Label();
            stopStartButton = new Button();
            stepButton = new Button();
            simulationSpeedBar = new TrackBar();
            debugModeButton = new Button();
            debugModeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)particlesBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simulationSpeedBar).BeginInit();
            SuspendLayout();
            // 
            // particlesBox
            // 
            particlesBox.Location = new Point(12, 12);
            particlesBox.Name = "particlesBox";
            particlesBox.Size = new Size(944, 688);
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
            simpleParticleButton.Location = new Point(962, 42);
            simpleParticleButton.Name = "simpleParticleButton";
            simpleParticleButton.Size = new Size(166, 23);
            simpleParticleButton.TabIndex = 1;
            simpleParticleButton.Text = "SimpleParticle";
            simpleParticleButton.UseVisualStyleBackColor = true;
            simpleParticleButton.Click += simpleParticleButton_Click;
            // 
            // blackHoleButton
            // 
            blackHoleButton.Location = new Point(962, 71);
            blackHoleButton.Name = "blackHoleButton";
            blackHoleButton.Size = new Size(166, 23);
            blackHoleButton.TabIndex = 2;
            blackHoleButton.Text = "BlackHole";
            blackHoleButton.UseVisualStyleBackColor = true;
            blackHoleButton.Click += blackHoleButton_Click;
            // 
            // whiteHoleButton
            // 
            whiteHoleButton.Location = new Point(962, 100);
            whiteHoleButton.Name = "whiteHoleButton";
            whiteHoleButton.Size = new Size(166, 23);
            whiteHoleButton.TabIndex = 3;
            whiteHoleButton.Text = "WhiteHole";
            whiteHoleButton.UseVisualStyleBackColor = true;
            whiteHoleButton.Click += whiteHoleButton_Click;
            // 
            // particlesLabel
            // 
            particlesLabel.AutoSize = true;
            particlesLabel.Location = new Point(962, 12);
            particlesLabel.Name = "particlesLabel";
            particlesLabel.Size = new Size(51, 15);
            particlesLabel.TabIndex = 4;
            particlesLabel.Text = "Particles";
            // 
            // debugLabel
            // 
            debugLabel.AutoSize = true;
            debugLabel.Location = new Point(962, 141);
            debugLabel.Name = "debugLabel";
            debugLabel.Size = new Size(42, 15);
            debugLabel.TabIndex = 5;
            debugLabel.Text = "Debug";
            // 
            // stopStartButton
            // 
            stopStartButton.Location = new Point(962, 171);
            stopStartButton.Name = "stopStartButton";
            stopStartButton.Size = new Size(166, 23);
            stopStartButton.TabIndex = 6;
            stopStartButton.Text = "Stop";
            stopStartButton.UseVisualStyleBackColor = true;
            stopStartButton.Click += stopStartButton_Click;
            // 
            // stepButton
            // 
            stepButton.Enabled = false;
            stepButton.Location = new Point(962, 200);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(166, 23);
            stepButton.TabIndex = 7;
            stepButton.Text = "Step";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += stepButton_Click;
            // 
            // simulationSpeedBar
            // 
            simulationSpeedBar.Location = new Point(962, 229);
            simulationSpeedBar.Maximum = 100;
            simulationSpeedBar.Minimum = 5;
            simulationSpeedBar.Name = "simulationSpeedBar";
            simulationSpeedBar.Size = new Size(166, 45);
            simulationSpeedBar.TabIndex = 8;
            simulationSpeedBar.Value = 15;
            simulationSpeedBar.Scroll += simulationSpeedBar_Scroll;
            // 
            // debugModeButton
            // 
            debugModeButton.Location = new Point(962, 300);
            debugModeButton.Name = "debugModeButton";
            debugModeButton.Size = new Size(166, 23);
            debugModeButton.TabIndex = 9;
            debugModeButton.Text = "Enable";
            debugModeButton.UseVisualStyleBackColor = true;
            debugModeButton.Click += debugModeButton_Click;
            // 
            // debugModeLabel
            // 
            debugModeLabel.AutoSize = true;
            debugModeLabel.Location = new Point(962, 277);
            debugModeLabel.Name = "debugModeLabel";
            debugModeLabel.Size = new Size(76, 15);
            debugModeLabel.TabIndex = 10;
            debugModeLabel.Text = "Debug Mode";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 712);
            Controls.Add(debugModeLabel);
            Controls.Add(debugModeButton);
            Controls.Add(simulationSpeedBar);
            Controls.Add(stepButton);
            Controls.Add(stopStartButton);
            Controls.Add(debugLabel);
            Controls.Add(particlesLabel);
            Controls.Add(whiteHoleButton);
            Controls.Add(blackHoleButton);
            Controls.Add(simpleParticleButton);
            Controls.Add(particlesBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)particlesBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)simulationSpeedBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox particlesBox;
        private System.Windows.Forms.Timer particlesTimer;
        private Button simpleParticleButton;
        private Button blackHoleButton;
        private Button whiteHoleButton;
        private Label particlesLabel;
        private Label debugLabel;
        private Button stopStartButton;
        private Button stepButton;
        private TrackBar simulationSpeedBar;
        private Button debugModeButton;
        private Label debugModeLabel;
    }
}