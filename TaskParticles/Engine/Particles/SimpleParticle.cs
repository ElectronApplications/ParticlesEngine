using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Particles
{
    class SimpleParticle : Particle, IAttractable, ICollidable
    {
        public float Mass { get; set; }
        public float Radius { get; set; } = 15;

        private Random random = new Random();
        private Color ParticleColor;

        public SimpleParticle(Vector2 position, Vector2 velocity, float mass, Color color) : base(position, velocity)
        {
            Mass = mass;
            ParticleColor = color;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(ParticleColor), -15, -15, 30, 30);
        }

        public void Collide(ParticlesEngine state, GameObject otherObject)
        {
            if (otherObject is SimpleParticle)
            {
                Alive = false;
                for (int i = 0; i < 10; i++)
                {
                    var particlePart = new SimpleParticlePart(Position + new Vector2((float)random.NextDouble() * 10, (float)random.NextDouble() * 10), Velocity, Mass/10, ParticleColor, random.Next(1000));
                    state.AddObject(particlePart);
                }
            }
        }
    }
}
