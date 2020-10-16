using System;
using BusinessSimulation.Entity;
using UnityEngine;

namespace BusinessSimulation.Scripts
{
    public class PersonalCharacteristic : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] public String Name;
        
        /// <summary>
        /// еда
        /// </summary>
        [SerializeField] public Characteristic Food;

        /// <summary>
        /// вода
        /// </summary>
        [SerializeField] public Characteristic Water;

        /// <summary>
        /// сон
        /// </summary>
        [SerializeField] public Characteristic Sleep;

        /// <summary>
        /// одежда
        /// </summary>
        [SerializeField] public Characteristic Clothes;

        /// <summary>
        /// развлечение
        /// </summary>
        [SerializeField] public Characteristic Entertainment;

        /// <summary>
        /// здоровье
        /// </summary>
        [SerializeField] public Characteristic Health;

        /// <summary>
        /// КПД
        /// </summary>
        [SerializeField] public Characteristic Efficiency;

        

        public bool CanWorkProcess()
        {
            return true;
        }
    }
}
