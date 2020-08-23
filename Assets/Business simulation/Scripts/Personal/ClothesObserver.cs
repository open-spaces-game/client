using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulation.Scripts.Personal
{
    public class ClothesObserver : MonoBehaviour
    {
        public float MinClothesPct = 0.2f;
        public float MinClothesDamageEntertainment = 0.3f;
        public float DamageClothes = 0.01f;
        
        private PersonalCharacteristic PersonalCharacteristic;
        
        void Start()
        {
            PersonalCharacteristic = GetComponent<PersonalCharacteristic>();
        }

        void Update()
        {
            PersonalCharacteristic.Clothes.Damage(DamageClothes * Time.deltaTime);
            
            if (PersonalCharacteristic.Clothes.GetPct() < MinClothesPct)
            {
                PersonalCharacteristic.Efficiency.Damage(MinClothesDamageEntertainment * Time.deltaTime);
            }
        }
    }
}