using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFS.Car.Movements;
using NFS.Car.Inputs;
using System;

namespace NFS.Car.Audio
{
    public class CarAudio : MonoBehaviour
    {
        GearEngine gearEngine;
        CarInputHandler carInputHandler;
        [SerializeField] AudioSource engineSource;
        [SerializeField] AudioSource brakeSource;
        [SerializeField] AudioSource oneShotSource;
        // 1
        [SerializeField] AudioClip[] audioClips;
        void Start()
        {
            gearEngine = GetComponent<GearEngine>();
            carInputHandler = GetComponent<CarInputHandler>();
            StartCoroutine(PlayEngine());
            //engineSource.Play();
            //brakeSource.Play();
        }

        void Update()
        {
            HandleHandBrakeInput();
            HandleOneShotInput();
        }

        void HandleHandBrakeInput()
        {
            if (carInputHandler.IsInputHandBrake()) {
                if (gearEngine.GetCurrentSpeed() > 2f) {
                    brakeSource.mute = false;
                } else {
                    brakeSource.mute = true;
                }
            } else {
                brakeSource.mute = true;
            }
        }

        void HandleOneShotInput()
        {
            if (Input.GetButtonDown("GearDown")) {
                oneShotSource.PlayOneShot(audioClips[0]);
            }

            if (Input.GetButtonDown("GearUp")) {
                oneShotSource.PlayOneShot(audioClips[1]);
            }

            if (Input.GetButtonDown("Klaxxon")) {
                oneShotSource.PlayOneShot(audioClips[2]);
            }
        }

        IEnumerator PlayEngine()
        {
            float t;
            while(true)
            {
                if (gearEngine.GetCurrentGearNumber() == 0) {
                    t = gearEngine.GetCurrentRPM() / gearEngine.GetMaxRPM();
                } else {
                    t = gearEngine.GetCurrentSpeed() / gearEngine.GetCurrentMaxSpeed();
                }
                engineSource.pitch = Mathf.Lerp(.8f, 3, t);
                yield return null;
            }
        }

        IEnumerator PlayBrake()
        {
            while(true) {

                yield return null;
            }
        }
    }
}


