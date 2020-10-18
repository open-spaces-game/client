using System.Linq;
using BusinessSimulation.Enum;
using BusinessSimulation.Scripts.Build;
using BusinessSimulation.Scripts.ProductionMachine;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI.Button
{
    public class CancelButton : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;
        private GameObject _indexController;
        private ProductionMachineTarget _productionMachineTarget;
        private BuildTarget _buildTarget;

        private void Start()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            
            _indexController = GameObject.FindGameObjectsWithTag(GameTag.IndexController.ToString()).FirstOrDefault();
            if (!(_indexController is null))
            {
                _button.onClick.AddListener(this.OnClick);
                _productionMachineTarget = _indexController.GetComponent<ProductionMachineTarget>();
                _buildTarget = _indexController.GetComponent<BuildTarget>();
            }
        }

        private void OnClick()
        {
            Clear();
        }

        public void Clear()
        {
            _productionMachineTarget.enabled = false;
            _buildTarget.enabled = false;
        }
    }
}