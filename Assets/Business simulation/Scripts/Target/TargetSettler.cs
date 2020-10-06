using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Build;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BusinessSimulation.Scripts.Target
{
    public class TargetSettler : MonoBehaviour, TargetPositionInterface
    {
        public float Distance = 1000;

        public RaycastHit TargetPosition => _targetPosition;
        private RaycastHit _targetPosition;
        public bool IsPosition { get; private set; }
        
        
        private List<Collider> _settlerObjectColliders;
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
            _settlerObjectColliders = FindSettlerColliders();
        }

        private void OnEnable()
        {
            IsPosition = false;
            _settlerObjectColliders = FindSettlerColliders();
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
            IsPosition = _settlerObjectColliders.Any(collider => collider.Raycast(_ray, out _targetPosition, Distance));
        }

        private List<Collider> FindSettlerColliders()
        {
            return GameObject.FindGameObjectsWithTag(GameTag.Settler.ToString())
                .Select(settler => settler.GetComponent<Collider>()).ToList();
        }
        
        private void OnDisable()
        {
            IsPosition = false;
        }

        public void Recheck()
        {
            _settlerObjectColliders = FindSettlerColliders();
        }
    }
}