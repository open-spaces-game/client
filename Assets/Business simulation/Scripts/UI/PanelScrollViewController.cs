using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI
{
    public class PanelScrollViewController : MonoBehaviour
    {
        public GameObject ContentContainer;

        private Dictionary<string, GameObject> tabs;

        private void Start()
        {
            tabs = new Dictionary<string, GameObject>();
        }

        public void Clear()
        {
            foreach (var tabContent in tabs.Select(tab => tab.Value))
            {
                tabContent.SetActive(false);
            }
        }

        public void ActiveTab(string name, GameObject tabContent)
        {
            Clear();
            if (tabs.ContainsKey(name))
            {
                tabs[name].SetActive(true);
            }
            else
            {
                tabContent = Instantiate(tabContent, ContentContainer.transform, true);
                tabs.Add(name, tabContent);
            }
        }
    }
}