using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine.Interfaces
{
    public interface IPositionable
    {
        public Vector2 Position { get; set; }
    }
}
