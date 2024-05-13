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

        private Random random = new Random();
        private Color ParticleColor;

        public SimpleParticle(Vector2 position, Vector2 velocity, float mass, Color color) : base(position, velocity)
        {
            Radius = 15;
            Mass = mass;
            ParticleColor = color;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(ParticleColor), -Radius, -Radius, Radius*2, Radius*2);
        }

        public void Collide(ParticlesEngine state, GameObject otherObject)
        {
            if (otherObject is SimpleParticle)
            {
                Alive = false;
                for (int i = 0; i < 10; i++)
                {
                    var particlePart = new SimpleParticlePart(
                        Position + new Vector2((float)random.NextDouble() * 10,
                        (float)random.NextDouble() * 10),
                        Velocity/5 + new Vector2(5.0f * (float)(random.NextDouble() - 0.5), 5.0f * (float)(random.NextDouble() - 0.5)),
                        Mass/10,
                        ParticleColor,
                        random.Next(1000)
                    );
                    state.AddObject(particlePart);
                }
            }
        }
    }
}
