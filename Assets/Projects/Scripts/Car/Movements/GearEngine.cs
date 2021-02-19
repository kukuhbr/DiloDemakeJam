using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace NFS.Car.Movements
{
    public class GearEngine : MonoBehaviour
    {
        public TextMeshProUGUI textGUI;
        public WheelDrive wheelDrive;
        public Engine engine;
        public List<float> maxTorque;
        public float maxRPM = 8500;

        private List<Gear> gears;

        private int currentGear = 0;        
        private float currentRPM = 0;
        
        // Start is called before the first frame update
        void Start()
        {
            SetupGears();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //accelInputPower value (-1 -> 1)
        public void Accelerate(float accelInputPower)
        {
            float delta = (65 / gears[currentGear].GetGearNumber()) * accelInputPower;

            if ((currentRPM <= maxRPM) && (currentRPM >= -maxRPM))
            {
                currentRPM = currentRPM + delta;
            }
            else
            {
                currentRPM = maxRPM * Mathf.Round(accelInputPower);
            }
            
            ApplyTorqueToWheel();
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
            float torque;
            if (currentRPM == 0)
            {
                torque =  0;
            }
            else
            {
                torque =  (63025 * engine.GetHorsePower() / currentRPM);
            }
            
            float result = 0;
            if (
                (torque > gears[currentGear].GetMaxTorque()) 
                && (torque < -gears[currentGear].GetMaxTorque())
                )
            {
                result = gears[currentGear].GetMaxTorque();
            }
            else
            {
                result = torque;
            }
            textGUI.text = torque.ToString();
            return result;
        }

        private void ApplyTorqueToWheel()
        {
            wheelDrive.ApplyTorque(CalculateTorque());
        }

        private void SetupGears()
        {
            gears = new List<Gear>(maxTorque.Count);
            for (int i = 0; i < maxTorque.Count; i++)
            {
                gears.Add(new Gear(i + 1, maxTorque[i]));
            }
        }
    }
}