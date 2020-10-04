using UnityEngine;

namespace AI.Scripts.Action
{
    public interface ActionInterface
    {
        GameObject gameObject { get; }
        bool enabled { get; set; }
        // NodeController NodeController { get; }
        
        
        void EnableAction(NodeController nodeController);
        // void DisableAction();
    }
}