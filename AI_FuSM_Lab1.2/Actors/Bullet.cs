using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AI_FuSM_Lab1._2
{
    class Bullet : Actor
    {
        public Bullet(Vector2 aPosition, Direction aDir, Color aColor) : base("Bullet", aPosition)
        {
            myDir = aDir;
            Color = aColor;
            mySpeed = 0.2f;
        }

        public void Update(GameTime aGameTime)
        {
            switch (myDir)
            {
                case Direction.Up:
                    Position = new Vector2(Position.X, Position.Y - mySpeed * aGameTime.ElapsedGameTime.Milliseconds);
                    break;
                case Direction.Left:
                    Position = new Vector2(Position.X - mySpeed * aGameTime.ElapsedGameTime.Milliseconds, Position.Y);
                    break;
                case Direction.Down:
                    Position = new Vector2(Position.X, Position.Y + mySpeed * aGameTime.ElapsedGameTime.Milliseconds);
                    break;
                case Direction.Right:
                    Position = new Vector2(Position.X + mySpeed * aGameTime.ElapsedGameTime.Milliseconds, Position.Y);
                    break;
            }
        }
    }
}
