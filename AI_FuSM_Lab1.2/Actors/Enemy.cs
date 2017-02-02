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

        int myHealth;
        int myMaxHealth;

        int myAmmo;
        int myMaxAmmo;

        public Player myPlayer;


        public Enemy(Vector2 aPosition, Player aPlayer) : base("Box", aPosition)
        {
            myHealth = myMaxHealth = 100;
            myAmmo = myMaxAmmo = 25;
            myPlayer = aPlayer;
            Color = Color.Blue;
            myFont = Game1.myContentManager.Load<SpriteFont>("Font");
        }

        public void Update(GameTime aGameTime)
        {
            foreach (State s in myPossibleStates)
            {
                float urgency = s.CalculateUrgency(this);
                if (urgency > 0)
                {
                    s.Execute(this, urgency, aGameTime);
                }
            }
        }

        public override void Draw(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, myHealth + "/" + myMaxHealth, new Vector2(Position.X, Position.Y - 60), Color.Red);
            aSpriteBatch.DrawString(myFont, myAmmo + "/" + myMaxAmmo, new Vector2(Position.X, Position.Y - 30), Color.Black);

            base.Draw(aSpriteBatch);
        }
    }
}
