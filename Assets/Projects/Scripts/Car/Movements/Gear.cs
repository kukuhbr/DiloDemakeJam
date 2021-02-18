using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Movements
{
    public class Gear
    {
        private int gearNumber;
        private float maxRPM;

        public Gear(int gearInput, float maxRPMInput)
        {
            gearNumber = gearInput;
            maxRPM = maxRPMInput;
        }

        public int GetGearNumber()
        {
            return gearNumber;
        }

        public float GetMaxRPM()
        {
            return maxRPM;
        }

        public bool IsMaxRPM(float rpm)
        {
            return rpm >= maxRPM;
        }
    }
}