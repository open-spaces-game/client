using System;
using BusinessSimulation.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Business_simulation.EventHandler
{
    public class TargetCharacteristicHandler
    {
        private TargetSelect _targetSelect;
        private PersonalCharacteristic _characteristic;
        private bool _enable;

        public TargetCharacteristicHandler(TargetSelect targetSelect)
        {
            _targetSelect = targetSelect;
        }

        public void onCursor(Action<PersonalCharacteristic> createWindow, Action<PersonalCharacteristic> updateWindow, Action disableWindow)
        {
            if (_targetSelect.IsPosition)
            {
                // PersonalCharacteristic
                var characteristic = FindCharacteristic(_targetSelect.Target);
                if (!_enable && _characteristic != characteristic)
                {
                    _characteristic = characteristic;
                    createWindow(characteristic);
                }
                _enable = true;
                updateWindow(characteristic);
            }
            else if (!_targetSelect.IsPosition && _enable)
            {
                _enable = false;
                disableWindow();
            }
        }
        
        private PersonalCharacteristic FindCharacteristic(GameObject transformGameObject)
        {
            return transformGameObject.GetComponent<PersonalCharacteristic>() 
                ? transformGameObject.GetComponentInChildren<PersonalCharacteristic>() : null;
        }
    }
}