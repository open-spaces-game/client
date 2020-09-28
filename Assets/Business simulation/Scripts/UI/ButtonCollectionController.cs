using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessSimulation.Scripts.UI.Button;
using UnityEngine;
using UnityEngine.UI;

namespace BusinessSimulation.Scripts.UI
{
    public class ButtonCollectionController : MonoBehaviour
    {
        public GameObject ButtonPrifab;
        public List<GameObject> Items;

        private void Start()
        {
            var query = Items.Select(item => item.GetComponent<ProductionMachineInfo>())
                .Where(item => item != null);
            
            foreach (var item in query)
            {
                var button = Instantiate(ButtonPrifab, transform, false);

                button.GetComponentInChildren<Text>().text = item.Name;
                if (item.Image)
                {
                    button.GetComponent<Image>().sprite = item.Image;
                }

                button.GetComponent<InstallationButtonInterface>().TargetPrefab = item.gameObject;
            }
        }
    }
}
