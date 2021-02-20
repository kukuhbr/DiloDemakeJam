using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NFS.Car.Inputs.Commands;
using NFS.Car.Movements;

namespace NFS.Car.Inputs
{
    public class CarInputHandler : MonoBehaviour
    {
        public CarMovement movement;

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
            bAccel = new Accelerate(movement);
            bNothing = new DoNothing(movement);
            bHBrake = new HandBrake(movement);
            bNos = new Nos(movement);
            bSGearUp = new ShiftGearUp(movement);
            bSGearDown = new ShiftGearDown(movement);
            bSteer = new Steer(movement);
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
            bAccel.Execute(GetInputAccelerate());
        }

        private void HandleShiftGearInput()
        {
            bSGearUp.Execute(GetInputShiftGearUp());
            bSGearDown.Execute(GetInputShiftGearDown());
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

        public bool IsInputAccelerate()
        {
            return GetInputAccelerate() != 0;
        }

        public bool IsInputSteer()
        {
            return GetInputSteer() != 0;
        }

        public bool IsInputHandBrake()
        {
            return GetInputHandBrake() != 0;
        }

        public bool IsInputNos()
        {
            return GetInputNos() != 0;
        }

        public bool IsInputShiftGearUp()
        {
            return GetInputShiftGearUp() != 0;
        }

        public bool IsInputShiftGearDown()
        {
            return GetInputShiftGearDown() != 0;
        }

        private float GetInputAccelerate()
        {
            return Input.GetAxis("Vertical");
        }

        private float GetInputSteer()
        {
            return Input.GetAxis("Horizontal");
        }

        private float GetInputHandBrake()
        {
            return Input.GetAxis("Fire1");
        }

        private float GetInputNos()
        {
            return Input.GetAxis("Fire3");
        }

        private float GetInputShiftGearUp()
        {
            return Input.GetAxis("GearUp");
        }

        private float GetInputShiftGearDown()
        {
            return Input.GetAxis("GearDown");
        }
    }
}