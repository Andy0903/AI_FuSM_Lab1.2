using Microsoft.Xna.Framework;
using System;

namespace AI_FuSM_Lab1._2
{
    class SFlee : State
    {
        public override float CalculateUrgency(Enemy aMe)
        {
            float safeSpace = 200f;
            float urgency = 1f -Vector2.Distance(aMe.Position, aMe.myPlayer.Position) / safeSpace;

            urgency = MathHelper.Clamp(urgency, 0, 1);

            return urgency;
        }

        public override void Execute(Enemy aMe, float aUrgency, GameTime aGameTime)
        {
            Vector2 wantToMove = Vector2.Zero;

            Vector2 direction = Vector2.Normalize(aMe.Position - aMe.myPlayer.Position);
            wantToMove = direction * aMe.mySpeed;


            if (aMe.InsideWindow(aMe.Position += wantToMove))
            {
                aMe.Position += wantToMove;
            }
        }
    }
}
