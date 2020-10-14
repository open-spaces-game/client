using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BusinessSimulation.Scripts.UI
{
    public class WindowProductionMachinePropertyList : MonoBehaviour
    {
        public class InputProduct
        {
            public string Name { get; set; }
            public float Count { get; set; }
        }

        public GameObject TextBox;
        public Text UIText { get; set; }
    
        public string Name { get; set; }

        public string SettlerName { get; set; }

        public string ProductName { get; set; }

        public float ProductCount { get; set; }

        public float ProductionTime { get; set; }

        public float ProductTimeOut { get; set; }

        public string Status { get; set; }
        
        public List<InputProduct> InputProducts = new List<InputProduct>();
        
        public void AddInputProduct(string name, float count)
        {
            InputProducts.Add(new InputProduct()
            {
                Name = name,
                Count = count
            });
        }

        private void Start()
        {
            UIText = TextBox.GetComponent<Text>();
        }

        private void Update()
        {
            UIText.text =
                $"Name: {Name} \r\n" +
                $"Status: {Status}\r\n" +
                $"SettlerName: {SettlerName}\r\n" +
                $"ProductName: {ProductName}\r\n " +
                $"ProductCount: {ProductCount}\r\n" +
                $"ProductionTime: {ProductionTime}\r\n" +
                $"ProductTimeOut: {ProductTimeOut}\r\n" +
                string.Join("", InputProducts.Select(inputProduct =>
                    "inputProduct: \r\n" +
                    $"Name: {inputProduct.Name}\r\n" +
                    $"Count: {inputProduct.Count}\r\n"
                ));
        }
    }
}