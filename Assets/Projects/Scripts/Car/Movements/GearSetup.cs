using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace NFS.Car.Movements
{
    [CreateAssetMenu(fileName = "GearSetup", menuName = "ScriptableObjects/Cars/GearSetup", order = 1)]
    public class GearSetup : ScriptableObject
    {
        public List<float> maxSpeedPerGear;

        public int GetCount()
        {
            return maxSpeedPerGear.Count;
        }
    }
}
