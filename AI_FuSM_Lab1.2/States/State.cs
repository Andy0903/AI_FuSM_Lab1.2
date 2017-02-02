using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_FuSM_Lab1._2
{
    abstract class State
    {
        public abstract float CalculateUrgency(Enemy aMe);
        public abstract void Execute(Enemy aMe, float aUrgency, GameTime aGameTime);
    }
}
