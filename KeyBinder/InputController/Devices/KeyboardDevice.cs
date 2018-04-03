using System;
using System.Collections.Generic;
using Godot;

namespace test1.InputController.Devices
{
    internal class KeyboardDevice : BaseDevice
    {
        private KeyboardBinding[] currentBinding;
        
        public KeyboardDevice(ActionInput[] allActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();

            for (int i = allActions.Length - 1; i >= 0; i--)
            {
                if (allActions[i].KeyboardBinding != null)
                {
                    tempAction.Add(allActions[i]);
                }
                
            }

            DeviceActions = tempAction.ToArray();
        }

        public override void Tick()
        {
            for (int i = DeviceActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref DeviceActions[i].IsTriggered;
                ref float State = ref DeviceActions[i].State;

                IsTriggered = false;
                State = 0;

                currentBinding = DeviceActions[i].KeyboardBinding;

                for (int j = currentBinding.Length - 1; j >= 0; j--)
                {
                    if (Input.IsKeyPressed(currentBinding[j].Key))
                    {
                        IsTriggered = true;
                        State = currentBinding[j].AxisContribution;
                    }
                }
            }
        }

    }
}
