using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Car.Movements
{
    public class Engine
    {
        private float hP;

        public Engine(float horsePower)
        {
            hP = horsePower;
        }

        public float GetHorsePower()
        {
            return hP;
        }

        public void SetHorsePower(float horsePower)
        {
            hP = horsePower;
        }
    }
}
