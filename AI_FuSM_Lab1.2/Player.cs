using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AI_FuSM_Lab1._2
{
    class Player : Actor
    {
        public Player(Vector2 aPosition) : base("Box", aPosition)
        {
            Color = Color.Red;
        }

        public override void Draw(SpriteBatch aSpriteBatch)
        {
            base.Draw(aSpriteBatch);
        }

        public override void Update(GameTime aGameTime)
        {
            Movement(aGameTime);
        }

        private void Movement(GameTime aGameTime)
        {
            Vector2 newPosition = Vector2.Zero;
            if (InputManager.Up)
            {
                newPosition = new Vector2(Position.X, Position.Y - mySpeed * aGameTime.ElapsedGameTime.Milliseconds);
            }
            if (InputManager.Left)
            {
                newPosition = new Vector2(Position.X - mySpeed * aGameTime.ElapsedGameTime.Milliseconds, Position.Y);
            }
            if (InputManager.Down)
            {
                newPosition = new Vector2(Position.X, Position.Y + mySpeed * aGameTime.ElapsedGameTime.Milliseconds);
            }
            if (InputManager.Right)
            {
                newPosition = new Vector2(Position.X + mySpeed * aGameTime.ElapsedGameTime.Milliseconds, Position.Y);
            }

            if (InsideWindow(newPosition))
            {
                Position = newPosition;
            }
        }
    }
}
