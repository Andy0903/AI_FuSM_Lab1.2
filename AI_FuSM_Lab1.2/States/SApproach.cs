using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_FuSM_Lab1._2
{
    class SApproach : State
    {
        public override void Execute(float aActivationValue)
        {
            ActivationValue = aActivationValue;
        }
    }
}
