using AI.Scripts.Action;
using UnityEngine;

namespace AI.Service
{
    public class EnableActionService
    {
        public void EnableAction(NodeController enableNode, NodeController disableNode)
        {
            if (enableNode.Action != disableNode.Action)
            {
                // Debug.Log("Disable" + disableNode.Action);
                disableNode.enabled = false;
                disableNode.Action.enabled = false;
            }
          
            // Debug.Log("Enable" + enableNode.Action);
            enableNode.enabled = true;
            enableNode.Action.enabled = true;
        }
    }
}