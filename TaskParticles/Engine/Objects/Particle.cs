using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine.Objects
{
    abstract class Particle : GameObject, IDrawable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public Particle(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public override void Tick()
        {
            Position += Velocity;
        }

        public virtual Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(Position.X, Position.Y);
            return matrix;
        }

        public abstract void Render(Graphics g);
    }
}
