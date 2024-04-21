using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Interfaces
{
    public interface IAttractable: IMovable
    {
        float Mass { get; set; }
        void ApplyForce(Vector2 force)
        {
            Velocity += force / Mass;
        }
    }
}
