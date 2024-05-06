using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Particles
{
    public class WhiteHole : Particle, IAttractable, IPostTransformable, ICollidable
    {
        public float Radius { get; set; } = 70;
        public float Mass { get; set; } = -100;

        private Random random = new Random();

        public WhiteHole(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            RenderPriority = 10;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.White), -Radius, -Radius, Radius * 2, Radius * 2);
        }

        public void Transform(Matrix matrix, GameObject gameObject)
        {
            if (gameObject != this && gameObject is IPositionable pos)
            {
                Vector2 diff = Position - pos.Position;

                var scaleFactor = Math.Min(1.5f, Math.Max(1, 17500 / diff.LengthSquared()));
                var angle = (float)(Math.Atan2(diff.Y, diff.X) * 180 / Math.PI);

                matrix.Rotate(angle);
                matrix.Scale(1 / scaleFactor, scaleFactor);
                matrix.Rotate(-angle);
            }
        }

        public void Collide(ParticlesEngine state, GameObject otherObject)
        {
            if (otherObject is BlackHole || otherObject is WhiteHole)
            {
                Alive = false;
                for (int i = 0; i < 100; i++)
                {
                    var particlePart = new SimpleParticlePart(Position + new Vector2((float)random.NextDouble() * 100, (float)random.NextDouble() * 100), Velocity, Mass / 100, Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), random.Next(1000));
                    state.AddObject(particlePart);
                }
            }
        }
    }
}
