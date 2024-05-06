using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Interfaces;

namespace TaskParticles.Engine.Controllers
{
    public class CollisionController : GameController
    {
        public override void ControllerTick(ParticlesEngine state)
        {
            var collidableObjects = state.GameObjects.Select(obj => obj as ICollidable).Where(obj => obj != null).Select(obj => obj!);

            foreach (var obj1 in collidableObjects)
            {
                foreach (var obj2 in collidableObjects)
                {
                    if (obj1 != obj2)
                    {
                        float distance = (obj1.Position - obj2.Position).Length();
                        if (distance <= obj1.Radius + obj2.Radius)
                        {
                            obj1.Collide(state, (obj2 as GameObject)!);
                        }
                    }
                }
            }
        }
    }
}
