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
        float myActVal;
        protected float ActivationValue { get { return myActVal; } set { MathHelper.Clamp(myActVal, 0, 1); } }

        public abstract void Execute(float aActivationValue);
    }
}
