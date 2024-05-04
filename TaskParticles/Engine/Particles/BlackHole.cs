using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Particles
{
    public class BlackHole : Particle, IAttractable
    {
        public float Mass { get; set; } = 1000;

        public BlackHole(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            RenderPriority = 10;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Orange), -72, -72, 144, 144);
            g.FillEllipse(new SolidBrush(Color.Black), -70, -70, 140, 140);
        }
    }
}
