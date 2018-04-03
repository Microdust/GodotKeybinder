using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.InputController.Devices
{
    internal abstract class BaseDevice
    {
        protected ActionInput[] DeviceActions;

        public BaseDevice()
        {
        }


        public abstract void Tick();

    }
}
