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
        private bool isRaceStarted = false;
        void Start()
        {
            gearEngine = GetComponent<GearEngine>();
            carInputHandler = GetComponent<CarInputHandler>();
            StartCoroutine(PlayEngine());
            //engineSource.Play();
            //brakeSource.Play();
            GameState.OnRaceStart += OnRaceStartHandler;
            GameState.OnRaceEnd += BrakeOnEnd;
        }

        void Update()
        {
            HandleHandBrakeInput();
            HandleOneShotInput();
        }

        void OnRaceStartHandler()
        {
            isRaceStarted = true;
        }

        void BrakeOnEnd()
        {
            StartCoroutine(PlayBrake());
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
                if (isRaceStarted) {
                    oneShotSource.PlayOneShot(audioClips[0]);
                } else {
                    oneShotSource.PlayOneShot(audioClips[2]);
                }
            }

            if (Input.GetButtonDown("GearUp")) {
                if (isRaceStarted) {
                    oneShotSource.PlayOneShot(audioClips[1]);
                } else {
                    oneShotSource.PlayOneShot(audioClips[3]);
                }
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
            while(gearEngine.GetCurrentSpeed() > 2f) {
                brakeSource.mute = false;
                yield return null;
            }
            brakeSource.mute = true;
        }

        public void PlayOneShot(int i) {
            if (i > audioClips.Length - 1)
                return;
            Debug.Log("PlayOneShot");
            oneShotSource.PlayOneShot(audioClips[i]);
        }

        void OnDestroy()
        {
            GameState.OnRaceStart -= OnRaceStartHandler;
            GameState.OnRaceEnd -= BrakeOnEnd;
        }
    }
}


