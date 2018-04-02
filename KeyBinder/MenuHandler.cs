using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1.InputController;


namespace test1
{
    public class MenuHandler : Control
    {
        private Panel RebindPanel;
        private ActionInput[] AllActions;

        public override void _Ready()
        {
            AllActions = InputManager.GetActions();
            GetChild(0).Connect("pressed", this, "ChangeKey");
            RebindPanel = (Panel)GetChild(1);
            RebindPanel.Visible = false;

            SetupRebindPanel();

            base._Ready();
        }

        public void SetupRebindPanel()
        {
            GridContainer Container = new GridContainer()
            {
                Columns = 2,
            };

            Container.AddConstantOverride("hseparation", 25);
            Container.AddConstantOverride("vseparation", 5);

            RebindPanel.GetChild(0).AddChild(Container);

            Container.AddChild(new Label() { Text = "Action"});
            Container.AddChild(new Label() { Text = "Keyboard" });


            for (int i = 0; i < AllActions.Length; i++)
            {
                if (AllActions[i].KeyboardBinding != null)
                {
                    for (int j = 0; j < AllActions[i].KeyboardBinding.Length; j++)
                    {
                        Container.AddChild(new Label() { Text = AllActions[i].KeyboardBinding[j].Name });
                        Container.AddChild(new Button() { Text = ((KeyList)(AllActions[i].KeyboardBinding[j].Key)).ToString()  });
                    }
                }
            }
        }

        private void ChangeKey()
        {
            if (!RebindPanel.Visible)
            {
                RebindPanel.Visible = true;
            }
            else
            {
                RebindPanel.Visible = false;
            }
            
           //InputManager.RebindKey(DeviceType.Keyboard, 0, 0, (int)KeyList.Y);
        }


    }
}
