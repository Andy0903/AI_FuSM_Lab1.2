using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AI_FuSM_Lab1._2
{
    class HealthPack : Pickup
    {
        public HealthPack(Vector2 aPosition) : base("HealthPack", aPosition)
        {
        }
    }
}
