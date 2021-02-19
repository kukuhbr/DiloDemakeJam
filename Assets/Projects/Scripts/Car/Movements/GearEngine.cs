﻿using System.Collections;
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
        public GearSetup gearSetup;
        public float maxRPM = 8500;

        private List<Gear> gears;
        private float currentSpeed;
        private int currentGear = 0;        
        private float currentRPM = 0;
        
        // Start is called before the first frame update
        void Start()
        {
            SetupGears();
            currentRPM = 0;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            currentSpeed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        }

        //accelInputPower value (-1 -> 1)
        public void Accelerate(float accelInputPower)
        {
            int currentGearNumber = gears[currentGear].GetGearNumber();
            float delta = (65 / currentGearNumber) * accelInputPower;

            //drop rpm
            if (accelInputPower == 0)
            {
                ReleaseRPM();
            }
            //increase rpm
            else if (IsRPMInRange(currentRPM + delta))
            {
                currentRPM = currentRPM + delta;
            }
            //constant max rpm
            else
            {
                SetToMaxRPM(accelInputPower);
            }
            
            ApplyRPMToWheel();
        }

        public void ShiftGearUp()
        {
            float currentMaxSpeed = gears[currentGear].GetMaxSpeed();
            if (currentGear < gears.Count)
            {
                currentGear = currentGear + 1;
                currentRPM = Mathf.Max(maxRPM, maxRPM * currentSpeed / currentMaxSpeed);
            }
        }

        public void ShiftGearDown()
        {
            float currentMaxSpeed = GetCurrentMaxSpeed();
            if (currentGear > 0)
            {
                currentGear = currentGear - 1;
                currentRPM = Mathf.Max(maxRPM, maxRPM * currentSpeed / currentMaxSpeed);
            }
        }

        private void ApplyRPMToWheel()
        {
            float maxSpeed = GetCurrentMaxSpeed();
            textGUI.text = currentSpeed.ToString();
            wheelDrive.ApplyRPM(currentRPM, maxRPM, maxSpeed);
        }

        private void SetupGears()
        {
            gears = new List<Gear>(gearSetup.GetCount());
            for (int i = 0; i < gearSetup.GetCount(); i++)
            {
                gears.Add(new Gear(i + 1, gearSetup.maxSpeedPerGear[i]));
            }
        }

        private bool IsSpeedinRange(float speed)
        {
            float currentMaxSpeed = GetCurrentMaxSpeed();
            return ((speed <= currentMaxSpeed) && (speed >= -currentMaxSpeed));
        }

        private bool IsRPMInRange(float rpm)
        {
            return ((rpm <= maxRPM) && (rpm >= -maxRPM));
        }

        private float GetCurrentMaxSpeed()
        {
            return gears[currentGear].GetMaxSpeed();
        }

        private void ReleaseRPM()
        {
            if (currentRPM > 0)
            {
                currentRPM = currentRPM - (1000 * Time.deltaTime);
            }
            else if (currentRPM < 0)
            {
                currentRPM = currentRPM + (1000 * Time.deltaTime);
            }
            else
            {
                currentRPM = 0;
            }
        }

        private void SetToMaxRPM(float accelInput)
        {
            if (accelInput > 0)
            {
                currentRPM = maxRPM;
            }
            else if (accelInput < 0)
            {
                currentRPM = -maxRPM;
            }
        }
    }
}