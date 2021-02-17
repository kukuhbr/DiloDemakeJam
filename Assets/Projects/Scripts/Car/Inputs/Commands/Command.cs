using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Inputs.Commands
{
    public abstract class Command
    {
        public abstract void Execute();
    }
}