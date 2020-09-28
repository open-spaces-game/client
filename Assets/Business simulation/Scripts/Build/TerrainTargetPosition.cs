using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        private int fingerID = -1;

        private void Awake()
        {
        #if !UNITY_EDITOR
        fingerID = 0; 
        #endif
        }
        
        private void Start()
        {
            TerrainCollider = Terrain.GetComponent<TerrainCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            
            if (EventSystem.current.IsPointerOverGameObject(fingerID))    // is the touch on the GUI
            {
                IsPosition = false;
                // GUI Action
                return;
            }
            
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            IsPosition = TerrainCollider.Raycast(Ray, out _targetPosition, Distance);
        }

        private void OnDisable()
        {
            IsPosition = false;
        }
        
        private void OnEnable()
        {
            IsPosition = false;
        }
    }
}
