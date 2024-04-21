using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine.Objects
{
    public interface IAttractable
    {
        float Mass { get; }
        Vector2 Position { get; }
        void ApplyForce(Vector2 force);
    }
}
