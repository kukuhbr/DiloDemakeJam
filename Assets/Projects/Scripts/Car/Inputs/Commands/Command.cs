using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Inputs.Commands
{
    public abstract class Command
    {
        protected float timeInput;
        protected float valueInput;

        public abstract void Execute();
    }
}