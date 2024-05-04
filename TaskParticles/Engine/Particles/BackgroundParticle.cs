using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Particles
{
    public class BackgroundParticle : Particle
    {
        public int Life { get; set; }

        private Random random;

        public BackgroundParticle(Vector2 position) : base(position, Vector2.Zero)
        {
            RenderPriority = 1000;
            Life = 500;
            random = new Random();
        }

        public override void Tick()
        {
            base.Tick();
            Life -= 1;
            if (Life <= 0)
                Alive = false;
            Velocity += new Vector2(((float)random.NextDouble() - 0.5f)/10.0f, ((float)random.NextDouble() - 0.5f)/10.0f);
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Life switch
            {
                >250 => Color.Blue,
                >125 => Color.LightBlue,
                >50 => Color.Orange,
                >25 => Color.Yellow,
                _ => Color.White
            }), -2, -2, 4, 4);
        }
    }
}
