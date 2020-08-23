using UnityEngine;

namespace BusinessSimulation.Scripts.Personal
{
    public class WaterObserver : MonoBehaviour
    {
        public float MinWaterPct = 0.2f;
        public float MinWaterDamageHealth = 0.3f;
        public float DamageWater = 0.01f;
        
        private PersonalCharacteristic PersonalCharacteristic;
        
        void Start()
        {
            PersonalCharacteristic = GetComponent<PersonalCharacteristic>();
        }

        void Update()
        {
            PersonalCharacteristic.Water.Damage(DamageWater * Time.deltaTime);
            
            if (PersonalCharacteristic.Water.GetPct() < MinWaterPct)
            {
                PersonalCharacteristic.Health.Damage(MinWaterDamageHealth * Time.deltaTime);
            }
        }
    }
}