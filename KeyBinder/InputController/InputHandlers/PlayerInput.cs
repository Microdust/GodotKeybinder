using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1.InputController.Devices;

namespace test1.InputController
{
    internal abstract class PlayerInput : Node
    {
        protected ActionInput[] AllActions;
        private BaseDevice device;

        public PlayerInput(BaseDevice device, ActionInput[] actions)
        {
            this.device = device;
            this.AllActions = actions;
        }


        public override void _Process(float delta)
        {
            device.Tick();
        }

        public abstract Vector2 GetAxisSigned2D(int xAxis, int yAxis);
        public abstract Vector2 GetAxis2D(int xAxis, int yAxis);
        public abstract bool GetAction(int actionId);

    }
}
