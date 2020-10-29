using BusinessSimulation.Scripts;
using BusinessSimulation.Scripts.UI;

namespace Business_simulation.Service
{
    public class FirstSettlerPropertyService
    {
        public void updateProperty(SettlerPropertyList settlerPropertyList, PersonalCharacteristic characteristic)
        {
            settlerPropertyList.FoodMinMax = new[] { characteristic.Food.Min, characteristic.Food.Max};
            settlerPropertyList.WaterMinMax = new[] { characteristic.Water.Min, characteristic.Water.Max};
            settlerPropertyList.SleepMinMax = new[] { characteristic.Sleep.Min, characteristic.Sleep.Max};
            settlerPropertyList.ClothesMinMax = new[] { characteristic.Clothes.Min, characteristic.Clothes.Max};
            settlerPropertyList.EntertainmentMinMax = new[] { characteristic.Entertainment.Min, characteristic.Entertainment.Max};
            settlerPropertyList.HealthMinMax = new[] { characteristic.Health.Min, characteristic.Health.Max};
            settlerPropertyList.EfficiencyMinMax = new[] { characteristic.Efficiency.Min, characteristic.Efficiency.Max};
        }
    }
}