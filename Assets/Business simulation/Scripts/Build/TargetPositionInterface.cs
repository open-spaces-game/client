using UnityEngine;

namespace BusinessSimulation.Scripts.Build
{
    public interface TargetPositionInterface
    {
        RaycastHit TargetPosition { get; }
        bool IsPosition { get; }
    }
}