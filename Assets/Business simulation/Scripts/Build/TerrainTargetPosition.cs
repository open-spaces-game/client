using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public class TerrainTargetPosition : MonoBehaviour, TargetPositionInterface
    {
        public GameObject Terrain;
        public float Distance = 1000;
        public RaycastHit TargetPosition
        {
            get { return _targetPosition; }
        }
        public RaycastHit _targetPosition;
        public bool IsPosition { get; private set; }

        private TerrainCollider TerrainCollider;
        private RaycastHit Hit;
        private Ray Ray;

        private void Start()
        {
            TerrainCollider = Terrain.GetComponent<TerrainCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            IsPosition = TerrainCollider.Raycast(Ray, out _targetPosition, Distance);
        }
    }
}
