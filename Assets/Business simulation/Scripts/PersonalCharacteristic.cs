using System.Collections;
using System.Collections.Generic;
using Business_simulation.Entity;
using UnityEngine;

public class PersonalCharacteristic : MonoBehaviour
{
    /// <summary>
    /// еда
    /// </summary>
    [SerializeField]
    public Characteristic Food;
    /// <summary>
    /// вода
    /// </summary>
    [SerializeField]
    public Characteristic Water;
    /// <summary>
    /// сон
    /// </summary>
    [SerializeField]
    public Characteristic Sleep;
    /// <summary>
    /// одежда
    /// </summary>
    [SerializeField]
    public Characteristic Clothes;
    /// <summary>
    /// развлечение
    /// </summary>
    [SerializeField]
    public Characteristic Entertainment;
    
    /// <summary>
    /// здоровье
    /// </summary>
    [SerializeField]
    public Characteristic Health;
    /// <summary>
    /// КПД
    /// </summary>
    [SerializeField]
    public Characteristic Efficiency;
}
