using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine.Interfaces
{
    public interface IDrawable
    {
        int RenderPriority { get; set; }

        Matrix GetTransform(Matrix preMatrix);

        void Render(Graphics g);
    }
}
