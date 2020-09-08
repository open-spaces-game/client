using System;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public class MarkerStructureValidator : MonoBehaviour
    {
        private bool isValid = true;
        private string tag;

        private void Start()
        {
            tag = GameTag.building.ToString();
            
            foreach (var colliderChild in GetComponentsInChildren<Collider>())
            {
                colliderChild.isTrigger = true;
            }
            
            gameObject.AddComponent<Rigidbody>();

        }

        public bool IsValid(List<GameObject> buildings, GameObject markerStructure)
        {
            return true || isValid;
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.transform.parent && other.transform.parent.CompareTag(tag))
            {
                isValid = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.transform.parent && other.transform.parent.CompareTag(tag))
            {
                isValid = true;
            }
        }
    }
}