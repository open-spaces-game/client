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
    public class SettlerInfoController : MonoBehaviour
    {
        public GameObject WindowSettlerPrefab;
        
        private GameObject _windowSettler;
        private GameObject _indexController;
        private TargetSettler _targetSettler;
        private UIController _uiController;

        private CursorCharacteristicHandler _cursorCharacteristicHandler;
        private TargetCharacteristicHandler _targetCharacteristicHandler;

        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            _targetSettler = _indexController != null ? _indexController.GetComponent<TargetSettler>() : null;
            _uiController = Camera.main.GetComponent<UIController>();
            
            var targetSelect = Camera.main.GetComponent<TargetSelect>();

            _cursorCharacteristicHandler = new CursorCharacteristicHandler(_targetSettler);
            _targetCharacteristicHandler = new TargetCharacteristicHandler(targetSelect);
        }

        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            _cursorCharacteristicHandler.onCursor(CreateWindow, UpdateWindow, DisableWindow);
            //_targetCharacteristicHandler.onCursor(CreateWindow, UpdateWindow, DisableWindow);
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

            _windowSettler = Instantiate(WindowSettlerPrefab, _uiController.ContainerTarget.transform, true);

            var settlerPropertyList = _windowSettler.GetComponent<SettlerPropertyList>();
            settlerPropertyList.Characteristic = characteristic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristic"></param>
        private void UpdateWindow(PersonalCharacteristic characteristic)
        {
            _windowSettler.SetActive(true);
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
