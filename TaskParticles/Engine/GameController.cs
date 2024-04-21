using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine
{
    public abstract class GameController : GameObject
    {
        public abstract void ControllerTick(ParticlesEngine state);

        public override void Tick() { }
    }
}
