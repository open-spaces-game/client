using System;
using UnityEngine;

namespace BusinessSimulation.Entity
{
    [System.Serializable]
    public class Characteristic
    {
        public float Real;
        public float Max;
        public float Min;

        public float GetPct()
        {
            return Math.Abs(Max - Min) < 0.0001f ? Min : Real / Max ;
        }

        public void SetValue(float value)
        {
            Real = value > Max ? Max : value;
        }

        public void Damage(float value)
        {
            Real = Mathf.Max(Real - value, Min);
        }
    }
}