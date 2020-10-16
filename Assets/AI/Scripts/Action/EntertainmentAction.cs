using System;
using System.Linq;
using AI.Enum;
using AI.Service;
using BusinessSimulation.Enum;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


namespace AI.Scripts.Action
{
    public class EntertainmentAction : MonoBehaviour, ActionInterface
    {
        /// <summary>
        /// Игровые приставки или иные развлечения
        /// </summary>
        public GameObject Target;
        private NavMeshAgent NavMeshAgent => GetComponentInParent<NavMeshAgent>();
        
        private void OnEnable()
        {
            Camera.main.GetComponent<SettlerNotification>()
                ?.GetComponent<SettlerNotification>()
                .Send("Можно прогуляться", transform.parent.gameObject);
            
            if (Target) {
                NavMeshAgent.destination = Target.transform.position;
                // Debug.Log(NavMeshAgent.destination);
            }
            else
            {
                NavMeshAgent.destination = new Vector3(
                    Random.Range(-1f, 1f),
                    0,
                    Random.Range(-1f, 1f)
                ) * 10 + NavMeshAgent.transform.position;
                // Debug.Log(NavMeshAgent.destination);
            }
        }
    }
}