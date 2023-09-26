using UnityEngine;

namespace Raycast
{
    public interface IRaycastable
    {
        bool HandleRaycast(RaycastHit hitInfo);
    }
}