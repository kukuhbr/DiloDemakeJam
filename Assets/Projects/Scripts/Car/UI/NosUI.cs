using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using NFS.Car.Movements;

namespace NFS.Car.UI
{
    public class NosUI : MonoBehaviour
    {
        public Image nosUI;
        public NosEngine nosEngine;

        private void Start()
        {
        }

        private void Update()
        {
            ShowNos();
        }

        private void ShowNos()
        {
            float max = nosEngine.GetNosCapacity();
            float current = nosEngine.GetCurrentCapacity();

            nosUI.fillAmount = current / max;
        }
    }
}