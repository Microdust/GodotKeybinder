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

        public MouseDevice(ActionInput[] allActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();

            for (int i = DeviceActions.Length - 1; i >= 0; i--)
            {
                if (DeviceActions[i].MouseBinding != null)
                {
                    tempAction.Add(DeviceActions[i]);
                }
            }

            DeviceActions = tempAction.ToArray();
        }

        public override void Tick()
        {
            for (int i = DeviceActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref DeviceActions[i].IsTriggered;
                IsTriggered = false;
                currentBinding = DeviceActions[i].MouseBinding;

                for (int j = currentBinding.Length - 1; j >= 0; j--)
                {
                    IsTriggered = Input.IsKeyPressed(currentBinding[j].Key);
                }
            }
        }
    }
}
