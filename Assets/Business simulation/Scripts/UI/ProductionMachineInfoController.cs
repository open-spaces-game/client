using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Target;
using UI.Scripts;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI
{
    public class ProductionMachineInfoController : MonoBehaviour
    {
        public GameObject WindowProductionMachineInfo { get; set; }

        public GameObject WindowProductionMachineInfoPrefab { get; set; }
        
        private GameObject _indexController;
        private TargetProductionMachine _targetProductionMachine;
        private UIController _uiController;
        private bool _enable;
        private ProductionMachineInfo _productionMachine;

        void Start()
        {
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            _targetProductionMachine = _indexController != null ? _indexController.GetComponent<TargetProductionMachine>() : null;
            _uiController = Camera.main.GetComponent<UIController>();
            _enable = false;
        }
        
        // Update is called once per frame
        void Update()
        {
            if (_targetProductionMachine.IsPosition)
            {
                // PersonalCharacteristic
                var productionMachine = FindCharacteristic(_targetProductionMachine.TargetPosition.transform.gameObject);
                if (!_enable && _productionMachine != productionMachine)
                {
                    
                    _productionMachine = productionMachine;
                    CreateWindow(productionMachine);
                }
                _enable = true;
                UpdateWindow(productionMachine);
            }
            else if (!_targetProductionMachine.IsPosition && _enable)
            {
                _enable = false;
                DisableWindow();
            }
        }

        private ProductionMachineInfo FindCharacteristic(GameObject transformGameObject)
        {
            return transformGameObject.GetComponent<ProductionMachineInfo>() 
                ? transformGameObject.GetComponentInChildren<ProductionMachineInfo>() : null;
        }

        private void DisableWindow()
        {
            WindowProductionMachineInfo.SetActive(false);
        }
        
        private void CreateWindow(ProductionMachineInfo productionMachineInfo)
        {
            if (WindowProductionMachineInfo != null)
            {
                Destroy(WindowProductionMachineInfo);
            }

            WindowProductionMachineInfo = Instantiate(WindowProductionMachineInfoPrefab, _uiController.ContainerTarget.transform, true);

            var productionMachinePropertyList = WindowProductionMachineInfo.GetComponent<WindowProductionMachinePropertyList>();
            productionMachinePropertyList.Name = productionMachineInfo.Name;
            var incomingGoods = productionMachineInfo.ProductionOfGoods.IncomingGoods;
            foreach (var good in incomingGoods)
            {
                productionMachinePropertyList.AddInputProduct(good.Good.name, good.Count);//TODO:: задать имя продукта
            }

            productionMachinePropertyList.ProductName = productionMachineInfo.ProductionOfGoods.OutgoingGood.Good.name;
            productionMachinePropertyList.ProductCount = productionMachineInfo.ProductionOfGoods.OutgoingGood.Count;
            productionMachinePropertyList.GoodProductionTime = productionMachineInfo.ProductionOfGoods.GoodProductionTime;
        }

        private void UpdateWindow(ProductionMachineInfo productionMachineInfo)
        {
            WindowProductionMachineInfo.SetActive(true);
            
            var productionMachinePropertyList = WindowProductionMachineInfo.GetComponent<WindowProductionMachinePropertyList>();
            
            productionMachinePropertyList.Status = productionMachineInfo.ProductionOfGoods.Status.ToString();
            productionMachinePropertyList.ProductTimeOut = productionMachineInfo.ProductionOfGoods.TimeOut;
            productionMachinePropertyList.SettlerName = productionMachineInfo.ProductionOfGoods.SettlerInfo?.Name;

            //TODO:: settler
        }
    }
}