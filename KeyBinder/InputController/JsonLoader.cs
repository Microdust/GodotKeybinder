using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace test1.InputController
{
    public sealed class JsonLoader : IDisposable
    {
        private string defaultPath = @"res://InputController/Bindings.json";      

        private BindingSetting[] GetBindings()
        {
            using (File file = new File())
            {
                file.Open(defaultPath, (int)File.ModeFlags.Read);
    
                return JsonConvert.DeserializeObject<BindingSetting[]>(file.GetAsText());    
            }

        }

        internal ActionInput[] GetBindingActions()
        {
            BindingSetting[] actions = GetBindings();
            ActionInput[] actionInputs = new ActionInput[actions.Length];

            for (int i = actions.Length - 1; i >= 0; i--)
            {
                actionInputs[i] = new ActionInput(actions[i]);
            }

            return actionInputs;
        }

        internal void SaveBindings(ActionInput[] actions)
        {
            string json = JsonConvert.SerializeObject(actions, Formatting.Indented);

            string debugLoc = @"c:\temp\KeyBindings.json";
        }

        public void Dispose()
        {
            defaultPath = null;
        }
    }
}

