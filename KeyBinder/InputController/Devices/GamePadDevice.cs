using Godot;
using System;
using System.Collections.Generic;

namespace test1.InputController.Devices
{
    internal sealed class GamePadDevice : BaseDevice
    {
        private int playerIndex = 0;
        private GamePadBinding[] currentBinding;
        private ActionInput[] buttonActions;

        public GamePadDevice(ActionInput[] allActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();
            List<ActionInput> tempButtonAction = new List<ActionInput>();

            for (int i = allActions.Length - 1; i >= 0; i--)
            {
                currentBinding = allActions[i].GamePadBinding;

                if (currentBinding != null)
                {
                    for (int j = currentBinding.Length - 1; j >= 0; j--)
                    {
                        if (currentBinding[j].Analog)
                        {
                            tempAction.Add(allActions[i]);
                        }
                        else
                        {
                            tempButtonAction.Add(allActions[i]);
                        }
                    }                       
                }
            }
            buttonActions = tempButtonAction.ToArray();
            DeviceActions = tempAction.ToArray();
        }

        public override void Tick()
        {
            for (int i = DeviceActions.Length - 1; i >= 0; i--)
            {
                ref float state = ref DeviceActions[i].State;
                currentBinding = DeviceActions[i].GamePadBinding;

                for (int j = currentBinding.Length - 1; j >= 0; j--)
                {               
                    state = Input.GetJoyAxis(playerIndex, currentBinding[j].Key);   
                }             
            }

            for (int i = buttonActions.Length - 1; i >= 0; i--)
            {
                ref bool IsTriggered = ref buttonActions[i].IsTriggered;
                currentBinding = buttonActions[i].GamePadBinding;

                for (int j = currentBinding.Length - 1; j >= 0; j--)
                {
                    IsTriggered = Input.IsJoyButtonPressed(playerIndex, currentBinding[j].Key);
                }
            }
        }
    }
}
