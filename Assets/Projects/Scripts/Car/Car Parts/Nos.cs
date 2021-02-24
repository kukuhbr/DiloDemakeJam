using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFS.Car.Parts
{
    [CreateAssetMenu(fileName = "Nos", menuName = "ScriptableObjects/Cars/Nos", order = 1)]
    public class Nos : ScriptableObject
    {
        public long price;
        public float power;
        public float capacity;
        public float regenSpeed;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}