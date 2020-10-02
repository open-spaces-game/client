using AI.Enum;
using UnityEngine;

namespace AI.Scripts.Action
{
    public class JobAction : MonoBehaviour, ActionInterface
    {
        public ActionCostEnum ActionCostType = ActionCostEnum.Job;
        public void Change()
        {
            gameObject.SetActive(true);
        }
    }
}