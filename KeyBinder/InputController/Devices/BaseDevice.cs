using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.InputController.Devices
{
    internal abstract class BaseDevice
    {
        protected ActionInput[] deviceActions;

        public BaseDevice()
        {
        }


        public abstract void Tick();

    }
}
