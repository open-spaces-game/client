using System;
using System.Collections.Generic;
using BusinessSimulation.Collection;
using BusinessSimulation.Entity;
using UnityEngine;

namespace BusinessSimulation.Scripts
{
    public class GoodStorage : MonoBehaviour
    {
        public float PermittedVolume;
        [SerializeField]
        public List<ProductionGood> AvailableGoods;

        private ProductionGoodCollection AvailableProductionGoods
        {
            get { return (ProductionGoodCollection)(AvailableGoods is ProductionGoodCollection 
                ? AvailableGoods
                : AvailableGoods = new ProductionGoodCollection(AvailableGoods)); }
        }



        public void PutGood(ProductionGood productionGood)
        {
            var availableGood = AvailableProductionGoods.FindByGood(productionGood.Good);

            if (availableGood != null)
            {
                availableGood.Count += productionGood.Count;
            }
            else
            {
                AvailableGoods.Add(productionGood);
            }
        }
        
        public bool CheckExistsGoods(ProductionGoodCollection incomingGoods)
        {
            foreach (var productionGood in incomingGoods)
            {
                var availableGood = AvailableProductionGoods.FindByGood(productionGood.Good);
                if (availableGood == null || productionGood.Count > availableGood.Count)
                {
                    return false;
                }
            }
            
            return true;
        }

        public void TakeGoods(ProductionGoodCollection incomingGoods)
        {
            foreach (var productionGood in incomingGoods)
            {
                var availableGood = AvailableProductionGoods.FindByGood(productionGood.Good);
                if (availableGood != null)
                {
                    if (productionGood.Count > availableGood.Count)
                    {
                        throw new Exception("Количество больше чем есть в хранилище");
                    }

                    availableGood.Count -= productionGood.Count;
                }
            }
        }

        public float GetFreePlace()
        {
            var availableVolume = AvailableProductionGoods.PermittedVolume();
            return Math.Max(PermittedVolume - availableVolume, 0);
        }
    }
}