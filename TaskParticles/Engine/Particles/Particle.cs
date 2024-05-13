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
    public abstract class Particle : GameObject, IDrawable, IMovable
    {
        public int RenderPriority { get; set; } = 100;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Radius { get; set; } = 10;

        public Particle(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public override void Tick()
        {
            Position += Velocity;
        }

        public virtual Matrix GetTransform(Matrix preMatrix)
        {
            preMatrix.Translate(Position.X, Position.Y);
            return preMatrix;
        }

        public abstract void Render(Graphics g);
        public virtual String Debug()
        {
            var result = "";
            result += $"Radius: {Radius.ToString("0.0")};\n";
            result += $"X: {Position.X.ToString("0.0")}; Y: {Position.Y.ToString("0.0")};\n";
            result += $"VX: {Velocity.X.ToString("0.0")}; VY: {Velocity.Y.ToString("0.0")};\n";
            return result;
        }
    }
}
