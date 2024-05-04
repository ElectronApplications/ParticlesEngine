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

        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> gameObjectsAddQueue = new List<GameObject>();


        public IEnumerable<GameObject> GameObjects { get => gameObjects; }

        public IEnumerable<GameController> GameControllers
        {
            get => GameObjects.Select(obj => obj as GameController).Where(obj => obj != null).Select(obj => obj!);
        }

        public IEnumerable<LeftMouseTool> LeftMouseTools
        {
            get => GameObjects.Select(obj => obj as LeftMouseTool).Where(obj => obj != null).Select(obj => obj!);
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
        }

        public void AddObject(GameObject gameObject)
        {
            gameObjectsAddQueue.Add(gameObject);
        }

        public void RemoveObject(GameObject gameObject)
        {
            gameObject.Alive = false;
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

            gameObjects.AddRange(gameObjectsAddQueue);
            gameObjectsAddQueue.Clear();

            gameObjects.RemoveAll(obj => !obj.Alive);
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.Black);
            foreach (var drawableObject in DrawableObjects.OrderByDescending(obj => obj.RenderPriority).ToList())
            {
                Matrix preMatrix = new Matrix();
                g.Transform = drawableObject.GetTransform(preMatrix);
                drawableObject.Render(g);
            }
        }

        public void MouseDown(int x, int y, MouseButtons button)
        {
            if (button == MouseButtons.Left)
            {
                foreach (var mouseTool in LeftMouseTools)
                {
                    mouseTool.MouseDown(x, y, this);
                }
            }
        }

        public void MouseMove(int x, int y)
        {
            foreach (var mouseTool in LeftMouseTools)
            {
                mouseTool.MouseMove(x, y, this);
            }
        }

        public void MouseUp(int x, int y, MouseButtons button)
        {
            if (button == MouseButtons.Left)
            {
                foreach (var mouseTool in LeftMouseTools)
                {
                    mouseTool.MouseUp(x, y, this);
                }
            }
        }
    }
}
