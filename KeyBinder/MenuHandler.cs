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
        private Panel rebindPanel;
        private ActionInput[] allActions;

        public override void _Ready()
        {
            allActions = InputManager.GetActions();
            GetChild(0).Connect("pressed", this, "ChangeKey");
            rebindPanel = (Panel)GetChild(1);
            rebindPanel.Visible = false;

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

            rebindPanel.GetChild(0).AddChild(Container);

            Container.AddChild(new Label() { Text = "Action"});
            Container.AddChild(new Label() { Text = "Keyboard" });


            for (int i = 0; i < allActions.Length; i++)
            {
                if (allActions[i].KeyboardBinding != null)
                {
                    for (int j = 0; j < allActions[i].KeyboardBinding.Length; j++)
                    {
                        Container.AddChild(new Label() { Text = allActions[i].KeyboardBinding[j].Name });
                        Container.AddChild(new Button() { Text = ((KeyList)(allActions[i].KeyboardBinding[j].Key)).ToString()  });
                    }
                }
            }
        }

        private void ChangeKey()
        {
            if (!rebindPanel.Visible)
            {
                rebindPanel.Visible = true;
            }
            else
            {
                rebindPanel.Visible = false;
            }
        }


    }
}
