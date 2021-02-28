using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using NFS.Car.Parts;

namespace NFS.Car.Movements
{
    public class NosEngine : MonoBehaviour
    {
        public Nos nos;
        public GearEngine gearEngine;
        public LineRenderer nosLine;

        public Transform nosLineStart;
        public Transform nosLineEnd;

        private float currentPower;
        private float currentCapacity;
        private bool isAllowNos = false;

        private void Start()
        {
            currentCapacity = nos.capacity;
            currentPower = 0;
            GameState.OnRaceStart += AllowNos;
        }

        private void FixedUpdate()
        {
            RegenNos();
        }

        public void ApplyNos(float nosInputForce)
        {
            if (isAllowNos)
            {
                DoNos(nosInputForce);
            }
        }

        //To Do : Increase Nos for each time passed
        public void RegenNos()
        {
            if ((currentPower == 0) && (currentCapacity <= nos.capacity))
            {
                currentCapacity = currentCapacity + (1 * nos.regenSpeed * Time.deltaTime);
                nosLine.enabled = false;
            }
            if (currentCapacity > nos.capacity)
            {
                currentCapacity = nos.capacity;
            }
        }

        //To Do : Decrease Nos Capacity for each time passed
        public void DoNos(float inputForce)
        {
            if (currentCapacity > 0)
            {
                currentPower = nos.power * inputForce;
                currentCapacity = currentCapacity - 1 * Time.deltaTime;
                nosLine.enabled = true;
                nosLine.SetPosition(0, nosLineStart.position);
                nosLine.SetPosition(1, nosLineEnd.position);
                if (gearEngine.GetCurrentSpeed() <= gearEngine.GetCurrentMaxSpeed())
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * currentPower, ForceMode.Impulse);
                }
            }
            else
            {
                currentPower = 0;
            }
        }

        public float GetCurrentPower()
        {
            return currentPower;
        }

        public float GetCurrentCapacity()
        {
            return currentCapacity;
        }

        public float GetNosCapacity()
        {
            return nos.capacity;
        }

        public float GetNosPower()
        {
            return nos.power;
        }

        private void AllowNos()
        {
            isAllowNos = true;
        }
    }
}
