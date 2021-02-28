using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace NFS.Car.Parts
{
    [CreateAssetMenu(fileName = "Engine", menuName = "ScriptableObjects/Cars/Engine", order = 1)]
    public class Engine : ScriptableObject
    {
        public float horsePower;

        public float GetHorsePower()
        {
            return horsePower;
        }

        public void SetHorsePower(float hP)
        {
            horsePower = hP;
        }
    }
}
