using System;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BusinessSimulation.Scripts.Build
{
    public class BuildTargetPosition : MonoBehaviour, TargetPositionInterface
    {
        public float Distance = 1000;

        public RaycastHit TargetPosition
        {
            get { return _targetPosition; }
        }
        public RaycastHit _targetPosition;
        public bool IsPosition { get; private set; }
        
        
        private List<Collider> _buildObjectColliders;
        private RaycastHit _hit;
        private Ray _ray;
        private int fingerID = -1;

        private void Awake()
        {
        #if !UNITY_EDITOR
                fingerID = 0; 
        #endif
        }

        private void Start()
        {
            _buildObjectColliders = FindBuilderColliders();
        }

        private void OnEnable()
        {
            IsPosition = false;
            _buildObjectColliders = FindBuilderColliders();
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
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            IsPosition = _buildObjectColliders.Any(collider => collider.Raycast(_ray, out _targetPosition, Distance));
        }

        private List<Collider> FindBuilderColliders()
        {
            return GameObject.FindGameObjectsWithTag(GameTag.building.ToString())
                .Select(build => build.GetComponent<BuildBlock>().floor.GetComponent<Collider>()).ToList();
        }
        
        private void OnDisable()
        {
            IsPosition = false;
        }
    }
}