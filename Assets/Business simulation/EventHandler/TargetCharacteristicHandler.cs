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

        public void onCursor(Action<PersonalCharacteristic> createWindow, Action disableWindow)
        {
            if (!_enable && _targetSelect.IsPosition)
            {
                // PersonalCharacteristic
                var characteristic = FindCharacteristic(_targetSelect.Target);
                if ( _characteristic != characteristic)
                {
                    _characteristic = characteristic;
                    createWindow(characteristic);
                }
                _enable = true;
            }
            else if (_enable && !_targetSelect.IsPosition)
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