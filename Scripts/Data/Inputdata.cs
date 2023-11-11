using System;
using Unity.Mathematics;
using UnityEngine;

namespace AtmRushClone.Scripts.Data
{
    [Serializable]
    public struct Inputdata
    {
        public float horizontalSpeed;

        [Header("x : negative speed, y : positive speed"), Space]
        public float2 verticalSpeed;

        public float stopeSlope;
    }
}