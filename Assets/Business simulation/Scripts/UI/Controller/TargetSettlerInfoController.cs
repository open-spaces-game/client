using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Business_simulation.EventHandler;
using Business_simulation.Service;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Target;
using UI.Scripts;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI
{
    public class TargetSettlerInfoController : MonoBehaviour
    {
        public GameObject WindowSettlerPrefab;
        
        private GameObject _windowSettler;
        private UIController _uiController;

        private TargetCharacteristicHandler _targetCharacteristicHandler;

        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            _uiController = Camera.main.GetComponent<UIController>();
            var targetSelect = Camera.main.GetComponent<TargetSelect>();

            _targetCharacteristicHandler = new TargetCharacteristicHandler(targetSelect);
        }

        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            _targetCharacteristicHandler.onCursor(CreateWindow, DisableWindow);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristic"></param>
        private void CreateWindow(PersonalCharacteristic characteristic)
        {
            if (_windowSettler != null)
            {
                Destroy(_windowSettler);
            }

            _windowSettler = Instantiate(WindowSettlerPrefab, _uiController.targetContainer.transform, true);

            var settlerPropertyList = _windowSettler.GetComponent<SettlerPropertyList>();
            settlerPropertyList.Characteristic = characteristic;
            _windowSettler.SetActive(true);
            _windowSettler.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
       
        /// <summary>
        /// 
        /// </summary>
        private void DisableWindow()
        {
            if (_windowSettler != null)
            {
                _windowSettler.SetActive(false);
            }
        }
    }
}
