using System;
using System.Collections.Generic;
using Godot;

namespace test1.InputController.Devices
{
    internal class KeyboardDevice : BaseDevice
    {
        private KeyboardBinding[] currentBinding;
        
        public KeyboardDevice(ActionInput[] AllActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();

            for (int i = AllActions.Length - 1; i >= 0; i--)
            {
                if (AllActions[i].KeyboardBinding != null)
                {
                    tempAction.Add(AllActions[i]);
                }
                
            }

            deviceActions = tempAction.ToArray();
        }

        public override void Tick()
        {
            for (int i = deviceActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref deviceActions[i].IsTriggered;
                ref float State = ref deviceActions[i].State;

                IsTriggered = false;
                State = 0;

                currentBinding = deviceActions[i].KeyboardBinding;

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
