using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_FuSM_Lab1._2
{
    static class KeyboardUtility
    {
        static KeyboardState myOldKeyboardState;
        static KeyboardState myNewKeyboardState;

        static public bool WasClicked(Keys aKey)
        {
            return myOldKeyboardState.IsKeyUp(aKey) && myNewKeyboardState.IsKeyDown(aKey);
        }

        static public bool IsHeldDown(Keys aKey)
        {
            return myOldKeyboardState.IsKeyDown(aKey) && myNewKeyboardState.IsKeyDown(aKey);
        }

        static public void Update()
        {
            myOldKeyboardState = myNewKeyboardState;
            myNewKeyboardState = Keyboard.GetState();
        }
    }
}
