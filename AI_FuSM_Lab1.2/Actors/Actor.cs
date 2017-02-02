using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AI_FuSM_Lab1._2
{
    abstract class Actor : Entity
    {
        protected List<Bullet> myBullets = new List<Bullet>();
        public float mySpeed = 0.1f;
        public Actor myTarget;

        public bool InsideWindow(Vector2 aPos)
        {
                return 0 < aPos.Y && aPos.Y < Game1.myGraphics.PreferredBackBufferHeight
                      && 0 < aPos.X && aPos.X < Game1.myGraphics.PreferredBackBufferWidth;
        }

        public Actor(string aFileName, Vector2 aPosition) : base(aFileName, aPosition)
        {
        }

        public virtual void TakeDamage(int aDmg)
        {   
        }

        public void Shoot()
        {
            myBullets.Add(new Bullet(Position, Color, myTarget));
        }

        public virtual void Update(GameTime aGameTime)
        {
            for (int i = myBullets.Count - 1; i >= 0; i--)
            {
                if (myBullets[i].HasCollided == true)
                {
                    myBullets.RemoveAt(i);
                }
                else
                {
                    myBullets[i].Update(aGameTime);
                }
            }
        }

    }
}
