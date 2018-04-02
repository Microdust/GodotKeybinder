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

        public GamePadDevice(ActionInput[] AllActions)
        {
            List<ActionInput> tempAction = new List<ActionInput>();
            List<ActionInput> tempButtonAction = new List<ActionInput>();

            for (int i = AllActions.Length - 1; i >= 0; i--)
            {
                currentBinding = AllActions[i].GamePadBinding;

                if (currentBinding != null)
                {
                    for (int j = currentBinding.Length - 1; j >= 0; j--)
                    {
                        if (currentBinding[j].Analog)
                        {
                            tempAction.Add(AllActions[i]);
                        }
                        else
                        {
                            tempButtonAction.Add(AllActions[i]);
                        }
                    }                       
                }
            }
            buttonActions = tempButtonAction.ToArray();
            deviceActions = tempAction.ToArray();
        }

        public override void Tick()
        {
            for (int i = deviceActions.Length - 1; i >= 0; i--)
            {
                ref float state = ref deviceActions[i].State;
                currentBinding = deviceActions[i].GamePadBinding;

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
