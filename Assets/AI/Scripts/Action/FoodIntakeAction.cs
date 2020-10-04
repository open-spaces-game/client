using AI.Enum;
using AI.Service;
using UnityEngine;

namespace AI.Scripts.Action
{
    public class FoodIntakeAction : MonoBehaviour, ActionInterface
    {
        public ActionCostEnum ActionCostType = ActionCostEnum.FoodIntake;
        private NodeController _nodeController => GetComponent<NodeController>();

        public void EnableAction(NodeController nodeController)
        {
            (new EnableActionService()).EnableAction(_nodeController, nodeController);
        }
    }
}