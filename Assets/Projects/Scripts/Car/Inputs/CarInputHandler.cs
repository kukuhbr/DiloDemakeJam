using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Inputs
{
    public class CarInputHandler : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (IsInputAccelerate())
            {

            }
            if (IsInputSteer())
            {

            }
            if (IsInputHandBrake())
            {

            }
            if (IsInputNos())
            {

            }
            if (IsInputSteer())
            {

            }
        }

        private bool IsInputAccelerate()
        {
            return Input.GetAxis("Vertical") != 0;
        }

        private bool IsInputSteer()
        {
            return Input.GetAxis("Horizontals") != 0;
        }

        private bool IsInputHandBrake()
        {
            return Input.GetAxis("Fire1") != 0;
        }

        private bool IsInputNos()
        {
            return Input.GetAxis("Fire2") != 0;
        }

        private bool IsInputShiftGear()
        {
            return Input.GetAxis("Fire3") != 0;
        }
    }
}