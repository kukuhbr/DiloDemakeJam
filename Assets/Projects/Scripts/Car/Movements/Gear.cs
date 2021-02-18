using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Movements
{
    public class Gear
    {
        private int gearNumber;
        private float maxTorque;

        public Gear(int gearInput, float maxTorqueInput)
        {
            gearNumber = gearInput;
            maxTorque = maxTorqueInput;
        }

        public int GetGearNumber()
        {
            return gearNumber;
        }

        public float GetMaxTorque()
        {
            return maxTorque;
        }

        public bool IsMaxTorque(float torque)
        {
            return torque >= maxTorque;
        }
    }
}