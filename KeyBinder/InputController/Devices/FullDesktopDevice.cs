using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.InputController.Devices
{
    internal class FullDesktopDevice : BaseDevice
    {
        private KeyboardBinding[] currentKeyboardBinding;
        private MouseBinding[] currentMouseBinding;
        private ActionInput[] mouseActions;
             
        public FullDesktopDevice(ActionInput[] allActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();
            List<ActionInput> tempMouseAction = new List<ActionInput>();       

            for (int i = allActions.Length - 1; i >= 0; i--)
            {
                if (allActions[i].KeyboardBinding != null)
                {
                    tempAction.Add(allActions[i]);
                }
                if (allActions[i].MouseBinding != null)
                {
                    tempMouseAction.Add(allActions[i]);
                }
            }

            DeviceActions = tempAction.ToArray();
            mouseActions = tempMouseAction.ToArray();
        }

        public override void Tick()
        {

            for (int i = mouseActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref mouseActions[i].IsTriggered;
                ref float State = ref mouseActions[i].State;

                IsTriggered = false;
                State = 0f;

                currentMouseBinding = mouseActions[i].MouseBinding;

                for (int j = currentMouseBinding.Length - 1; j >= 0; j--)
                {
                    if (Input.IsMouseButtonPressed(currentMouseBinding[j].Key))
                    {
                        IsTriggered = true;
                        State = currentMouseBinding[j].AxisContribution;
                    }
                }
            }

            for (int i = DeviceActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref DeviceActions[i].IsTriggered;
                ref float State = ref DeviceActions[i].State;

                IsTriggered = false;
                State = 0f;

                currentKeyboardBinding = DeviceActions[i].KeyboardBinding;

                for (int j = currentKeyboardBinding.Length - 1; j >= 0; j--)
                {
                    if (Input.IsKeyPressed(currentKeyboardBinding[j].Key))
                    {
                        IsTriggered = true;
                        State = currentKeyboardBinding[j].AxisContribution;
                    }                  
                }
            }

        }
    }
}
