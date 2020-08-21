using UnityEngine;

namespace Business_simulation.Entity
{
    [System.Serializable]
    public class Characteristic
    {
        public float Real;
        public float Max;

        public float GetPct()
        {
            return Max == 0 ? Real / Max : 0;
        }

        public void SetValue(float value)
        {
            Real = value > Max ? Max : value;
        }
    }
}