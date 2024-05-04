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
    public class BlackHole : Particle, IAttractable, IPostTransformable
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
    }
}
