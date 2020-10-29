using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Build;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BusinessSimulation.Scripts.Target
{
    /// <summary>
    /// переименовать в курсор ибо мы оперируем курсором
    /// </summary>
    public class TargetProductionMachine : MonoBehaviour, TargetPositionInterface
    {
        public float Distance = 1000;

        public RaycastHit TargetPosition => _targetPosition;
        private RaycastHit _targetPosition;
        public bool IsPosition { get; private set; }
        
        
        private List<Collider> _productionMachineObjectColliders;
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
            _productionMachineObjectColliders = FindProductionMachineColliders();
        }

        private void OnEnable()
        {
            IsPosition = false;
            _productionMachineObjectColliders = FindProductionMachineColliders();
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
            IsPosition = _productionMachineObjectColliders.Any(collider => collider.Raycast(_ray, out _targetPosition, Distance));
        }

        private List<Collider> FindProductionMachineColliders()
        {
            return GameObject.FindGameObjectsWithTag(GameTag.ProductionMachine.ToString())
                .Select(productionMachine => productionMachine.GetComponent<Collider>()).ToList();
        }
        
        private void OnDisable()
        {
            IsPosition = false;
        }

        public void Recheck()
        {
            _productionMachineObjectColliders = FindProductionMachineColliders();
        }
    }
}