using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AI.Collection;
using AI.Scripts.Entity;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
   public float MaxTimeout;
   private float timeout;
   private ActionCostCollection _actionCostAdapter;

   public void Start()
   {
      var actionCosts = GetComponents<ActionCost>().Where(actionCost => actionCost.enabled).ToList();
      _actionCostAdapter = new ActionCostCollection(actionCosts);
      _actionCostAdapter.Rechek();
   }

   private void OnEnable()
   {
      _actionCostAdapter.Rechek();
   }

   private void Update()
   {
      timeout += Time.deltaTime;
      if (timeout > MaxTimeout)
      {
         timeout = 0;
         ChangeAction();
      }
   }
   
   private void ChangeAction()
   {
      float randValue = Random.Range(0.0f, 1.0f);

      var action = _actionCostAdapter.FindByRange(randValue);
      action.Change();
      gameObject.SetActive(false);
   }
}
