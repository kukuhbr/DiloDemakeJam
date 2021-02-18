using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NFS.Car.Movements
{
    public class GearState : MonoBehaviour
    {
        private List<Gear> gears;

        // Start is called before the first frame update
        void Start()
        {
            gears = new Gear();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}