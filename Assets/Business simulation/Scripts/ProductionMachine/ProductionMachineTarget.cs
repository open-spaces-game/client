using System;
using System.Collections.Generic;
using BusinessSimulation.Scripts.Build;
using UnityEngine;

namespace BusinessSimulation.Scripts.ProductionMachine
{
    public class ProductionMachineTarget : MonoBehaviour
    {
        public GameObject TargetProductionMachine;
        public GameObject MarkerProductionMachine;
        
        private TerrainTargetPosition _terrainTargetPosition;
        private BuildTargetPosition _buildTargetPosition;

        void Start()
        {
            _terrainTargetPosition = GetComponent<TerrainTargetPosition>();
            _buildTargetPosition = GetComponent<BuildTargetPosition>();
        }
        
        void Update()
        {
            var TargetPosition = GetTargetPosition();
            
            if (TargetPosition != null)
            {
                MarkerProductionMachine.SetActive(true);
                MarkerProductionMachine.transform.position = GetMarkerPosition(TargetPosition);

                var isValidPlace = true; //markerStructureValidator.IsValid(buildings, MarkerStructure);
                
                var validColor = isValidPlace ? Color.white : Color.red;
                // markerStructureColor.ChangeColor(validColor);
                
                if (isValidPlace && Input.GetMouseButtonDown(0))
                {
                    GameObject Structure = Instantiate<GameObject>(TargetProductionMachine);
                    Structure.transform.position = MarkerProductionMachine.transform.position;
                }
            }
        }

        private TargetPositionInterface GetTargetPosition()
        {
            if (MarkerProductionMachine)
            {
                if (_buildTargetPosition.IsPosition)
                {
                    return _buildTargetPosition;
                }
                
                if (_terrainTargetPosition.IsPosition)
                {
                    return _terrainTargetPosition;
                }
            }

            return null;
        }

        private Vector3 GetMarkerPosition(TargetPositionInterface targetPosition)
        {
            Vector3 point = targetPosition.TargetPosition.point;

            var scale = MarkerProductionMachine.transform.localScale * 0.5f;

            var position = new Vector3(
                point.x + scale.x,
                point.y + scale.y,
                 point.z - scale.z);
             return new Vector3((int)position.x, position.y, (int)position.z);
        }

        private void OnEnable()
        {
            Clear();
        }
        
        private void OnDisable()
        {
            Clear();
        }
        
        public void SetTarget(GameObject targetPrefab, GameObject markerPrefab = null)
        {
            Clear();
            TargetProductionMachine = targetPrefab;
            MarkerProductionMachine = Instantiate(markerPrefab ? markerPrefab : targetPrefab);
        }

        public void Clear()
        {
            TargetProductionMachine = null;
            if (!(MarkerProductionMachine is null))
            {
                Destroy(MarkerProductionMachine);
                MarkerProductionMachine = null;
            }
        }
    }
}