using UnityEngine;

namespace BusinessSimulation.Entity
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

        public void Damage(float value)
        {
            Real = Mathf.Max(Real - value, 0);
        }
    }
}