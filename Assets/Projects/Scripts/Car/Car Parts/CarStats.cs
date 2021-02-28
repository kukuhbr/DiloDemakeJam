using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Parts
{
    public class CarStats : MonoBehaviour
    {
        public Nos nos;
        public Engine engine;
        public GearSetup transmission;

        private float accel;
        private float maxSpeed;
        private float handling;

        // Start is called before the first frame update
        void Start()
        {
            CalculateAccel();
            CalculateHandling();
            CalculateMaxSpeed();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public float GetAccel()
        {
            return accel;
        }

        public float GetMaxSpeed()
        {
            return maxSpeed;
        }

        public float GetHandling()
        {
            return handling;
        }

        private void CalculateAccel()
        {

        }

        private void CalculateMaxSpeed()
        {

        }

        private void CalculateHandling()
        {

        }
    }
}