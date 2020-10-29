using BusinessSimulation.Scripts;
using BusinessSimulation.Scripts.UI;

namespace Business_simulation.Service
{
    public class SecondSettlerPropertyService
    {
        public void updateProperty(SettlerPropertyList settlerPropertyList, PersonalCharacteristic characteristic)
        {
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