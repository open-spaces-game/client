using System;
using UnityEngine;

namespace BusinessSimulation.Entity
{
    [System.Serializable]
    public class ProductionGood
    {
        public GameObject Good;
        public float Count;

        public string GoodName => Good ? Good.name : ""; //TODO:: задать имя продукта

    }
}