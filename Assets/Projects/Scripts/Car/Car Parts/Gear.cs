using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Parts
{
    public class Gear
    {
        private int gearNumber;
        private float maxSpeed;

        public Gear(int gearInput, float maxSpeedInput)
        {
            gearNumber = gearInput;
            maxSpeed = maxSpeedInput;
        }

        public int GetGearNumber()
        {
            return gearNumber;
        }

        public float GetMaxSpeed()
        {
            return maxSpeed;
        }

        public bool IsMaxSpeed(float speed)
        {
            return speed >= maxSpeed;
        }
    }
}