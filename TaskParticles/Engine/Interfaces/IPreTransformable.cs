using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine.Interfaces
{
    public interface IPreTransformable
    {
        void Transform(Matrix matrix, GameObject gameObject);
    }
}
