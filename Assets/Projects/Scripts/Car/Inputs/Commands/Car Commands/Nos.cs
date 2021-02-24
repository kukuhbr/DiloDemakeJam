using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NFS.Car.Movements;

namespace NFS.Car.Inputs.Commands
{
    public class Nos : Command
    {
        public Nos(CarMovement movementInput) : base(movementInput)
        {

        }

        public override void Execute(float input)
        {
            valueInput = input;
            movement.nos.ApplyNos(input);
        }
    }
}
