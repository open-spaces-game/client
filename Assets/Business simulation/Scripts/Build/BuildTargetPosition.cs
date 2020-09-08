using System;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using UnityEngine;

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

        private void Start()
        {
            _buildObjectColliders = FindBuilderColliders();
        }

        private void OnEnable()
        {
            _buildObjectColliders = FindBuilderColliders();
        }

        // Update is called once per frame
        void Update()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            IsPosition = _buildObjectColliders.Any(collider => collider.Raycast(_ray, out _targetPosition, Distance));
        }

        private List<Collider> FindBuilderColliders()
        {
            return GameObject.FindGameObjectsWithTag(GameTag.building.ToString())
                .Select(build => build.GetComponent<BuildBlock>().floor.GetComponent<Collider>()).ToList();
        }
    }
}