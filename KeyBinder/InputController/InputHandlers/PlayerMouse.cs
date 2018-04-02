using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using test1.InputController.Devices;

namespace test1.InputController
{
    internal class PlayerMouse : PlayerInput
    {
        public PlayerMouse(ActionInput[] Actions) : base(new MouseDevice(Actions), Actions)
        {
        }

        public override bool GetAction(int actionId)
        {
            return AllActions[actionId].State != 0 ? true : false;
        }

        public override Vector2 GetAxis2D(int xAxis, int yAxis)
        {
            throw new NotImplementedException();
        }

        public override Vector2 GetAxisSigned2D(int xAxis, int yAxis)
        {
            throw new NotImplementedException();
        }
    }
}
