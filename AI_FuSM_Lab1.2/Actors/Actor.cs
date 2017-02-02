﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AI_FuSM_Lab1._2
{
    abstract class Actor : Entity
    {
        public enum Direction
        {
            Up,
            Left,
            Down,
            Right
        }
        public Direction myDir = Direction.Right;

        public float mySpeed = 0.1f;
        public bool InsideWindow(Vector2 aPos)
        {
                return 0 < aPos.Y && aPos.Y < Game1.myGraphics.PreferredBackBufferHeight
                      && 0 < aPos.X && aPos.X < Game1.myGraphics.PreferredBackBufferWidth;
        }

        public Actor(string aFileName, Vector2 aPosition) : base(aFileName, aPosition)
        {
        }


    }
}
