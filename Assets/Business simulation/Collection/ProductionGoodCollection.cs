using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Entity;
using UnityEngine;

namespace BusinessSimulation.Collection
{
    [System.Serializable]
    public class ProductionGoodCollection : List<ProductionGood>
    {
        public ProductionGoodCollection(List<ProductionGood> availableGoods) :base(availableGoods)
        {
        }

        public ProductionGood FindByGood(GameObject Good)
        {
            return Find(availableGood => availableGood.Good == Good);
        }

        public float PermittedVolume()
        {
            return this.Select(availableGood => availableGood.Count).Sum();
        }
    }
}