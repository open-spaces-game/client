using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AI.Collection;
using AI.Scripts.Action;
using AI.Scripts.Entity;
using UnityEngine;
using Random = UnityEngine.Random;

public class NodeController : MonoBehaviour
{
   public float MaxTimeout;
   [SerializeField]
   public List<ActionCost> ActionCosts;
   
   private float timeout;
   private ActionCostCollection _actionCostAdapter;

   public ActionInterface Action => GetComponent<ActionInterface>();

   public void Start()
   {
      var enableActionCosts = ActionCosts.Where(actionCost => actionCost.Enabled)
         // .Where(actionCost => actionCost.Action.activeSelf)
         .ToList();
      
      _actionCostAdapter = new ActionCostCollection(enableActionCosts);
      _actionCostAdapter.Rechek();
      
      // gameObject.SetActive(enableActionCosts.Count > 0);
   }

   private void OnEnable()
   {
      _actionCostAdapter?.Rechek();
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
      action.EnableAction(this);
      
   }
}
