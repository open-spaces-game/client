using System;
using UnityEngine;

namespace UI.Scripts
{
    public class UIController : MonoBehaviour
    {
        public GameObject ContainerTarget;
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        public Vector3 WorldToScreenPoint(Vector3 point)
        {
            var screenPoint = _camera.WorldToScreenPoint(point);
            //TODO:: участь сдвиг
            return screenPoint;
        }
    }
}