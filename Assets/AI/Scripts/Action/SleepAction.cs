using System.Linq;
using AI.Enum;
using AI.Service;
using BusinessSimulation.Enum;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Scripts.Action
{
    public class SleepAction : MonoBehaviour, ActionInterface
    {
        public GameObject Target;
        private NavMeshAgent NavMeshAgent => GetComponentInParent<NavMeshAgent>();
        
        private void OnEnable()
        {
            Camera.main.GetComponent<SettlerNotification>()
                ?.Send("Хочу поспать", transform.parent.gameObject);
            
            if (Target) {
                NavMeshAgent.destination = Target.transform.position;
                // Debug.Log(NavMeshAgent.destination);
            }
        }
        
    }
}