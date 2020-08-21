using System;
using System.Collections;
using System.Collections.Generic;
using Business_simulation.Entity;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class ProductionOfGoods : MonoBehaviour
{
    public enum ProductionStatus { WaitingStart, Run, Pause }

    public ProductionStatus Status = ProductionStatus.WaitingStart;
    [SerializeField]
    public List<ProductionGood> IncomingGoods;  
    [SerializeField]
    public ProductionGood OutgoingGood;
    public float GoodProductionTime;
    public GameObject Citizen;
    
    private PersonalCharacteristic CitizenCharacteristic;

    private float TimeOut = 0;
    private bool _isCitizenCharacteristicNotNull;
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        TimeOut = GoodProductionTime;
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
                //Set storage OutgoingGood
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
        this.Citizen = Citizen;
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
        if (true)
        {
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
