using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace NFS.Car.Movements
{
    public class GearEngine : MonoBehaviour
    {
        public WheelDrive wheelDrive;
        public Engine engine;
        public GearSetup gearSetup;
        public GearShiftCategory gearShiftCategory;
        public float maxRPM = 8500;

        private List<Gear> gears;
        private float currentSpeed;
        private int currentGear = 0;
        private float currentRPM = 0;
        private bool isShiftingGearUp = false;
        private Sprite shiftCategory;
        private Sprite alertCategory;
        private float shiftTimeCheck = 0.1f;
        private float shiftTime;

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
            ResetIsShiftingGearUp();
            UpdateAlertCategory();
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
            isShiftingGearUp = true;
            float currentMaxSpeed = GetCurrentMaxSpeed();

            if (currentMaxSpeed == 0)
            {
                float shiftCategoryValue = gearShiftCategory.GetCategoryValue(currentRPM, maxRPM);
                shiftCategory = gearShiftCategory.GetSpriteCategory(currentRPM, maxRPM);
                Debug.Log(currentRPM + ">" + maxRPM + ">" + shiftCategoryValue + ">" + shiftCategory);
                if (currentGear + 1 < gears.Count)
                {
                    currentGear = currentGear + 1;
                    currentRPM = (Mathf.Min(maxRPM, currentRPM)/2) + shiftCategoryValue;
                }
            }
            else
            {
                float shiftCategoryValue = gearShiftCategory.GetCategoryValue(currentSpeed, currentMaxSpeed);

                shiftCategory = gearShiftCategory.GetSpriteCategory(currentSpeed, currentMaxSpeed);
                Debug.Log(currentSpeed + ">" + currentMaxSpeed + ">" + shiftCategoryValue + ">" + shiftCategory);
                if (currentGear + 1 < gears.Count)
                {
                    currentGear = currentGear + 1;
                    currentRPM = (Mathf.Min(maxRPM, currentRPM)/2) + shiftCategoryValue;
                }
            }
        }

        public void ShiftGearDown()
        {
            if (currentGear - 1 >= 0)
            {
                currentGear = currentGear - 1;
                currentRPM = (Mathf.Min(maxRPM, currentRPM)/2);
            }            
        }

        public float GetCurrentRPM()
        {
            return currentRPM;
        }

        public float GetMaxRPM()
        {
            return maxRPM;
        }

        public float GetCurrentSpeed()
        {
            return currentSpeed;
        }

        public float GetCurrentMaxSpeed()
        {
            return gears[currentGear].GetMaxSpeed();
        }

        public float GetMaxSpeed()
        {
            return gears[gears.Count-1].GetMaxSpeed();
        }

        public int GetCurrentGearNumber()
        {
            return currentGear;
        }

        public Gear GetCurrentGear()
        {
            return gears[currentGear];
        }

        public Sprite GetShiftCategory()
        {
            return shiftCategory;
        }

        public Sprite GetAlertCategory()
        {
            return alertCategory;
        }

        public bool IsShiftingGearUp()
        {
            return isShiftingGearUp;
        }

        private void ApplyRPMToWheel()
        {
            float maxSpeed = GetCurrentMaxSpeed();
            wheelDrive.ApplyRPM(currentRPM, maxRPM, currentSpeed, maxSpeed);
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

        private void ReleaseRPM()
        {
            if (currentRPM > 1)
            {
                currentRPM = currentRPM - (maxRPM * Time.deltaTime);
            }
            else if (currentRPM < -1)
            {
                currentRPM = currentRPM + (maxRPM * Time.deltaTime);
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

        private void ResetIsShiftingGearUp()
        {
            if (isShiftingGearUp)
            {
                shiftTime = shiftTime - Time.deltaTime;
                if (shiftTime < 0)
                {
                    isShiftingGearUp = false;
                }
            }
            else if (!isShiftingGearUp)
            {
                shiftTime = shiftTimeCheck;
            }
        }

        private void UpdateAlertCategory()
        {
            float maxSpeed = GetCurrentMaxSpeed();
            if (maxSpeed == 0)
            {
                alertCategory = gearShiftCategory.GetAlerts(currentRPM, maxRPM);
            }
            else
            {
                alertCategory = gearShiftCategory.GetAlerts(currentSpeed, GetCurrentMaxSpeed());
            }
        }
    }
}