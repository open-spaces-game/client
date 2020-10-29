using BusinessSimulation.Scripts.UI;

namespace Business_simulation.Service
{
    public class SecondProductionMachineService
    {
        public void updateProperty(WindowProductionMachinePropertyList productionMachinePropertyList, ProductionMachineInfo productionMachineInfo)
        {
            productionMachinePropertyList.Status = productionMachineInfo.ProductionOfGoods.Status.ToString();
            productionMachinePropertyList.ProductTimeOut = productionMachineInfo.ProductionOfGoods.TimeOut;
            productionMachinePropertyList.SettlerName =  !(productionMachineInfo.ProductionOfGoods.SettlerInfo is null) 
                ? productionMachineInfo.ProductionOfGoods.SettlerInfo.Name
                : "--";
        }
    }
}