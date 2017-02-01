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
            foreach (Bullet b in myBullets)
            {
                b.Draw(aSpriteBatch);
            }

            base.Draw(aSpriteBatch);
        }

        public override void Update(GameTime aGameTime)
        {
            Shoot();
            Movement(aGameTime);
            foreach (Bullet b in myBullets)
            {
                b.Update(aGameTime);
            }
        }

        private void Shoot()
        {
            if (InputManager.ActionClick)
            {
                myBullets.Add(new Bullet(Position, myDir, Color));
            }
        }

        private void Movement(GameTime aGameTime)
        {
            Vector2 newPosition = Vector2.Zero;
            Direction newDir = Direction.Right;
            if (InputManager.Up)
            {
                newPosition = new Vector2(Position.X, Position.Y - mySpeed * aGameTime.ElapsedGameTime.Milliseconds);
                newDir = Direction.Up;
            }
            if (InputManager.Left)
            {
                newPosition = new Vector2(Position.X - mySpeed * aGameTime.ElapsedGameTime.Milliseconds, Position.Y);
                newDir = Direction.Left;
            }
            if (InputManager.Down)
            {
                newPosition = new Vector2(Position.X, Position.Y + mySpeed * aGameTime.ElapsedGameTime.Milliseconds);
                newDir = Direction.Down;
            }
            if (InputManager.Right)
            {
                newPosition = new Vector2(Position.X + mySpeed * aGameTime.ElapsedGameTime.Milliseconds, Position.Y);
                newDir = Direction.Right;
            }

            if (InsideWindow(newPosition))
            {
                Position = newPosition;
                myDir = newDir;
            }
        }
    }
}
