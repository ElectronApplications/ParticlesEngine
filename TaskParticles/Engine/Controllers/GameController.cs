using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Objects;

namespace TaskParticles.Engine.Controllers
{
    abstract class GameController
    {
        public abstract List<GameObject> Tick(List<GameObject> gameObjects);
    }
}
