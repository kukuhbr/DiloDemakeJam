using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NFS.Car.Movements;

namespace NFS.Car.Inputs.Commands
{
    class ShiftGearDown : Command
    {
        public ShiftGearDown(CarMovement movementInput) : base(movementInput)
        {

        }

        public override void Execute(float input)
        {
            valueInput = input;
        }
    }
}
