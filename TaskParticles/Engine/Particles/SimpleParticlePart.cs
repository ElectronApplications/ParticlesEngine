using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Particles
{
    public class SimpleParticlePart : Particle, IAttractable
    {
        public float Mass { get; set; }
        public int Life { get; set; }
        public Color ParticleColor { get; set; }

        public SimpleParticlePart(Vector2 position, Vector2 velocity, float mass, Color color, int life) : base(position, velocity)
        {
            Mass = mass;
            ParticleColor = color;
            Life = life;
        }

        public override void Tick()
        {
            base.Tick();
            Life -= 1;
            if (Life <= 0)
                Alive = false;
        }

        public override void Render(Graphics g)
        {
            var color = Color.FromArgb((int)(Math.Min(1f, (float)Life/500) * 255), ParticleColor);
            g.FillEllipse(new SolidBrush(color), -5, -5, 10, 10);
        }
    }
}
