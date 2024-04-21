using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Objects;

namespace TaskParticles.Engine.Controllers
{
    class GravityController : GameController
    {
        public float G { get; set; }

        public GravityController()
        {
            G = 1;
        }

        public GravityController(float g)
        {
            G = g;
        }

        public override List<GameObject> Tick(List<GameObject> gameObjects)
        {
            var attractableObjects = gameObjects.Select(obj => obj as IAttractable).Where(obj => obj != null).Select(obj => obj!);

            foreach (var obj1 in attractableObjects)
            {
                foreach (var obj2 in attractableObjects)
                {
                    if (obj1 != obj2)
                    {
                        float distance = (obj1.Position - obj2.Position).Length();
                        if (distance > 10)
                        {
                            float forceAbs = G * obj1.Mass * obj2.Mass / (obj1.Position - obj2.Position).LengthSquared();
                            var normalized = (obj1.Position - obj2.Position) / distance;
                            obj1.ApplyForce(-normalized * forceAbs);
                            obj2.ApplyForce(normalized * forceAbs);
                        }
                    }
                }
            }

            return gameObjects;
        }
    }
}
