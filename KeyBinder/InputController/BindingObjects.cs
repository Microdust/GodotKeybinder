using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using Newtonsoft.Json;

namespace test1.InputController
{

    public class ActionInput
    {
        public readonly string Action;
        public readonly int Id;
        public float State;
        public bool IsTriggered;
        public readonly KeyboardBinding[] KeyboardBinding;
        public readonly GamePadBinding[] GamePadBinding;
        public readonly MouseBinding[] MouseBinding;

        public ActionInput(BindingSetting settings)
        {
            this.Action = settings.Action;
            this.Id = settings.Id;
            this.KeyboardBinding = settings.KeyboardBinding;
            this.GamePadBinding = settings.GamePadBinding;
            this.MouseBinding = settings.MouseBinding;
        }
    }

    public class BindingSetting
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public KeyboardBinding[] KeyboardBinding { get; set; }
        public GamePadBinding[] GamePadBinding { get; set; }
        public MouseBinding[] MouseBinding { get; set; }
    }

    public class BindingProperties
    {
        public readonly float AxisContribution;
        public int Key;
        public string Name;

        public BindingProperties(int KeyToBind, float AxisContribution, string Name)
        {
            this.Key = KeyToBind;
            this.AxisContribution = AxisContribution;
            this.Name = Name;
        }
    }

    public sealed class KeyboardBinding : BindingProperties
    {      
        [JsonConstructor]
        public KeyboardBinding(KeyList KeyboardKey, float AxisContribution, string Name) : base((int)KeyboardKey, AxisContribution, Name)
        {
        }
    }

    public sealed class GamePadBinding : BindingProperties
    {
        public bool Analog;

        [JsonConstructor]
        public GamePadBinding(JoystickList GamePadKey, float AxisContribution, string Name) : base((int)GamePadKey, AxisContribution, Name)
        {
        }
    }

    public sealed class MouseBinding : BindingProperties
    {

        [JsonConstructor]
        public MouseBinding(ButtonList MouseKey, float AxisContribution, string Name) : base((int)MouseKey, AxisContribution, Name)
        {
        }
    }

}
