using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Particles;

namespace TaskParticles.Engine.Controllers
{
    public class BackgroundParticlesController : GameController
    {
        private Random random;

        public BackgroundParticlesController()
        {
            random = new Random();
        }

        public override void ControllerTick(ParticlesEngine state)
        {
            if (random.Next((int)(10 * state.Scale)) == 0)
            {
                var position = new Vector2(random.Next(-state.Width/2, state.Width/2), random.Next(-state.Height/2, state.Height/2));
                position /= state.Scale;
                position -= state.Translation;
                state.AddObject(new BackgroundParticle(position));
            }
        }
    }
}
