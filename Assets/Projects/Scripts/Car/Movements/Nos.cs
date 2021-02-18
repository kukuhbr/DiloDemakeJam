using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Car.Movements
{
    public class Nos
    {
        private float currentTorque = 0;
        private float currentCapacity;
        private float torquePower;
        private float nosCapacity;
        private bool isNosMode = false;

        public Nos(float power, float capacity)
        {
            torquePower = power;
            nosCapacity = capacity;
        }

        //To Do : Increase Nos for each time passed
        public void RegenNos()
        {
            if ((!isNosMode) && (currentCapacity < nosCapacity))
            {
                currentCapacity = currentCapacity + 1;
            }
        }

        //To Do : Decrease Nos Capacity for each time passed
        public void DoNos()
        {
            if (currentCapacity > 0)
            {
                currentTorque = torquePower;
                currentCapacity = currentCapacity - 1;
                isNosMode = true;
            }
        }

        public float GetTorquePower()
        {
            return torquePower;
        }

        public float GetNosCapacity()
        {
            return nosCapacity;
        }

        public float GetCurrentTorque()
        {
            return currentTorque;
        }
    }
}
