using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using test1.InputController.Devices;

namespace test1.InputController
{
    internal class PlayerKeyboard : PlayerInput
    {
        public PlayerKeyboard(ActionInput[] Actions) : base (new KeyboardDevice(Actions), Actions)
        {

        }

        public override Vector2 GetAxis2D(int xAxis, int yAxis)
        {
            return new Vector2(AllActions[xAxis].State, AllActions[yAxis].State);
        }

        public override Vector2 GetAxisSigned2D(int xAxis, int yAxis)
        {
            return new Vector2(AllActions[xAxis].State, AllActions[yAxis].State);
        }

        public override bool GetAction(int actionId)
        {
            return AllActions[actionId].State != 0 ? true : false;
        }
    }
}
