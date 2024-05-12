using TaskParticles.Engine;
using TaskParticles.Engine.Controllers;
using TaskParticles.Engine.MouseTools;
using TaskParticles.Engine.Particles;

namespace TaskParticles
{
    public partial class Form1 : Form
    {
        private ParticlesEngine engine;
        private LeftMouseTool currentMouseTool;
        private BlackHole? previousBlackHole = null;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            particlesBox.MouseWheel += particlesBox_MouseWheel;
            particlesBox.Image = new Bitmap(particlesBox.Width, particlesBox.Height);

            engine = new ParticlesEngine(particlesBox.Width, particlesBox.Height);

            currentMouseTool = new ParticleSpawnTool<SimpleParticle>((position, diff) => new SimpleParticle(position, diff / 15, random.Next(30), Color.Red));

            engine.AddObject(new GravityController());
            engine.AddObject(new CollisionController());
            engine.AddObject(new BackgroundParticlesController());
            engine.AddObject(currentMouseTool);
        }

        private void particlesBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            engine.Draw(g);
        }

        private void particlesTimer_Tick(object sender, EventArgs e)
        {
            engine.Tick();
            particlesBox.Invalidate();
        }

        private void particlesBox_MouseDown(object sender, MouseEventArgs e)
        {
            engine.MouseDown(e.X, e.Y, e.Button);
        }

        private void particlesBox_MouseMove(object sender, MouseEventArgs e)
        {
            engine.MouseMove(e.X, e.Y);
        }

        private void particlesBox_MouseUp(object sender, MouseEventArgs e)
        {
            engine.MouseUp(e.X, e.Y, e.Button);
        }

        private void particlesBox_MouseWheel(object? sender, MouseEventArgs e)
        {
            engine.MouseWheel(e.Delta);
        }

        private void simpleParticleButton_Click(object sender, EventArgs e)
        {
            engine.RemoveObject(currentMouseTool);
            currentMouseTool = new ParticleSpawnTool<SimpleParticle>((position, diff) => new SimpleParticle(position, diff / 15, 10, Color.FromArgb(random.Next(255), random.Next(255), random.Next(255))));
            engine.AddObject(currentMouseTool);
        }

        private void blackHoleButton_Click(object sender, EventArgs e)
        {
            engine.RemoveObject(currentMouseTool);
            currentMouseTool = new ParticleSpawnTool<BlackHole>((position, diff) =>
            {
                var blackHole = new BlackHole(position, diff / 15);
                previousBlackHole = blackHole;
                return blackHole;
            });
            engine.AddObject(currentMouseTool);
        }

        private void whiteHoleButton_Click(object sender, EventArgs e)
        {
            engine.RemoveObject(currentMouseTool);
            currentMouseTool = new ParticleSpawnTool<WhiteHole>((position, diff) =>
            {
                var whiteHole = new WhiteHole(position, diff / 15);
                if (previousBlackHole != null)
                {
                    previousBlackHole.LinkedWhiteHole = whiteHole;
                }
                return whiteHole;
            });
            engine.AddObject(currentMouseTool);
        }
    }
}