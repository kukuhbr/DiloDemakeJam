using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NFS.Car.UI
{
    public class SpeedometerUI : MonoBehaviour
    {
        public Slider slider;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateUI(float rpm, float maxRPM)
        {
            slider.value = rpm / maxRPM;
        }
    }
}