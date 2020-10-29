using System.Linq;
using Business_simulation.EventHandler;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Target;
using UI.Scripts;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI
{
    public class ProductionMachineInfoController : MonoBehaviour
    {
        public GameObject WindowProductionMachineInfoPrefab;
        
        private GameObject _indexController;
        private UIController _uiController;
        private ProductionMachineInfo _productionMachine;
        private CursorProductionMachineHandler _cursorProductionMachineHandler;
        private GameObject _windowProductionMachineInfo;

        void Start()
        {
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            _uiController = Camera.main.GetComponent<UIController>();
            
            var targetProductionMachine = _indexController != null 
                ? _indexController.GetComponent<TargetProductionMachine>() : null;
            
            _cursorProductionMachineHandler = new CursorProductionMachineHandler(targetProductionMachine);
        }
        
        // Update is called once per frame
        void Update()
        {
            _cursorProductionMachineHandler.onCursor(CreateWindow, UpdateWindow, DisableWindow);
        }

        private void DisableWindow()
        {
            _windowProductionMachineInfo.SetActive(false);
        }
        
        private void CreateWindow(ProductionMachineInfo productionMachineInfo)
        {
            if (_windowProductionMachineInfo != null)
            {
                Destroy(_windowProductionMachineInfo);
            }

            _windowProductionMachineInfo = Instantiate(WindowProductionMachineInfoPrefab, _uiController.ContainerTarget.transform, true);

            var productionMachinePropertyList = _windowProductionMachineInfo.GetComponent<WindowProductionMachinePropertyList>();
            productionMachinePropertyList.ProductionMachineInfo = productionMachineInfo;
        }

        private void UpdateWindow(ProductionMachineInfo productionMachineInfo)
        {
            _windowProductionMachineInfo.SetActive(true);
        }
    }
}