using Godot;
using System.Collections.Generic;

namespace test1.InputController
{
    internal static class InputManager
    {
        private static readonly ActionInput[] allActions;
        private static readonly List<PlayerInput> players = new List<PlayerInput>();

        static InputManager()
        {
            using (JsonLoader loader = new JsonLoader())
            {
                allActions = loader.GetBindingActions();       
            }
        }

        public static void Initialize()
        {
            if (!string.IsNullOrWhiteSpace(Input.GetJoyName(0)))
            {
                players.Add(new PlayerGamePad(allActions));
            }
            else
            {
                players.Add(new PlayerFullDesktop(allActions));
            }
        }

        public static PlayerInput GetPlayer(int index)
        {
            return players[index];
        }

        public static ActionInput[] GetActions()
        {
            return allActions;
        }

        public static void RebindKey(DeviceType type, int action, int keyIndex, int newKey)
        {
            switch (type)
            {
                case DeviceType.Keyboard:
                    allActions[action].KeyboardBinding[keyIndex].Key = newKey;
                    break;
                case DeviceType.GamePad:
                    GD.Print(allActions[action].GamePadBinding[keyIndex].Key);
                    allActions[action].GamePadBinding[keyIndex].Key = newKey;
                    break;
                case DeviceType.Mouse:
                    allActions[action].MouseBinding[keyIndex].Key = newKey;
                    break;
            }

        }

    }
}
