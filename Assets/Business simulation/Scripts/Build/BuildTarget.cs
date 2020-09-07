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
        private MarkerStructureColliderEnter markerStructureColliderEnter;
        private MarkerStructureColor markerStructureColor;

        // Start is called before the first frame update
        void Start()
        {
            TerrainTargetPosition = GetComponent<TerrainTargetPosition>();
            MarkerStructure = Instantiate<GameObject>(TargetStructure);
            markerStructureColliderEnter = MarkerStructure.AddComponent<MarkerStructureColliderEnter>();
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
                
                var structure = markerStructureColliderEnter.GetColliderStructure();
                var isValidPlace = structure == null;
                var validColor = isValidPlace ? Color.white : Color.red;
                markerStructureColor.ChangeColor(validColor);
                // Если есть строение то нужно проверить можно ли к нему присоединить блок
                // Если нет то создаём новое строение и помещаем блок в нутрь этого строения
                if (isValidPlace && Input.GetMouseButtonDown(0))
                {
                    GameObject Structure = Instantiate<GameObject>(TargetStructure);
                    Structure.transform.position = MarkerStructure.transform.position;
                    var build = new GameObject("build");
                    
                    build.transform.position = Structure.transform.position;
                    Structure.transform.parent = build.transform;
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
    }
}
