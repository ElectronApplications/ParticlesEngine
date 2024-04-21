using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Controllers;
using TaskParticles.Engine.Objects;

namespace TaskParticles.Engine
{
    class ParticlesEngine
    {
        public Random rng;

        public List<GameObject> GameObjects;
        public List<GameController> GameControllers;
        public int Width { get; set; }
        public int Height { get; set; }

        public ParticlesEngine(int width, int height)
        {
            rng = new Random();
            Width = width;
            Height = height;
            GameObjects = new List<GameObject>();
            GameControllers = new List<GameController>();

            GameObjects.Add(new SimpleParticle(new Vector2(width/2, height/2), Vector2.Zero, 1000));
            GameControllers.Add(new GravityController());
        }

        public void SpawnParticle(Vector2 Position, Vector2 Velocity)
        {
            GameObjects.Add(new SimpleParticle(Position, Velocity, rng.Next(1, 10)));
        }

        public void Tick()
        {
            foreach (var obj in GameObjects)
            {
                obj.Tick();
            }

            foreach (var controller in GameControllers)
            {
                GameObjects = controller.Tick(GameObjects);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var drawableObject in GameObjects.Select(obj => obj as IDrawable))
            {
                if (drawableObject != null)
                {
                    g.Transform = drawableObject.GetTransform();
                    drawableObject.Render(g);
                }
            }
        }
    }
}
