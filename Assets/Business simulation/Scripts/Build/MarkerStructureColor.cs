using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public class MarkerStructureColor : MonoBehaviour
    {
        private MeshRenderer[] _meshRenderers;

        private void Start()
        {
            _meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        public void ChangeColor(Color color)
        {
            foreach (var meshRenderer in _meshRenderers)
            {
                meshRenderer.material.color = color;
            }
        }
    }
}