using System.Collections.Generic;
using BusinessSimulation.Enum;
using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public class MarkerStructureColliderEnter: MonoBehaviour
    {
        private bool isValid = true;
        private string tag;
        
        private BuildBlock buildBlock;

        private void Start()
        {
            tag = GameTag.building.ToString();
            
            foreach (var colliderChild in GetComponentsInChildren<Collider>())
            {
                colliderChild.isTrigger = true;
            }
            
            gameObject.AddComponent<Rigidbody>();
        }

        public BuildBlock GetColliderStructure()
        {
            return buildBlock;
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.transform.parent && other.transform.parent.CompareTag(tag))
            {
                buildBlock = other.transform.parent.GetComponent<BuildBlock>();
                isValid = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.transform.parent && other.transform.parent.CompareTag(tag))
            {
                buildBlock = null;
            }
        }
    }
}