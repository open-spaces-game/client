using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulation.Scripts.UI.Button
{
    public class TabButton : MonoBehaviour
    {
        public string Name;
        public GameObject TabContent;
        public GameObject TabPanel;

        public void OnClick()
        {
            TabPanel.GetComponent<PanelScrollViewController>().ActiveTab(Name, TabContent);
        }
    }    
}

