using System;
using System.Collections.Generic;
using System.Linq;
using AI.Scripts.Action;
using BusinessSimulation.Enum;
using UI.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace AI.Scripts
{
    public class SettlerNotification : MonoBehaviour
    {
        public GameObject SettlerMessagePrefab;
        private UIController uiController;
        private Dictionary<GameObject, GameObject> messageContainers;

        private void Start()
        {
            messageContainers = new Dictionary<GameObject, GameObject>();
            uiController = Camera.main.GetComponent<UIController>();
        }

        public void Send(string message, GameObject target)
        {
            var container = FindMessageBox(target);
            var text = container.GetComponentInChildren<Text>();
            text.text = message;
            var rect = container.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(text.preferredWidth + 10, rect.sizeDelta.y);
            
            container.SetActive(true);
        }

        private GameObject FindMessageBox(GameObject target)
        {
            GameObject container;
            if (messageContainers.ContainsKey(target))
            {
                container = messageContainers.First(cursor => cursor.Key == target)
                    .Value;
            }
            else
            {
                container = Instantiate(SettlerMessagePrefab, uiController.ContainerTarget.transform, true);
                container.GetComponent<WordTargetController>().Target = target;
                messageContainers.Add(target, container);
            }

            return container;
        }
    }
}