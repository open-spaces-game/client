using AI.Enum;
using UnityEngine;

namespace AI.Scripts.Action
{
    public class SleepAction : MonoBehaviour, ActionInterface
    {
        public ActionCostEnum ActionCostType = ActionCostEnum.Sleep;
        public void Change()
        {
            gameObject.SetActive(true);
        }
    }
}