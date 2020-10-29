using BusinessSimulation.Scripts.UI;

namespace Business_simulation.Service
{
    public class FirstProductionMachineService
    {
        public void updateProperty(WindowProductionMachinePropertyList productionMachinePropertyList, ProductionMachineInfo productionMachineInfo)
        {
            productionMachinePropertyList.ProductionMachineInfo = productionMachineInfo;
            productionMachinePropertyList.Name = productionMachineInfo.Name;
            var incomingGoods = productionMachineInfo.ProductionOfGoods.IncomingGoods;
            foreach (var good in incomingGoods)
            {
                productionMachinePropertyList.AddInputProduct(good.GoodName, good.Count);
            }

            productionMachinePropertyList.ProductName = productionMachineInfo.ProductionOfGoods.OutgoingGood.GoodName;
            productionMachinePropertyList.ProductCount = productionMachineInfo.ProductionOfGoods.OutgoingGood.Count;
            productionMachinePropertyList.ProductionTime = productionMachineInfo.ProductionOfGoods.GoodProductionTime;
        }
    }
}