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
        public TextMeshProUGUI percentageText;
        public Image shiftAlertImage;
        public Image shiftCategoryImage;
        public Animator shiftCatAnimator;

        private float animateTimeCheck = 0.1f;
        private float animateTime;

        // Start is called before the first frame update
        void Start()
        {
            shiftCategoryImage.color = new Color(255, 255, 255, 0);
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
            ShowShiftPercentage();
            ShowAlert();
            if (gearEngine.IsShiftingGearUp())
            {
                ShowShiftCategory();
            }
            if (animateTime > 0)
            {
                animateTime = animateTime - Time.deltaTime;
            }
            else
            {
                AnimateShiftCategory(false);
                animateTime = 0;
            }
        }

        private void AnimateShiftCategory(bool paramVal)
        {
            shiftCatAnimator.SetBool("isShow", paramVal);
        }

        private void ShowAlert()
        {
            shiftAlertImage.sprite = gearEngine.GetAlertCategory();
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
            shiftCategoryImage.sprite = gearEngine.GetShiftCategory();
            AnimateShiftCategory(true);
            animateTime = animateTimeCheck;
            //shiftCategoryText.text = gearEngine.GetShiftCategory();
        }

        private void ShowSpeedUI()
        {
            float currentSpeed = gearEngine.GetCurrentSpeed();
            speedText.text = Mathf.Round(currentSpeed).ToString();
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