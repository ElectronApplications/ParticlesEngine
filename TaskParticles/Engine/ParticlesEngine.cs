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
        public Vector2 Translation { get; set; } = Vector2.Zero;
        public float Scale { get; set; } = 1.0f;
        public float ScaleVelocity { get; set; } = 0.0f;

        private bool isMouseDown = false;
        private Vector2 mousePrevious;

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

        public IEnumerable<IPreTransformable> PreTransformables
        {
            get => GameObjects.Select(obj => obj as IPreTransformable).Where(obj => obj != null).Select(obj => obj!);
        }

        public IEnumerable<IPostTransformable> PostTransformables
        {
            get => GameObjects.Select(obj => obj as IPostTransformable).Where(obj => obj != null).Select(obj => obj!);
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
            Scale += Scale*ScaleVelocity/10.0f;
            ScaleVelocity -= ScaleVelocity*0.25f;

            Scale = Math.Min(4.0f, Scale);
            Scale = Math.Max(0.1f, Scale);

            g.Clear(Color.Black);
            foreach (var drawableObject in DrawableObjects.OrderByDescending(obj => obj.RenderPriority).ToList())
            {
                Matrix matrix = new Matrix();

                foreach (var preTransformable in PreTransformables)
                {
                    preTransformable.Transform(matrix, (drawableObject as GameObject)!);
                }

                matrix.Translate(Width / 2, Height / 2);
                matrix.Scale(Scale, Scale);

                drawableObject.GetTransform(matrix);
                matrix.Translate(Translation.X, Translation.Y);

                foreach (var postTransformable in PostTransformables)
                {
                    postTransformable.Transform(matrix, (drawableObject as GameObject)!);
                }
                try
                {
                    g.Transform = matrix;
                }
                catch { }

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
            } else
            {
                isMouseDown = true;
                mousePrevious = new Vector2(x, y);
            }
        }

        public void MouseMove(int x, int y)
        {
            foreach (var mouseTool in LeftMouseTools)
            {
                mouseTool.MouseMove(x, y, this);
            }
            if (isMouseDown)
            {
                Translation += (new Vector2(x, y) - mousePrevious) / Scale;
                mousePrevious = new Vector2(x, y);
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
            } else
            {
                isMouseDown = false;
            }
        }

        public void MouseWheel(int delta)
        {
            ScaleVelocity += delta/100.0f;
        }
    }
}
