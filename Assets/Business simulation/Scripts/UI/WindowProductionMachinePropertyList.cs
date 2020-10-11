using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace BusinessSimulation.Scripts.UI
{
    public class WindowProductionMachinePropertyList : MonoBehaviour
    {
        private Text _namePropertyValue;
        private Text _settlerNamePropertyValue;
        private Text _productNamePropertyValue;
        private Text _productCountPropertyValue;
        private Text _goodProductionTimePropertyValue;
        private Text _productTimeOutPropertyValue;
        private Text _statusPropertyValue;
        private Text _inputProductNamePropertyValue;
        private Text _inputProductCountPropertyValue;

        public string Name {
            set => NamePropertyValue.text = value.ToString(CultureInfo.InvariantCulture);//
        }

        public string SettlerName 
        {
            set => SettlerNamePropertyValue.text = value;
        }

        public string ProductName {
            set => ProductNamePropertyValue.text = value;
        }

        public float ProductCount {
            set => ProductCountPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float GoodProductionTime {
            set => GoodProductionTimePropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float ProductTimeOut {
            set => ProductTimeOutPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public string Status {
            set => StatusPropertyValue.text = value;
        }
        
        private string InputProductName {
            set => InputProductNamePropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }
        
        private float InputProductCount {
            set => InputProductCountPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        private Text NamePropertyValue =>
            _namePropertyValue 
                ? _namePropertyValue 
                : _namePropertyValue = transform.Find("NameProperty").Find("PropertyValue").GetComponent<Text>();
        private Text SettlerNamePropertyValue => _settlerNamePropertyValue 
                ? _settlerNamePropertyValue 
                : _settlerNamePropertyValue = transform.Find("SettlerNameProperty").Find("PropertyValue").GetComponent<Text>();
        private Text ProductNamePropertyValue => _productNamePropertyValue
            ? _productNamePropertyValue 
            : _productNamePropertyValue = transform.Find("ProductNameProperty").Find("PropertyValue").GetComponent<Text>();
        private Text ProductCountPropertyValue => _productCountPropertyValue
            ? _productCountPropertyValue 
            : _productCountPropertyValue = transform.Find("ProductCountProperty").Find("PropertyValue").GetComponent<Text>();
        private Text GoodProductionTimePropertyValue => _goodProductionTimePropertyValue
            ? _goodProductionTimePropertyValue 
            : _goodProductionTimePropertyValue = transform.Find("GoodProductionTimeProperty").Find("PropertyValue").GetComponent<Text>();
        private Text ProductTimeOutPropertyValue => _productTimeOutPropertyValue
            ? _productTimeOutPropertyValue 
            : _productTimeOutPropertyValue = transform.Find("ProductTimeOutProperty").Find("PropertyValue").GetComponent<Text>();
        private Text StatusPropertyValue => _statusPropertyValue
            ? _statusPropertyValue 
            : _statusPropertyValue = transform.Find("StatusProperty").Find("PropertyValue").GetComponent<Text>();

        private Text InputProductNamePropertyValue => _inputProductNamePropertyValue
            ? _inputProductNamePropertyValue 
            : _inputProductNamePropertyValue = _inputProductNameProperty.transform.Find("InputProductNameProperty").Find("PropertyValue").GetComponent<Text>();
        
        private Text InputProductCountPropertyValue => _inputProductCountPropertyValue
            ? _inputProductCountPropertyValue 
            : _inputProductCountPropertyValue = _inputProductNameProperty.transform.Find("InputProductCountProperty").Find("PropertyValue").GetComponent<Text>();

        private GameObject _inputProductNameProperty;
        private int InputProductNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodName"></param>
        /// <param name="goodCount"></param>
        public void AddInputProduct(string goodName, float goodCount)
        {
            _inputProductNameProperty = InputProductNumber > 0
                ? Instantiate(_inputProductNameProperty)
                : transform.Find("StatusProperty").gameObject;

            InputProductNumber++;
            
            InputProductName = goodName;
            InputProductCount = goodCount;
        }

        
    }
}