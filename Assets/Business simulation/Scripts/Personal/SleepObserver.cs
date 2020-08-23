using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulation.Scripts.Personal
{
    public class SleepObserver : MonoBehaviour
    {
        public float MinSleepPct = 0.2f;
        public float MinSleepDamageEfficiency = 0.3f;
        public float DamageSleep = 0.01f;
        
        private PersonalCharacteristic PersonalCharacteristic;
        
        void Start()
        {
            PersonalCharacteristic = GetComponent<PersonalCharacteristic>();
        }

        void Update()
        {
            PersonalCharacteristic.Sleep.Damage(DamageSleep * Time.deltaTime);
            
            if (PersonalCharacteristic.Sleep.GetPct() < MinSleepPct)
            {
                PersonalCharacteristic.Efficiency.Damage(MinSleepDamageEfficiency * Time.deltaTime);
            }
        }
    }
}