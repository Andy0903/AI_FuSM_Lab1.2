using Microsoft.Xna.Framework;
using System;

namespace AI_FuSM_Lab1._2
{
    class SAttack : State
    {
        float myLastShotTime;

        public override float CalculateUrgency(Enemy aMe)
        {
            float missingHP = aMe.MaxHealth - aMe.Health;

            float urgency = 1f - Vector2.Distance(aMe.Position, aMe.myTarget.Position) / (missingHP * aMe.Ammo);

            urgency = MathHelper.Clamp(urgency, 0, 1);

            return urgency;
        }

        public override void Execute(Enemy aMe, float aUrgency, GameTime aGameTime)
        {
            if (0 < aMe.Ammo && TimeToShoot(aGameTime))
            {
                aMe.Shoot();
                aMe.Ammo--;
                myLastShotTime = (float)aGameTime.TotalGameTime.TotalSeconds;
            }
        }

        private bool TimeToShoot(GameTime aGameTime)
        {
            float cooldown = 0.5f;
            if (myLastShotTime + cooldown <= aGameTime.TotalGameTime.TotalSeconds)
            {
                return true;
            }

            return false;
        }
    }
}
