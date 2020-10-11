using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Target;
using UI.Scripts;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI
{
    public class SettlerInfoController : MonoBehaviour
    {
        public GameObject WindowSettlerPrefab;
        public GameObject WindowSettler;
        
        
        private GameObject _indexController;
        private TargetSettler _targetSettler;
        private UIController _uiController;
        private bool _enable;
        private PersonalCharacteristic _characteristic;

        // Start is called before the first frame update
        void Start()
        {
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            _targetSettler = _indexController != null ? _indexController.GetComponent<TargetSettler>() : null;
            _uiController = Camera.main.GetComponent<UIController>();
            _enable = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_targetSettler.IsPosition)
            {
                // PersonalCharacteristic
                var characteristic = FindCharacteristic(_targetSettler.TargetPosition.transform.gameObject);
                if (!_enable && _characteristic != characteristic)
                {
                    
                    _characteristic = characteristic;
                    CreateWindow(characteristic);
                }
                _enable = true;
                UpdateWindow(characteristic);
            }
            else if (!_targetSettler.IsPosition && _enable)
            {
                _enable = false;
                DisableWindow();
            }
        }

     

        private PersonalCharacteristic FindCharacteristic(GameObject transformGameObject)
        {
            return transformGameObject.GetComponent<PersonalCharacteristic>() 
                ? transformGameObject.GetComponentInChildren<PersonalCharacteristic>() : null;
        }

        private void DisableWindow()
        {
            WindowSettler.SetActive(false);
        }
        
        private void CreateWindow(PersonalCharacteristic characteristic)
        {
            if (WindowSettler != null)
            {
                Destroy(WindowSettler);
            }

            WindowSettler = Instantiate(WindowSettlerPrefab, _uiController.ContainerTarget.transform, true);

            var settlerPropertyList = WindowSettler.GetComponent<SettlerPropertyList>();
            settlerPropertyList.FoodMinMax = new[] { characteristic.Food.Min, characteristic.Food.Max};
            settlerPropertyList.WaterMinMax = new[] { characteristic.Water.Min, characteristic.Water.Max};
            settlerPropertyList.SleepMinMax = new[] { characteristic.Sleep.Min, characteristic.Sleep.Max};
            settlerPropertyList.ClothesMinMax = new[] { characteristic.Clothes.Min, characteristic.Clothes.Max};
            settlerPropertyList.EntertainmentMinMax = new[] { characteristic.Entertainment.Min, characteristic.Entertainment.Max};
            settlerPropertyList.HealthMinMax = new[] { characteristic.Health.Min, characteristic.Health.Max};
            settlerPropertyList.EfficiencyMinMax = new[] { characteristic.Efficiency.Min, characteristic.Efficiency.Max};
        }
        
        private void UpdateWindow(PersonalCharacteristic characteristic)
        {
            WindowSettler.SetActive(true);
            
            var settlerPropertyList = WindowSettler.GetComponent<SettlerPropertyList>();
            settlerPropertyList.Food = characteristic.Food.Real;
            settlerPropertyList.Water = characteristic.Water.Real;
            settlerPropertyList.Sleep = characteristic.Sleep.Real;
            settlerPropertyList.Clothes = characteristic.Clothes.Real;
            settlerPropertyList.Entertainment = characteristic.Entertainment.Real;
            settlerPropertyList.Health = characteristic.Health.Real;
            settlerPropertyList.Efficiency = characteristic.Efficiency.Real;
        }
    }
}
