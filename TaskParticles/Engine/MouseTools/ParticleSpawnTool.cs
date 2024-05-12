using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;
using TaskParticles.Engine.Particles;

namespace TaskParticles.Engine.MouseTools
{
    public class ParticleSpawnTool<T> : LeftMouseTool, IDrawable where T : Particle
    {
        public int RenderPriority { get; set; } = 0;
        Func<Vector2, Vector2, T> ParticleSpawner { get; set; }

        private bool isMouseDown = false;
        private Vector2 mouseDown;
        private Vector2 mouseCurrent;

        public ParticleSpawnTool(Func<Vector2, Vector2, T> particleSpawner) {
            ParticleSpawner = particleSpawner;
        }

        public override void MouseDown(int x, int y, ParticlesEngine state)
        {
            isMouseDown = true;
            mouseDown = new Vector2(x, y);
        }

        public override void MouseMove(int x, int y, ParticlesEngine state)
        {
            mouseCurrent = new Vector2(x, y);
        }

        public override void MouseUp(int x, int y, ParticlesEngine state)
        {
            isMouseDown = false;
            var position = new Vector2(x, y);
            state.AddObject(ParticleSpawner((position - new Vector2(state.Width / 2, state.Height / 2)) / state.Scale - state.Translation, (mouseDown - position) / state.Scale));
        }

        public Matrix GetTransform(Matrix preMatrix)
        {
            return new Matrix();
        }

        public void Render(Graphics g)
        {
            if (isMouseDown)
            {
                g.Transform = new Matrix();
                g.DrawLine(new Pen(Color.White), mouseDown.X, mouseDown.Y, mouseCurrent.X, mouseCurrent.Y);
            }
        }
    }
}
