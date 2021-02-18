using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Car.Movements
{
    public class Nos
    {
        private float torquePower;
        private float NosCapacity;

        public Nos(float power, float capacity)
        {
            torquePower = power;
            NosCapacity = capacity;
        }

        public float GetTorquePower()
        {
            return torquePower;
        }

        public float GetNosCapacity()
        {
            return NosCapacity;
        }
    }
}
