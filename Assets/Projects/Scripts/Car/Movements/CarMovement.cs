using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace NFS.Car.Movements
{
    public class CarMovement : MonoBehaviour
    {
        public GearEngine gearEngine;
        public WheelDrive wheelDrive;
        public NosEngine nos;

        private void Start()
        {
            gearEngine = GetComponent<GearEngine>();
            wheelDrive = GetComponent<WheelDrive>();
            nos = GetComponent<NosEngine>();
        }
        private void FixedUpdate()
        {
            
        }
    }
}
