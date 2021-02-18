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
        private Command bSGearUp;
        private Command bSGearDown;
        private Command bSteer;

        // Start is called before the first frame update
        void Start()
        {
            bAccel = new Accelerate();
            bNothing = new DoNothing();
            bHBrake = new HandBrake();
            bNos = new Nos();
            bSGearUp = new ShiftGearUp();
            bSGearDown = new ShiftGearDown();
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
                bAccel.Execute(GetInputAccelerate());
            }
        }

        private void HandleShiftGearInput()
        {
            if (IsInputShiftGearUp())
            {
                bSGearUp.Execute(GetInputShiftGearUp());
            }
            else if (IsInputShiftGearDown())
            {
                bSGearDown.Execute(GetInputShiftGearDown());
            }
        }

        private void HandleSteerInput()
        {
            if (IsInputSteer())
            {
                bSteer.Execute(GetInputSteer());
            }
        }

        private void HandleNosInput()
        {
            if (IsInputNos())
            {
                bNos.Execute(GetInputNos());
            }
        }

        private void HandleHandBrakeInput()
        {
            if (IsInputHandBrake())
            {
                bHBrake.Execute(GetInputHandBrake());
            }
        }

        private bool IsInputAccelerate()
        {
            return GetInputAccelerate() != 0;
        }

        private bool IsInputSteer()
        {
            return GetInputSteer() != 0;
        }

        private bool IsInputHandBrake()
        {
            return GetInputHandBrake() != 0;
        }

        private bool IsInputNos()
        {
            return GetInputNos() != 0;
        }

        private bool IsInputShiftGearUp()
        {
            return GetInputShiftGearUp() != 0;
        }

        private bool IsInputShiftGearDown()
        {
            return GetInputShiftGearDown() != 0;
        }

        private float GetInputAccelerate()
        {
            return Input.GetAxis("Vertical");
        }

        private float GetInputSteer()
        {
            return Input.GetAxis("Horizontals");
        }

        private float GetInputHandBrake()
        {
            return Input.GetAxis("Fire1");
        }

        private float GetInputNos()
        {
            return Input.GetAxis("Fire2");
        }

        private float GetInputShiftGearUp()
        {
            return Input.GetAxis("Fire3");
        }

        private float GetInputShiftGearDown()
        {
            return Input.GetAxis("Fire4");
        }
    }
}