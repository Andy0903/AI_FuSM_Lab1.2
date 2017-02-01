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
        State myState;
        SpriteFont myFont;

        int myHealth;
        int myMaxHealth;

        int myAmmo;
        int myMaxAmmo;


        public Enemy(Vector2 aPosition) : base("Box", aPosition)
        {
            myHealth = myMaxHealth = 100;
            myAmmo = myMaxAmmo = 25;

            Color = Color.Blue;
            myFont = Game1.myContentManager.Load<SpriteFont>("Font");
        }

        public override void Update(GameTime aGameTime)
        {
            myState = DetermineState();

            myState.Execute();
        }

        private State DetermineState()
        {
            return new SAttack();
        }

        public override void Draw(SpriteBatch aSpriteBatch)
        {
            aSpriteBatch.DrawString(myFont, myHealth + "/" + myMaxHealth, new Vector2(Position.X, Position.Y - 60), Color.Red);
            aSpriteBatch.DrawString(myFont, myAmmo + "/" + myMaxAmmo, new Vector2(Position.X, Position.Y - 30), Color.Black);

            base.Draw(aSpriteBatch);
        }
    }
}
