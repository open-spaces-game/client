using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                var batton = Instantiate(ButtonPrifab, transform, false);

                batton.GetComponentInChildren<Text>().text = item.Name;
                if (item.Image)
                {
                    batton.GetComponent<Image>().sprite = item.Image;
                }

                batton.GetComponent<InstallationProductionMachineButton>().ProductionMachine = item.gameObject;
            }
        }
    }
}
