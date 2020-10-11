using System.Collections.Generic;
using BusinessSimulation.Collection;
using BusinessSimulation.Entity;
using UnityEngine;
using UnityEngine.Serialization;

namespace BusinessSimulation.Scripts
{
    public class ProductionOfGoods : MonoBehaviour
    {
        public enum ProductionStatus
        {
            WaitingStart,
            Run,
            Pause
        }

        public ProductionStatus Status = ProductionStatus.WaitingStart;
        [SerializeField] public List<ProductionGood> IncomingGoods;
        [SerializeField] public ProductionGood OutgoingGood;
        public float GoodProductionTime;
        public GameObject Settler;
        public PersonalCharacteristic SettlerInfo => Settler ? Settler.GetComponent<PersonalCharacteristic>() : null;
        private ProductionGoodCollection IncomingProductionGoods =>
            (ProductionGoodCollection) (IncomingGoods is ProductionGoodCollection
                ? IncomingGoods
                : IncomingGoods = new ProductionGoodCollection(IncomingGoods));
        private PersonalCharacteristic CitizenCharacteristic { get; set; }
        private GoodStorage Storage { get; set; }

        public float TimeOut { get; private set; }
    

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            TimeOut = GoodProductionTime;
            Storage = GetComponent<GoodStorage>();
            //Set storage
        }

        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            if (checkRunProcess())
            {
                TimeOut -= Time.deltaTime * CitizenCharacteristic.Efficiency.GetPct();
                if (TimeOut <= 0)
                {
                    Storage.PutGood(OutgoingGood);
                    Status = ProductionStatus.WaitingStart;
                    RunProcess();
                }
            }
            else
            {
                Status = Status == ProductionStatus.Run ? ProductionStatus.Pause : ProductionStatus.WaitingStart;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Citizen"></param>
        public void RunProcess(GameObject Citizen)
        {
            this.Settler = Citizen;
            CitizenCharacteristic = Citizen.GetComponent<PersonalCharacteristic>();

            RunProcess();
        }

        /// <summary>
        /// TODO:: Проверить количество ресурсов на складе
        /// Если процесс приостановлен, то возвращаем его с того же места
        /// TODO:: Забрать ресурсы со склада при старте процесса
        /// </summary>
        private void RunProcess()
        {
            TimeOut = Status == ProductionStatus.Pause ? TimeOut : GoodProductionTime;
            if (Storage.CheckExistsGoods(IncomingProductionGoods) && Storage.GetFreePlace() > OutgoingGood.Count)
            {
                Storage.TakeGoods(IncomingProductionGoods);
                Status = ProductionStatus.Run;
            }
            else
            {
                Status = Status == ProductionStatus.Pause ? ProductionStatus.Pause : ProductionStatus.WaitingStart;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool checkRunProcess()
        {
            return Status == ProductionStatus.Run
                   && CitizenCharacteristic.CanWorkProcess();
        }
    }
}
