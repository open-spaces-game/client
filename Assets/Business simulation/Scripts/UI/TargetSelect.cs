using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Build;
using BusinessSimulation.Scripts.Target;
using UnityEngine;

public class TargetSelect : MonoBehaviour
{
    public GameObject Target;

    private List<TargetPositionInterface> _targetControllers;
    private IEnumerable<TargetPositionInterface> _queryObjectTargeted;

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
        if (isClickInObject())
        {
            Target = _queryObjectTargeted.FirstOrDefault()?.TargetPosition.transform.gameObject;
        }
    }

    private bool isClickInObject()
    {
        return Input.GetMouseButtonDown(0);
    }
}
