using System.Drawing.Drawing2D;
using System.Numerics;
using TaskParticles.Engine;

namespace TaskParticles
{
    public partial class Form1 : Form
    {
        private ParticlesEngine engine;

        private bool isMouseDown = false;
        private Vector2 mouseDown;
        private Vector2 mouseCurrent;

        public Form1()
        {
            InitializeComponent();
            particlesBox.Image = new Bitmap(particlesBox.Width, particlesBox.Height);

            engine = new ParticlesEngine(particlesBox.Width, particlesBox.Height);
        }

        private void particlesBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            engine.Draw(g);

            if (isMouseDown)
            {
                g.Transform = new Matrix();
                g.DrawLine(new Pen(Color.Black), mouseDown.X, mouseDown.Y, mouseCurrent.X, mouseCurrent.Y);
            }
        }

        private void particlesTimer_Tick(object sender, EventArgs e)
        {
            engine.Tick();
            particlesBox.Invalidate();
        }

        private void particlesBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            mouseDown = new Vector2(e.X, e.Y);
        }

        private void particlesBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            var position = new Vector2(e.X, e.Y);
            engine.SpawnParticle(position, (mouseDown - position) / 15);
        }

        private void particlesBox_MouseMove(object sender, MouseEventArgs e)
        {
            mouseCurrent = new Vector2(e.X, e.Y);
        }
    }
}