using Godot;
using System.Collections.Generic;

namespace test1.InputController
{
    internal static class InputManager
    {
        private static readonly ActionInput[] AllActions;
        private static readonly List<PlayerInput> Players = new List<PlayerInput>();

        static InputManager()
        {
            using (JsonLoader loader = new JsonLoader())
            {
                AllActions = loader.GetBindingActions();       
            }
        }

        public static void Initialize()
        {
            if (Input.GetJoyName(0) != string.Empty)
            {
                Players.Add(new PlayerGamePad(AllActions));
            }
            else
            {
                Players.Add(new PlayerFullDesktop(AllActions));
            }
        }

        public static PlayerInput GetPlayer(int index)
        {
            return Players[index];
        }

        public static ActionInput[] GetActions()
        {
            return AllActions;
        }

        public static void RebindKey(DeviceType type, int action, int keyIndex, int newKey)
        {
            GD.Print("RebindKey");
            switch (type)
            {
                case DeviceType.Keyboard:
                    AllActions[action].KeyboardBinding[keyIndex].Key = newKey;
                    break;
                case DeviceType.GamePad:
                    GD.Print(AllActions[action].GamePadBinding[keyIndex].Key);
                    AllActions[action].GamePadBinding[keyIndex].Key = newKey;
                    break;
                case DeviceType.Mouse:
                    AllActions[action].MouseBinding[keyIndex].Key = newKey;
                    break;
            }

        }

    }
}
