using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Particles
{
    class SimpleParticle : Particle, IAttractable
    {
        public float Mass { get; set; }

        public SimpleParticle(Vector2 position, Vector2 velocity, float mass) : base(position, velocity)
        {
            Mass = mass;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), -15, -15, 30, 30);
        }
    }
}
