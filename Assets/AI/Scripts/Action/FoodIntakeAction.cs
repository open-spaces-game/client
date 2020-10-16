using System;
using System.Linq;
using AI.Enum;
using AI.Service;
using BusinessSimulation.Enum;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Scripts.Action
{
    public class FoodIntakeAction : MonoBehaviour, ActionInterface
    {
        public GameObject Target;
        //TODO:: создать кеш
        private NavMeshAgent NavMeshAgent => GetComponentInParent<NavMeshAgent>();

        private void OnEnable()
        {
            GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString())
                .FirstOrDefault()
                ?.GetComponent<SettlerNotification>()
                .Send("Пора поесть", this);
            
            if (Target) {
                NavMeshAgent.destination = Target.transform.position;
                // Debug.Log(NavMeshAgent.destination);
            }
        }
    }
}