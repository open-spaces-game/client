using AI.Enum;
using UnityEngine;

namespace AI.Scripts.Action
{
    public class EntertainmentAction : MonoBehaviour, ActionInterface
    {
        public ActionCostEnum ActionCostType = ActionCostEnum.Entertainment;
        public void Change()
        {
            gameObject.SetActive(true);
        }
    }
}