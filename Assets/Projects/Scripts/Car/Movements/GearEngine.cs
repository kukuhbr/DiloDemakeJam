using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NFS.Car.Movements
{
    public class GearEngine : MonoBehaviour
    {
        public WheelDrive wheelDrive;
        public Engine engine;
        public List<float> maxTorque;
        private int currentGear;
        private List<Gear> gears;
        private float currentRPM = 0;
        public float maxRPM = 8500;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < gears.Count; i++)
            {
                gears[i] = new Gear(i, maxTorque[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        //accelInputPower value (-1 -> 1)
        public void Accelerate(float accelInputPower)
        {
            if (currentRPM < maxRPM)
            {
                currentRPM = currentRPM + ((65 / gears[currentGear].GetGearNumber()) * accelInputPower);
            }
        }

        public void ShiftGearUp()
        {
            float torque = CalculateTorque();
            if (currentGear < gears.Count)
            {
                currentGear = currentGear + 1;
                currentRPM = Mathf.Max(maxRPM, maxRPM * torque / gears[currentGear].GetMaxTorque());                
            }
        }

        public void ShiftGearDown()
        {
            float torque = CalculateTorque();
            if (currentGear > 0)
            {
                currentGear = currentGear - 1;
                currentRPM = Mathf.Max(maxRPM, maxRPM * torque / gears[currentGear].GetMaxTorque());
            }
        }

        private float CalculateTorque()
        {
            if (currentRPM == 0)
            {
                return 0;
            }
            else
            {
                float torque =  (63025 * engine.GetHorsePower() / currentRPM);
                if (torque > gears[currentGear].GetMaxTorque())
                {
                    return gears[currentGear].GetMaxTorque();
                }
                else
                {
                    return torque;
                }
            }
        }

        private void ApplyTorqueToWheel()
        {
            wheelDrive.ApplyTorque(CalculateTorque());
        }
    }
}