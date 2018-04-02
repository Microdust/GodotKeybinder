﻿using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1.InputController.Devices;

namespace test1.InputController
{
    internal abstract class PlayerInput : Node
    {
        protected ActionInput[] AllActions;
        private BaseDevice device;

        public PlayerInput(BaseDevice device, ActionInput[] Actions)
        {
            this.device = device;
            this.AllActions = Actions;
        }


        public override void _Process(float delta)
        {
            device.Tick();
            base._Process(delta);
        }

        public abstract Vector2 GetAxisSigned2D(int xAxis, int yAxis);
        public abstract Vector2 GetAxis2D(int xAxis, int yAxis);
        public abstract bool GetAction(int actionId);

    }
}
