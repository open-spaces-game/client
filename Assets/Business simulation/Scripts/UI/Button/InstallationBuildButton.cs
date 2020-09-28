using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Build;
using BusinessSimulation.Scripts.ProductionMachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace BusinessSimulation.Scripts.UI.Button
{
    public class InstallationBuildButton : MonoBehaviour, InstallationButtonInterface
    {
        public GameObject TargetPrefab { get; set; }

        private UnityEngine.UI.Button _button;
        private GameObject _indexController;
        private TerrainTargetPosition _terrainTargetPosition;
        private BuildTarget _buildTarget;

        private void Start()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            if (!(_indexController is null))
            {
                _button.onClick.AddListener(this.OnClick);
                _terrainTargetPosition = _indexController.GetComponent<TerrainTargetPosition>();
                _buildTarget = _indexController.GetComponent<BuildTarget>();
            }
        }
        
        private void OnClick()
        {
            _terrainTargetPosition.enabled = true;
            _buildTarget.enabled = true;
            _buildTarget.SetTarget(TargetPrefab, TargetPrefab);
        }
    }
}