using System;
using System.Linq;
using AI.Scripts.Entity;
using BusinessSimulation.Entity;
using BusinessSimulation.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI.Scripts
{
    public class NodeCostChanger : MonoBehaviour
    {
        public enum CitizenCharacteristicName
        {
            Food,
            Water,
            Sleep,
            Clothes,
            Entertainment,
            Health,
            Efficiency
        };

        public GameObject action;
        public GameObject targetAction;

        public CitizenCharacteristicName citizenCharacteristic;
        public float min;
        public float max;
        

        private PersonalCharacteristic PersonalCharacteristic;
        private ActionCost ActionCost;
        private float MinMaxDiff;
        
        private void Start()
        {
            PersonalCharacteristic = GetComponentInParent<PersonalCharacteristic>();

            ActionCost = action.GetComponent<NodeController>()
                .ActionCosts
                .FirstOrDefault(cost => cost.Action == targetAction);

            enabled = ActionCost != null;

            MinMaxDiff = max - min;
        }

        private void Update()
        {
            ActionCost.Cost = min + MinMaxDiff * (1 - getValueCharacteristic());
        }
        
        /// <summary>
        /// TODO:: Нужно сделать определение через редактор источника значений
        /// </summary>
        /// <returns></returns>
        private float getValueCharacteristic()
        {
            switch (citizenCharacteristic)
            {
                case CitizenCharacteristicName.Clothes: return PersonalCharacteristic.Clothes.GetPct();
                case CitizenCharacteristicName.Efficiency: return PersonalCharacteristic.Efficiency.GetPct();
                case CitizenCharacteristicName.Entertainment: return PersonalCharacteristic.Entertainment.GetPct();
                case CitizenCharacteristicName.Food: return PersonalCharacteristic.Food.GetPct();
                case CitizenCharacteristicName.Sleep: return PersonalCharacteristic.Sleep.GetPct();
                case CitizenCharacteristicName.Water: return PersonalCharacteristic.Water.GetPct();
                case CitizenCharacteristicName.Health: return PersonalCharacteristic.Health.GetPct();
            }

            return 1;
        }
    }
}