using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public class BuildTarget : MonoBehaviour
    {
        public GameObject TargetStructure;
        public GameObject MarkerStructure;

        private TerrainTargetPosition TerrainTargetPosition;

        // Start is called before the first frame update
        void Start()
        {
            TerrainTargetPosition = GetComponent<TerrainTargetPosition>();
            MarkerStructure = Instantiate<GameObject>(TargetStructure);
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
    }
}
