﻿using AI.Enum;
using AI.Service;
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
            Debug.Log("Хочу поспать", this);
            if (Target) {
                NavMeshAgent.destination = Target.transform.position;
                // Debug.Log(NavMeshAgent.destination);
            }
        }
        
    }
}