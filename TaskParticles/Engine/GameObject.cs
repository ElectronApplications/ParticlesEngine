using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine
{
    public abstract class GameObject
    {
        public bool Alive { get; set; } = true;
        public abstract void Tick();
    }
}
