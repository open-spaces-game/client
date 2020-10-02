using System.Collections.Generic;
using System.Linq;
using AI.Scripts.Action;
using AI.Scripts.Entity;
using UnityEngine;

namespace AI.Collection
{
    public class ActionCostCollection
    {
        private List<ActionCost> _actionCosts;
        public ActionCostCollection(List<ActionCost> actionCosts)
        {
            _actionCosts = actionCosts;
        }

        public ActionInterface FindByRange(float randValue)
        {
            var currentActionCost = _actionCosts
                .First(actionCost => actionCost.InRange(randValue));
            
            return currentActionCost.Action.GetComponent<ActionInterface>();
        }

        public void Rechek()
        {
            var costSum = CalculateSumCost();
            var minSum = 0.0f;
            
            foreach (var actionCost in _actionCosts)
            {
                actionCost.rangeMin = minSum;
                actionCost.rangeMax = Mathf.Min(actionCost.Cost / costSum,1);
                minSum = actionCost.rangeMax;
            }
        }

        private float CalculateSumCost()
        {
            return _actionCosts.Select(actionCost => actionCost.Cost).Sum();
        }
    }
    
    
}