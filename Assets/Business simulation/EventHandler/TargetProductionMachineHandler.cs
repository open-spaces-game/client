using System;
using BusinessSimulation.Scripts.UI;
using UnityEngine;

namespace Business_simulation.EventHandler
{
    public class TargetProductionMachineHandler
    {
        private TargetSelect _targetSelect;
        private ProductionMachineInfo _productionMachine;
        private bool _enable;

        public TargetProductionMachineHandler(TargetSelect targetSelect)
        {
            _targetSelect = targetSelect;
        }

        public void onCursor(Action<ProductionMachineInfo> createWindow, Action<ProductionMachineInfo> updateWindow, Action disableWindow)
        {
            if (_targetSelect.IsPosition)
            {
                // PersonalCharacteristic
                var productionMachine = FindCharacteristic(_targetSelect.Target);
                if (!_enable && _productionMachine != productionMachine)
                {
                    _productionMachine = productionMachine;
                    createWindow(productionMachine);
                }
                _enable = true;
                updateWindow(productionMachine);
            }
            else if (!_targetSelect.IsPosition && _enable)
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