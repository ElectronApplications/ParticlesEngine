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
            if (random.Next(10) == 0)
            {
                var position = new Vector2(random.Next(state.Width), random.Next(state.Height));
                state.GameObjects.Add(new BackgroundParticle(position));
            }
        }
    }
}
