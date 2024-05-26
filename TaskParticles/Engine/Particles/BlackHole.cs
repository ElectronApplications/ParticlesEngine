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
    public class BlackHole : Particle, IAttractable, IPostTransformable, ICollidable
    {
        public float Mass { get; set; } = 10000;

        private Random random = new Random();
        public WhiteHole? LinkedWhiteHole { get; set; } = null;

        public BlackHole(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            Radius = 70;
            RenderPriority = 10;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Orange), -Radius - 8, -Radius - 8, Radius*2 + 16, Radius*2 + 16);
            g.FillEllipse(new SolidBrush(Color.Black), -Radius - 6, -Radius - 6, Radius*2 + 12, Radius*2 + 12);
        }

        public void Transform(Matrix matrix, GameObject gameObject)
        {
            if (gameObject != this && gameObject is IPositionable pos)
            {
                Vector2 diff = Position - pos.Position;
                
                var scaleFactor = Math.Min(2.5f, Math.Max(1, 35000 / diff.LengthSquared()));
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
                for (int i = 0; i < 50; i++)
                {
                    var particlePart = new SimpleParticlePart(
                        Position + new Vector2((float)random.NextDouble() * 100,
                        (float)random.NextDouble() * 100),
                        Velocity/5 + new Vector2(20.0f*(float)(random.NextDouble()-0.5), 20.0f*(float)(random.NextDouble()-0.5)),
                        Mass / 100,
                        Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), random.Next(1000)
                    );
                    state.AddObject(particlePart);
                }
            }
            else
            {
                if (LinkedWhiteHole != null && LinkedWhiteHole.Alive)
                {
                    var positionable = (otherObject as IPositionable)!;
                    positionable.Position = LinkedWhiteHole.Position + Position - positionable.Position;
                }
                else
                {
                    otherObject.Alive = false;
                }
            }
        }

        public override string Debug()
        {
            bool whiteHoleLinked = LinkedWhiteHole != null && LinkedWhiteHole.Alive;
            string whiteHole = whiteHoleLinked ? "linked" : "not linked";
            return base.Debug() + $"Mass: {Mass};\n" + $"White hole {whiteHole}";
        }
    }
}
