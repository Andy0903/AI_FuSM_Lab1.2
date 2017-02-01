using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_FuSM_Lab1._2
{
    static class InputManager
    {
        static public bool ActionClick
        {
            get { return KeyboardUtility.WasClicked(Keys.Space); }
        }

        static public bool UserInputUpClick
        {
            get { return KeyboardUtility.WasClicked(Keys.W) || KeyboardUtility.WasClicked(Keys.Up); }
        }

        static public bool Up
        {
            get { return KeyboardUtility.IsHeldDown(Keys.W) || KeyboardUtility.IsHeldDown(Keys.Up); }
        }

        static public bool Left
        {
            get { return KeyboardUtility.IsHeldDown(Keys.A) || KeyboardUtility.IsHeldDown(Keys.Left); }
        }

        static public bool Down
        {
            get { return KeyboardUtility.IsHeldDown(Keys.S) || KeyboardUtility.IsHeldDown(Keys.Down); }
        }

        static public bool Right
        {
            get { return KeyboardUtility.IsHeldDown(Keys.D) || KeyboardUtility.IsHeldDown(Keys.Right); }
        }
    }
}
