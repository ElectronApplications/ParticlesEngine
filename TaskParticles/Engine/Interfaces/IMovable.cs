using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine.Interfaces
{
    public interface IMovable : IPositionable
    {
        public Vector2 Velocity { get; set; }
    }
}
