using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public class BuildTarget : MonoBehaviour
    {
        public GameObject TargetStructure;
        public GameObject MarkerStructure;

        private TerrainTargetPosition TerrainTargetPosition;
        private List<GameObject> buildings;
        private MarkerStructureValidator markerStructureValidator;
        private MarkerStructureColor markerStructureColor;

        // Start is called before the first frame update
        void Start()
        {
            TerrainTargetPosition = GetComponent<TerrainTargetPosition>();
            MarkerStructure = Instantiate<GameObject>(TargetStructure);
            markerStructureValidator = MarkerStructure.AddComponent<MarkerStructureValidator>();
            markerStructureColor = MarkerStructure.AddComponent<MarkerStructureColor>();
            buildings = FindBuildings(); 
        }

        // Update is called once per frame
        void Update()
        {
            if (MarkerStructure && TerrainTargetPosition.IsPosition)
            {
                MarkerStructure.SetActive(true);
                MarkerStructure.transform.position = GetMarkerPosition();
                
                var isValidPlace = markerStructureValidator.IsValid(buildings, MarkerStructure);
                
                var validColor = isValidPlace ? Color.white : Color.red;
                markerStructureColor.ChangeColor(validColor);
                
                if (isValidPlace && Input.GetMouseButtonDown(0))
                {
                    GameObject Structure = Instantiate<GameObject>(TargetStructure);
                    Structure.transform.position = MarkerStructure.transform.position;
                    buildings.Add(Structure);
                }
            }
            else
            {
                MarkerStructure.SetActive(false);
            }
        }

        private Vector3 GetMarkerPosition()
        {
            Vector3 point = TerrainTargetPosition.TargetPosition.point;
            return new Vector3(
                (int)point.x,
                point.y + MarkerStructure.transform.localScale.y * 0.5f,
                (int)point.z);
        }
        
        
        private List<GameObject> FindBuildings()
        {
            try
            {
                return  GameObject.FindGameObjectsWithTag(GameTag.building.ToString()).ToList();
            }
            catch (Exception e)
            {
                return new List<GameObject>();
            }
        }
        
        private void OnEnable()
        {
            Clear();
        }
        
        private void OnDisable()
        {
            Clear();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetPrefab"></param>
        /// <param name="markerPrefab"></param>
        public void SetTarget(GameObject targetPrefab, GameObject markerPrefab)
        {
            Clear();
            TargetStructure = targetPrefab;
            MarkerStructure = Instantiate(markerPrefab ? markerPrefab : targetPrefab);
        }

        public void Clear()
        {
            TargetStructure = null;
            if (!(MarkerStructure is null))
            {
                Destroy(MarkerStructure);
                MarkerStructure = null;
            }
        }
    }
}
