using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using test1.InputController.Devices;

namespace test1.InputController
{
    internal class PlayerGamePad : PlayerInput
    {
        private const float DEADZONE = 0.25f;
        private const float DEADZONE_SQUARED = DEADZONE * DEADZONE;

        private Vector2 vectorZero = new Vector2(0f, 0f);
        private Vector2 vectorTemp = new Vector2(0f, 0f);

        public PlayerGamePad(ActionInput[] Actions) : base(new GamePadDevice(Actions), Actions)
        {
        }

        public override bool GetAction(int actionId)
        {
            return AllActions[actionId].IsTriggered;
        }

        public override Vector2 GetAxis2D(int xAxis, int yAxis)
        {
            vectorTemp.x = AllActions[xAxis].State;
            vectorTemp.y = AllActions[yAxis].State;

            return vectorTemp.LengthSquared() > DEADZONE_SQUARED ? vectorTemp : vectorZero;
        }

        public override Vector2 GetAxisSigned2D(int xAxis, int yAxis)
        {
            vectorTemp.x = 0f;
            vectorTemp.y = 0f;


            if (Mathf.Abs(AllActions[xAxis].State) > DEADZONE)
                vectorTemp.x = AllActions[xAxis].State;

            if (Mathf.Abs(AllActions[yAxis].State) > DEADZONE)
                vectorTemp.y = AllActions[yAxis].State;

            return vectorTemp;
        }
    }
}
