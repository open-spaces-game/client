using System;
using BusinessSimulation.Scripts.Target;
using BusinessSimulation.Scripts.UI;
using UnityEngine;

namespace Business_simulation.EventHandler
{
    public class CursorProductionMachineHandler
    {
        private TargetProductionMachine _targetProductionMachine;
        private ProductionMachineInfo _productionMachine;
        private bool _enable;
        
        public CursorProductionMachineHandler(TargetProductionMachine targetProductionMachine)
        {
            _targetProductionMachine = targetProductionMachine;
        }
        
        public void onCursor(Action<ProductionMachineInfo> createWindow, Action<ProductionMachineInfo> updateWindow, Action disableWindow)
        {
            if (_targetProductionMachine.IsPosition)
            {
                // PersonalCharacteristic
                var productionMachine = FindCharacteristic(_targetProductionMachine.TargetPosition.transform.gameObject);
                if (!_enable && _productionMachine != productionMachine)
                {
                    _productionMachine = productionMachine;
                    createWindow(productionMachine);
                }
                _enable = true;
                updateWindow(productionMachine);
            }
            else if (!_targetProductionMachine.IsPosition && _enable)
            {
                _enable = false;
                disableWindow();
            }
        }
        
        private ProductionMachineInfo FindCharacteristic(GameObject transformGameObject)
        {
            return transformGameObject.GetComponent<ProductionMachineInfo>() 
                ? transformGameObject.GetComponentInChildren<ProductionMachineInfo>() : null;
        }
    }
}