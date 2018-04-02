using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace test1.InputController
{
    public struct GamePadState
    {

        public readonly bool ButtonA;
        public readonly bool ButtonB;
        public readonly bool ButtonX;
        public readonly bool ButtonY;

        public readonly bool ButtonLeft;
        public readonly bool ButtonRight;
        public readonly bool ButtonUp;
        public readonly bool ButtonDown;

        public readonly Vector2 LeftAnalog;
        public readonly Vector2 RightAnalog;

        public GamePadState(int playerIndex)
        {
            ButtonA = Input.IsJoyButtonPressed(playerIndex, 0);
            ButtonB = Input.IsJoyButtonPressed(playerIndex, 1);
            ButtonX = Input.IsJoyButtonPressed(playerIndex, 2);
            ButtonY = Input.IsJoyButtonPressed(playerIndex, 3);
            ButtonLeft = Input.IsJoyButtonPressed(playerIndex, 14);
            ButtonRight = Input.IsJoyButtonPressed(playerIndex, 15);
            ButtonUp = Input.IsJoyButtonPressed(playerIndex, 12);
            ButtonDown = Input.IsJoyButtonPressed(playerIndex, 13);

            LeftAnalog.x = Input.GetJoyAxis(playerIndex, 0);
            LeftAnalog.y = Input.GetJoyAxis(playerIndex, 1);
            RightAnalog.x = Input.GetJoyAxis(playerIndex, 2);
            RightAnalog.y = Input.GetJoyAxis(playerIndex, 3);
        }


    }
}
