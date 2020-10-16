using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace BusinessSimulation.Scripts.UI
{
    public class SettlerPropertyList : MonoBehaviour
    {
        private Text _foodPropertyValue;
        private Text _waterPropertyValue;
        private Text _sleepPropertyValue;
        private Text _clothesPropertyValue;
        private Text _entertainmentPropertyValue;
        private Text _healthPropertyValue;
        private Text _efficiencyPropertyValue;
        
        public float[] FoodMinMax { get; set;}
        public float[] WaterMinMax { get; set; }
        public float[] SleepMinMax { get; set; }
        public float[] ClothesMinMax { get; set; }
        public float[] EntertainmentMinMax { get; set; }
        public float[] HealthMinMax { get; set; }
        public float[] EfficiencyMinMax { get; set; }
        
        public float Food {
            set => FoodPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float Water
        {
            set => WaterPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float Sleep
        {
            set => SleepPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float Clothes
        {
            set => ClothesPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float Entertainment
        {
            set => EntertainmentPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float Health
        {
            set => HealthPropertyValue.text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float Efficiency
        {
            set
            {
                transform.Find("EfficiencyProperty").Find("PropertyValue").GetComponent<Text>().text = value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private Text FoodPropertyValue
        {
            get => _foodPropertyValue 
                ? _foodPropertyValue 
                : _foodPropertyValue = transform.Find("FoodProperty").Find("PropertyValue").GetComponent<Text>();
        }
        private Text WaterPropertyValue
        {
            get => _waterPropertyValue 
                ? _waterPropertyValue 
                : _waterPropertyValue = transform.Find("WaterProperty").Find("PropertyValue").GetComponent<Text>();
        }
        private Text SleepPropertyValue =>
            _sleepPropertyValue 
                ? _sleepPropertyValue 
                : _sleepPropertyValue = transform.Find("SleepProperty").Find("PropertyValue").GetComponent<Text>();

        private Text ClothesPropertyValue
        {
            get => _clothesPropertyValue
                ? _clothesPropertyValue
                : _clothesPropertyValue = transform.Find("ClothesProperty").Find("PropertyValue").GetComponent<Text>();
        }
        
        private Text EntertainmentPropertyValue
        {
            get => _entertainmentPropertyValue
                ? _entertainmentPropertyValue
                : _entertainmentPropertyValue = transform.Find("EntertainmentProperty").Find("PropertyValue").GetComponent<Text>();
        }
        private Text HealthPropertyValue
        {
            get => _healthPropertyValue
                ? _healthPropertyValue
                : _healthPropertyValue = transform.Find("HealthProperty").Find("PropertyValue").GetComponent<Text>();
        }
        private Text EfficiencyPropertyValue
        {
            get => _efficiencyPropertyValue
                ? _efficiencyPropertyValue
                : _efficiencyPropertyValue = transform.Find("EfficiencyProperty").Find("PropertyValue").GetComponent<Text>();
        }
    }
}