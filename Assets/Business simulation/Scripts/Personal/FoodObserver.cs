using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulation.Scripts.Personal
{
    public class FoodObserver : MonoBehaviour
    {
        public float MinFoodPct = 0.2f;
        public float MinFoodDamageHealth = 0.001f;
        public float DamageFood = 0.001f;
        
        private PersonalCharacteristic PersonalCharacteristic;
        
        void Start()
        {
            PersonalCharacteristic = GetComponent<PersonalCharacteristic>();
        }

        void Update()
        {
            PersonalCharacteristic.Food.Damage(DamageFood);
            
            Debug.Log(PersonalCharacteristic.Food.GetPct());
            if (PersonalCharacteristic.Food.GetPct() < MinFoodPct)
            {
                PersonalCharacteristic.Health.Damage(MinFoodDamageHealth);
            }
        }
    }
}