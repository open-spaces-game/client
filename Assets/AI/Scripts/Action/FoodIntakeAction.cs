using AI.Enum;
using UnityEngine;

namespace AI.Scripts.Action
{
    public class FoodIntakeAction : MonoBehaviour, ActionInterface
    {
        public ActionCostEnum ActionCostType = ActionCostEnum.FoodIntake;
        public void Change()
        {
            gameObject.SetActive(true);
        }
    }
}