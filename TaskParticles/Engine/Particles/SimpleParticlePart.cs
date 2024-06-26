﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Particles
{
    public class SimpleParticlePart : Particle, IAttractable, ICollidable
    {
        public float Mass { get; set; }
        public int Life { get; set; }
        public Color ParticleColor { get; set; }

        public SimpleParticlePart(Vector2 position, Vector2 velocity, float mass, Color color, int life) : base(position, velocity)
        {
            Radius = 5;
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
            g.FillEllipse(new SolidBrush(color), -Radius, -Radius, Radius*2, Radius*2);
        }

        public void Collide(ParticlesEngine state, GameObject otherObject)
        {
            
        }

        public override string Debug()
        {
            return base.Debug() + $"Mass: {Mass};\n" + $"Life: {Life}";
        }
    }
}
