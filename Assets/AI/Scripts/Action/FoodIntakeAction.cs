using System;
using System.Linq;
using AI.Enum;
using AI.Service;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts;
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
            Camera.main.GetComponent<SettlerNotification>()
                ?.GetComponent<SettlerNotification>()
                .Send("Пора поесть", GetComponentInParent<PersonalCharacteristic>().gameObject);
            
            if (Target) {
                NavMeshAgent.destination = Target.transform.position;
            }
        }
    }
}