using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Car.Inputs.Commands
{
    public class HandBrake : Command
    {
        public override void Execute(float input)
        {
            valueInput = input;
        }
    }
}
