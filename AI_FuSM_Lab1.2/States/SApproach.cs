using Microsoft.Xna.Framework;
using System;

namespace AI_FuSM_Lab1._2
{
    class SApproach : State
    {
        public override float CalculateUrgency(Enemy aMe)
        {
            const float WEIGHT = 0.1f;
            float urgency = 1f - Vector2.Distance(aMe.Position, aMe.myTarget.Position) / (aMe.Health * aMe.Ammo * WEIGHT);

            urgency = MathHelper.Clamp(urgency, 0, 1);

            return urgency;
        }

        public override void Execute(Enemy aMe, float aUrgency, GameTime aGameTime)
        {
            Vector2 wantToMove = Vector2.Zero;

            Vector2 direction = Vector2.Normalize(aMe.myTarget.Position - aMe.Position);
            wantToMove = direction * aMe.mySpeed;

            if (aMe.InsideWindow(aMe.Position += wantToMove))
            {
                aMe.Position += wantToMove;
            }
        }
    }
}
