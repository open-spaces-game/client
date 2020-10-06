using System;
using UnityEngine;

namespace AI.Scripts.Entity
{
    [Serializable]
    public class ActionCost 
    {
        [SerializeField]
        public float Cost;
        [SerializeField]
        public GameObject Action;
        [SerializeField]
        public bool Enabled;
        public float RangeMin { get; set; }
        public float RangeMax { get; set; }
        
        public bool InRange(float value)
        {
            return RangeMin < value && value < RangeMax;
        }
    }
}