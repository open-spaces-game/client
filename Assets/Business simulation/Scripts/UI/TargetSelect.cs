using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Build;
using BusinessSimulation.Scripts.Target;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetSelect : MonoBehaviour
{
    public GameObject Target;
    public bool IsPosition { get; private set; }

    private List<TargetPositionInterface> _targetControllers;
    private IEnumerable<TargetPositionInterface> _queryObjectTargeted;
    private int fingerID = -1;

    private void Awake()
    {
#if !UNITY_EDITOR
                fingerID = 0; 
#endif
    }
    
    private void Start()
    {
        var indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString())
            .FirstOrDefault();
        
        _targetControllers = new List<TargetPositionInterface>()
        {
            indexController.GetComponent<TargetProductionMachine>(),
            indexController.GetComponent<TargetSettler>(),
            // indexController.GetComponent<BuildTargetPosition>()
        };

        _queryObjectTargeted =  _targetControllers.Where(controller => controller.IsPosition);

    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(fingerID))    // is the touch on the GUI
        {
            // GUI Action
            return;
        }
        
        if (isClickInObject())
        {
            Target = _queryObjectTargeted.FirstOrDefault()?.TargetPosition.transform.gameObject;
        }

        IsPosition = Target != null;
    }

    private bool isClickInObject()
    {
        return Input.GetMouseButtonDown(0);
    }

    
}
