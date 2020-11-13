using System;
using System.Globalization;
using Business_simulation.Service;
using UnityEngine;
using UnityEngine.UI;

namespace BusinessSimulation.Scripts.UI
{
    public class SettlerPropertyList : MonoBehaviour
    {
        public Text UIText { get; set; }
        public GameObject TextBox;
        
        public PersonalCharacteristic Characteristic { get; set; }
        private FirstSettlerPropertyService _firstSettlerPropertyService;
        private SecondSettlerPropertyService _secondSettlerPropertyService;
        
        private void Start()
        {
            _firstSettlerPropertyService = new FirstSettlerPropertyService();
            _secondSettlerPropertyService = new SecondSettlerPropertyService();
            
            _firstSettlerPropertyService.updateProperty(this, Characteristic);
            UIText = TextBox.GetComponent<Text>();
        }

        private void Update()
        {
            _secondSettlerPropertyService.updateProperty(this, Characteristic);
            
            UIText.text =
                $"Food: {Food} ({FoodMinMax[0]} - {FoodMinMax[1]})\r\n" +
                $"Water: {Water} ({WaterMinMax[0]} - {WaterMinMax[1]})\r\n" +
                $"Sleep: {Sleep} ({SleepMinMax[0]} - {SleepMinMax[1]})\r\n" +
                $"Clothes: {Clothes} ({ClothesMinMax[0]} - {ClothesMinMax[1]})\r\n " +
                $"Entertainment: {Entertainment} ({EntertainmentMinMax[0]} - {EntertainmentMinMax[1]})\r\n" +
                $"Health: {Health} ({HealthMinMax[0]} - {HealthMinMax[1]})\r\n" +
                $"Efficiency: {Efficiency} ({EfficiencyMinMax[0]} - {EfficiencyMinMax[1]})\r\n";
        }

                
        public float Food { get; set; }
        public float Water { get; set; }
        public float Sleep { get; set; }
        public float Clothes { get; set; }
        public float Entertainment { get; set; }
        public float Health { get; set; }
        public float Efficiency { get; set; }
        
        public float[] FoodMinMax { get; set;}
        public float[] WaterMinMax { get; set; }
        public float[] SleepMinMax { get; set; }
        public float[] ClothesMinMax { get; set; }
        public float[] EntertainmentMinMax { get; set; }
        public float[] HealthMinMax { get; set; }
        public float[] EfficiencyMinMax { get; set; }

    }
}