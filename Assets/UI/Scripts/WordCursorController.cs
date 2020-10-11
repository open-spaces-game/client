using System;
using System.Linq;
using UnityEngine;

namespace UI.Scripts
{
    public class WordCursorController : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            
            _rectTransform.anchoredPosition = Input.mousePosition;
        }

        private void Update()
        {
            _rectTransform.anchoredPosition = Input.mousePosition;
        }
    }
}