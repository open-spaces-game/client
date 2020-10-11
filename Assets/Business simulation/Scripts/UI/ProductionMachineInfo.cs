using UnityEngine;

namespace BusinessSimulation.Scripts.UI
{
    public class ProductionMachineInfo : MonoBehaviour
    {
        public string Name;

        public Sprite Image;
        
        private ProductionOfGoods _productionOfGoods;
        public ProductionOfGoods ProductionOfGoods => _productionOfGoods 
            ? _productionOfGoods : _productionOfGoods = GetComponent<ProductionOfGoods>();

    }
}