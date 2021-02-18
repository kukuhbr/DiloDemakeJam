using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace NFS.Car.Movements
{
    public class Engine : MonoBehaviour
    {
        public float hP;

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
