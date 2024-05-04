using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine
{
    public abstract class LeftMouseTool : GameObject
    {
        public abstract void MouseDown(int x, int y, ParticlesEngine state);
        public abstract void MouseMove(int x, int y, ParticlesEngine state);
        public abstract void MouseUp(int x, int y, ParticlesEngine state);

        public override void Tick() { }
    }
}
