using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public class BuildTarget : MonoBehaviour
    {
        public GameObject TargetStructure;
        public GameObject MarkerStructure;

        private TerrainTargetPosition TerrainTargetPosition;
        private List<GameObject> buildings;

        // Start is called before the first frame update
        void Start()
        {
            TerrainTargetPosition = GetComponent<TerrainTargetPosition>();
            MarkerStructure = Instantiate<GameObject>(TargetStructure);
            buildings = FindBuildings(); 
        }

        // Update is called once per frame
        void Update()
        {
            if (MarkerStructure && TerrainTargetPosition.IsPosition)
            {
                MarkerStructure.SetActive(true);
                MarkerStructure.transform.position = GetMarkerPosition();
                if (Input.GetMouseButtonDown(0))
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
                return  GameObject.FindGameObjectsWithTag("building").ToList();
            }
            catch (Exception e)
            {
                return new List<GameObject>();
            }
        }
    }
}
