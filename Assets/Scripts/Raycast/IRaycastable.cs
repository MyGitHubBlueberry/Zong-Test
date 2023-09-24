using UnityEngine;

namespace Raycast
{
    public interface IRaycastable
    {
        void HandleRaycast(RaycastHit hitInfo);
    }
}