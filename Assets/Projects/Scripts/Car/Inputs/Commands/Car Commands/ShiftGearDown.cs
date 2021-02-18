using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Car.Inputs.Commands
{
    class ShiftGearDown : Command
    {
        public override void Execute(float input)
        {
            valueInput = input;
        }
    }
}
