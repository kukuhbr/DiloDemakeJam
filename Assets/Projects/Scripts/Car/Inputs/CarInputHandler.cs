using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NFS.Car.Inputs.Commands;

namespace NFS.Car.Inputs
{
    public class CarInputHandler : MonoBehaviour
    {
        private Command bAccel;
        private Command bNothing;
        private Command bHBrake;
        private Command bNos;
        private Command bSGear;
        private Command bSteer;

        // Start is called before the first frame update
        void Start()
        {
            bAccel = new Accelerate();
            bNothing = new DoNothing();
            bHBrake = new HandBrake();
            bNos = new Nos();
            bSGear = new ShiftGear();
            bSteer = new Steer();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            HandleShiftGearInput();
            HandleHandBrakeInput();
            HandleNosInput();
            HandleAccelerateInput();
            HandleSteerInput();
        }

        private void HandleAccelerateInput()
        {
            if (IsInputAccelerate())
            {
                bAccel.Execute();
            }
        }

        private void HandleShiftGearInput()
        {
            if (IsInputShiftGear())
            {
                bSGear.Execute();
            }
        }

        private void HandleSteerInput()
        {
            if (IsInputSteer())
            {
                bSteer.Execute();
            }
        }

        private void HandleNosInput()
        {
            if (IsInputNos())
            {
                bNos.Execute();
            }
        }

        private void HandleHandBrakeInput()
        {
            if (IsInputHandBrake())
            {
                bHBrake.Execute();
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