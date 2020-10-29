using System;
using BusinessSimulation.Scripts;
using BusinessSimulation.Scripts.Target;
using UnityEngine;


namespace Business_simulation.EventHandler
{
    public class CursorCharacteristicHandler
    {
        public bool _enable;
        private PersonalCharacteristic _characteristic;
        private TargetSettler _targetSettler;

        public CursorCharacteristicHandler(TargetSettler targetSettler)
        {
            _targetSettler = targetSettler;
        }

        public void onCursor(Action<PersonalCharacteristic> createWindow, Action<PersonalCharacteristic> updateWindow, Action disableWindow)
        {
            if (_targetSettler.IsPosition)
            {
                // PersonalCharacteristic
                var characteristic = FindCharacteristic(_targetSettler.TargetPosition.transform.gameObject);
                if (!_enable && _characteristic != characteristic)
                {
                    _characteristic = characteristic;
                    createWindow(characteristic);
                }
                _enable = true;
                updateWindow(characteristic);
            }
            else if (!_targetSettler.IsPosition && _enable)
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