using System;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI
{
    public class DisableGameObjectTimeout : MonoBehaviour
    {
        public GameObject Target;
        public float Delay;
        private float _timeout;

        public void Start()
        {
            _timeout = Delay;
            Target = Target ? Target : gameObject;
        }

        public void OnEnable()
        {
            _timeout = Delay;
            Target = Target ? Target : gameObject;
        }

        private void Update()
        {
            _timeout -= Time.deltaTime;
            if (_timeout < 0)
            {
                _timeout = Delay;
                Target.SetActive(false);
            }
        }
    }
}