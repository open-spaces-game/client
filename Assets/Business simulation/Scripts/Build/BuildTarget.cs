using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using UnityEngine;
using UnityEngine.Serialization;

namespace BusinessSimulation.Scripts.Build
{
    public class BuildTarget : MonoBehaviour
    {
        [FormerlySerializedAs("TargetStructure")] 
        public GameObject targetStructure;
        [FormerlySerializedAs("MarkerStructure")] 
        public GameObject markerStructure;

        private TerrainTargetPosition _terrainTargetPosition;
        private List<GameObject> _buildings;
        private MarkerStructureValidator _markerStructureValidator;
        private MarkerStructureColor _markerStructureColor;

        // Start is called before the first frame update
        void Start()
        {
            _terrainTargetPosition = GetComponent<TerrainTargetPosition>();
            _buildings = FindBuildings(); 
        }

        // Update is called once per frame
        void Update()
        {
            if (markerStructure && _terrainTargetPosition.IsPosition)
            {
                markerStructure.SetActive(true);
                markerStructure.transform.position = GetMarkerPosition();
                
                var isValidPlace = _markerStructureValidator.IsValid(_buildings, markerStructure);
                
                var validColor = isValidPlace ? Color.white : Color.red;
                _markerStructureColor.ChangeColor(validColor);
                
                if (isValidPlace && Input.GetMouseButtonDown(0))
                {
                    GameObject Structure = Instantiate<GameObject>(targetStructure);
                    Structure.transform.position = markerStructure.transform.position;
                    _buildings.Add(Structure);
                }
            }
            else
            {
                markerStructure.SetActive(false);
            }
        }

        private Vector3 GetMarkerPosition()
        {
            Vector3 point = _terrainTargetPosition.TargetPosition.point;
            return new Vector3(
                (int)point.x,
                point.y + markerStructure.transform.localScale.y * 0.5f,
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
            targetStructure = targetPrefab;
            markerStructure = Instantiate(markerPrefab ? markerPrefab : targetPrefab);
            markerStructure = Instantiate<GameObject>(targetStructure);
            _markerStructureValidator = markerStructure.AddComponent<MarkerStructureValidator>();
            _markerStructureColor = markerStructure.AddComponent<MarkerStructureColor>();
        }

        public void Clear()
        {
            targetStructure = null;
            if (!(markerStructure is null))
            {
                Destroy(markerStructure);
                markerStructure = null;
            }
        }
    }
}
