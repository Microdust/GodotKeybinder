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
             
        public FullDesktopDevice(ActionInput[] AllActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();
            List<ActionInput> tempMouseAction = new List<ActionInput>();       

            for (int i = AllActions.Length - 1; i >= 0; i--)
            {
                if (AllActions[i].KeyboardBinding != null)
                {
                    tempAction.Add(AllActions[i]);
                }
                if (AllActions[i].MouseBinding != null)
                {
                    tempMouseAction.Add(AllActions[i]);
                }
            }

            deviceActions = tempAction.ToArray();
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

            for (int i = deviceActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref deviceActions[i].IsTriggered;
                ref float State = ref deviceActions[i].State;

                IsTriggered = false;
                State = 0f;

                currentKeyboardBinding = deviceActions[i].KeyboardBinding;

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
