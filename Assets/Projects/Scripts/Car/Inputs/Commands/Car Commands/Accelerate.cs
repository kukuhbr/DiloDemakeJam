using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NFS.Car.Movements;

namespace NFS.Car.Inputs.Commands
{
    public class Accelerate : Command
    {
        public Accelerate(CarMovement movementInput) : base(movementInput)
        {

        }

        public override void Execute(float input)
        {
            valueInput = input;
            if (valueInput == 0)
            {
                movement.gearEngine.ReleaseAccelerate();                
            }
            else
            {
                movement.gearEngine.Accelerate(input);
            }
        }
    }
}