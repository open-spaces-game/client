using AI.Scripts.Action;
using UnityEngine;

namespace AI.Scripts
{
    public class SettlerNotification : MonoBehaviour
    {
        public void Send(string message, MonoBehaviour target)
        {
            Debug.Log(message, target);
        }
    }
}