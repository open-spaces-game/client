using UnityEngine;

namespace AI.Scripts.Entity
{
    public class ActionCost : MonoBehaviour
    {
        public int Cost;
        public GameObject Action;
        public float rangeMin;
        public float rangeMax;

        public bool InRange(float value)
        {
            return rangeMin < value && value < rangeMax;
        }
    }
}