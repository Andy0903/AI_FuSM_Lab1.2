using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AI_FuSM_Lab1._2
{
    class Bullet : Entity
    {
        Actor myTarget;
        float mySpeed;

        public bool HasCollided { get; private set; }

        public Bullet(Vector2 aPosition, Color aColor, Actor aTarget) : base("Bullet", aPosition)
        {
            Color = aColor;
            mySpeed = 0.2f;
            myTarget = aTarget;
        }

        public void Update(GameTime aGameTime)
        {
            Collision();
            Vector2 direction = GetDirection();

            float newPositionX = Position.X + (mySpeed * direction.X * aGameTime.ElapsedGameTime.Milliseconds);
            float newPositionY = Position.Y + (mySpeed * direction.Y * aGameTime.ElapsedGameTime.Milliseconds);
            Position = new Vector2(newPositionX, newPositionY);
            
        }

        private Vector2 GetDirection()
        {
            Vector2 direction = (myTarget.Position - Position);
            direction.Normalize();

            return direction;
        }

         private void Collision()
        {
            if (Hitbox.Intersects(myTarget.Hitbox))
            {
                myTarget.TakeDamage(10);
                HasCollided = true;
            }
        }
    }
}
