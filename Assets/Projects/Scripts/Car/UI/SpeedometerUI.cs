using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using NFS.Car.Movements;

namespace NFS.Car.UI
{
    public class SpeedometerUI : MonoBehaviour
    {
        public GearEngine gearEngine;
        public Slider slider;
        public TextMeshProUGUI speedText;
        public TextMeshProUGUI gearText;
        public TextMeshProUGUI shiftCategoryText;
        public TextMeshProUGUI percentageText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            ShowGearUI();
            ShowSpeedometerUI();
            ShowSpeedUI();
            ShowShiftCategory();
            ShowShiftPercentage();
            if (gearEngine.IsShiftingGearUp())
            {
                
            }
        }

        private void ShowShiftPercentage()
        {
            float currentSpeed = gearEngine.GetCurrentSpeed();
            float currentMaxSpeed = gearEngine.GetCurrentMaxSpeed();
            float result = (currentSpeed / currentMaxSpeed) * 100;
            percentageText.text = Mathf.Round(result).ToString() + "%";
        }

        private void ShowShiftCategory()
        {
            shiftCategoryText.text = gearEngine.GetShiftCategory();
        }

        private void ShowSpeedUI()
        {
            float currentSpeed = gearEngine.GetCurrentSpeed();
            speedText.text = Mathf.Round(currentSpeed).ToString() + "km/h";
        }

        private void ShowGearUI()
        {
            Gear currentGear = gearEngine.GetCurrentGear();
            gearText.text = currentGear.GetGearNumber().ToString();
        }

        private void ShowSpeedometerUI()
        {
            Gear currentGear = gearEngine.GetCurrentGear();
            if (currentGear.GetMaxSpeed() == 0)
            {
                UpdateSpeedometer(gearEngine.GetCurrentRPM(), gearEngine.GetMaxRPM());
            }
            else
            {
                UpdateSpeedometer(gearEngine.GetCurrentSpeed(), gearEngine.GetCurrentMaxSpeed());
            }
        }

        private void UpdateSpeedometer(float value, float maxValue)
        {
            slider.value = value / maxValue;
        }
    }
}