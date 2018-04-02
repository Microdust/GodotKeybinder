using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.InputController.Devices
{
    internal class MouseDevice : BaseDevice
    {
        private MouseBinding[] currentBinding;

        public MouseDevice(ActionInput[] AllActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();

            for (int i = deviceActions.Length - 1; i >= 0; i--)
            {
                if (deviceActions[i].MouseBinding != null)
                {
                    tempAction.Add(deviceActions[i]);
                }
            }

            deviceActions = tempAction.ToArray();
        }

        public override void Tick()
        {
            for (int i = deviceActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref deviceActions[i].IsTriggered;
                IsTriggered = false;
                currentBinding = deviceActions[i].MouseBinding;

                for (int j = currentBinding.Length - 1; j >= 0; j--)
                {
                    IsTriggered = Input.IsKeyPressed(currentBinding[j].Key);
                }
            }
        }
    }
}
