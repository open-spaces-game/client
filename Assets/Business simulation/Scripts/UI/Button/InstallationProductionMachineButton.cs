using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Build;
using BusinessSimulation.Scripts.ProductionMachine;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI.Button
{
    public class InstallationProductionMachineButton : MonoBehaviour, InstallationButtonInterface
    {
        public GameObject TargetPrefab
        {
            get => _targetPrefab;
            set
            {
                _targetPrefab = value;
            }
        }

        private UnityEngine.UI.Button _button;
        private GameObject _targetPrefab;
        private GameObject _indexController;
        private ProductionMachineTarget _productionMachineTarget;
        private BuildTargetPosition _buildTargetPosition;

        private void Start()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _button.onClick.AddListener(this.OnClick);
            
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            if (!(_indexController is null))
            {
                _buildTargetPosition = _indexController.GetComponent<BuildTargetPosition>();
                _productionMachineTarget = _indexController.GetComponent<ProductionMachineTarget>();
            }
        }
        
        private void OnClick()
        {
            _buildTargetPosition.enabled = true;
            _productionMachineTarget.enabled = true;

            _productionMachineTarget.SetTarget(TargetPrefab, TargetPrefab);
        }
    }
}