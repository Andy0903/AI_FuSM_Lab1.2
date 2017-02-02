using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AI_FuSM_Lab1._2
{
    class Enemy : Actor
    {
        List<State> myPossibleStates = new List<State> { new SFlee(), new SApproach(), new SAttack() };
        SpriteFont myFont;

        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Ammo { get; set; }
        public int MaxAmmo { get; set; }
       
        public Enemy(Vector2 aPosition, Player aPlayer) : base("Box", aPosition)
        {
            Health = MaxHealth = 100;
            Ammo = MaxAmmo = 25;
            myTarget = aPlayer;
            Color = Color.Blue;
            myFont = Game1.myContentManager.Load<SpriteFont>("Font");
        }

        public override void Update(GameTime aGameTime)
        {
            foreach (State s in myPossibleStates)
            {
                float urgency = s.CalculateUrgency(this);
                if (urgency > 0)
                {
                    s.Execute(this, urgency, aGameTime);
                }
            }

            base.Update(aGameTime);
        }

        public override void TakeDamage(int aDmg)
        {
            if (0 < Health)
            {
                Health -= aDmg;
            }
        }

        public override void Draw(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, Health + "/" + MaxHealth, new Vector2(Position.X, Position.Y - 60), Color.Red);
            aSpriteBatch.DrawString(myFont, Ammo + "/" + MaxAmmo, new Vector2(Position.X, Position.Y - 30), Color.Black);

            foreach (Bullet b in myBullets)
            {
                b.Draw(aSpriteBatch);
            }

            base.Draw(aSpriteBatch);
        }
    }
}
