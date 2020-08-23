using UnityEngine;

namespace BusinessSimulation.Scripts.Personal
{
    public class EntertainmentObserver : MonoBehaviour
    {
        public float MinEntertainmentPct = 0.2f;
        public float MinEntertainmentDamageEfficiency = 0.3f;
        public float DamageEntertainment = 0.01f;
        
        private PersonalCharacteristic PersonalCharacteristic;
        
        void Start()
        {
            PersonalCharacteristic = GetComponent<PersonalCharacteristic>();
        }

        void Update()
        {
            PersonalCharacteristic.Entertainment.Damage(DamageEntertainment * Time.deltaTime);
            
            if (PersonalCharacteristic.Entertainment.GetPct() < MinEntertainmentPct)
            {
                PersonalCharacteristic.Efficiency.Damage(MinEntertainmentDamageEfficiency * Time.deltaTime);
            }
        }
    }
}