using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskParticles.Engine.Controllers;
using TaskParticles.Engine.Interfaces;
using TaskParticles.Engine.Particles;

namespace TaskParticles.Engine
{
    public class ParticlesEngine
    {
        public Random rng;

        public int Width { get; set; }
        public int Height { get; set; }

        public List<GameObject> GameObjects;

        public IEnumerable<GameController> GameControllers
        {
            get => GameObjects.Select(obj => obj as GameController).Where(obj => obj != null).Select(obj => obj!);
        }

        public IEnumerable<IDrawable> DrawableObjects
        {
            get => GameObjects.Select(obj => obj as IDrawable).Where(obj => obj != null).Select(obj => obj!);
        }

        public ParticlesEngine(int width, int height)
        {
            rng = new Random();
            Width = width;
            Height = height;
            GameObjects = new List<GameObject>();

            GameObjects.Add(new SimpleParticle(new Vector2(width/2, height/2), Vector2.Zero, 1000));
            GameObjects.Add(new GravityController());
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
                controller.ControllerTick(this);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var drawableObject in DrawableObjects)
            {
                Matrix preMatrix = new Matrix();
                g.Transform = drawableObject.GetTransform(preMatrix);
                drawableObject.Render(g);
            }
        }
    }
}
