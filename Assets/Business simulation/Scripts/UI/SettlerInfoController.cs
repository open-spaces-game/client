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

        // Start is called before the first frame update
        void Start()
        {
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            _targetSettler = _indexController != null ? _indexController.GetComponent<TargetSettler>() : null;
            _uiController = Camera.main.GetComponent<UIController>();

            _cursorCharacteristicHandler = new CursorCharacteristicHandler(_targetSettler);
        }

        // Update is called once per frame
        void Update()
        {
            _cursorCharacteristicHandler.onCursor(CreateWindow, UpdateWindow, DisableWindow);
        }
        
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
        
        private void UpdateWindow(PersonalCharacteristic characteristic)
        {
            _windowSettler.SetActive(true);
        }
        
        private void DisableWindow()
        {
            _windowSettler.SetActive(false);
        }
    }
}
