﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParticles.Engine.Interfaces
{
    public interface ICollidable : IPositionable
    {
        float Radius { get; set; }
        void Collide(ParticlesEngine state, GameObject otherObject);
    }
}
