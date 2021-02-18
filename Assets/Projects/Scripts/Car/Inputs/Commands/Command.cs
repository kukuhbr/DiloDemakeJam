using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NFS.Car.Movements;

namespace NFS.Car.Inputs.Commands
{
    public abstract class Command
    {
        protected CarMovement movement;
        protected float timeInput;
        protected float valueInput;

        public Command(CarMovement movementInput)
        {
            movement = movementInput;
        }

        public abstract void Execute(float input);

        public float GetTimeInput()
        {
            return timeInput;
        }

        public float GetValueInput()
        {
            return valueInput;
        }
    }
}