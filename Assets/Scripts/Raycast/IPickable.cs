using UnityEngine;

namespace Raycast
{
    public interface IPickable : IRaycastable
    {
        void Drop(Transform tempParent);
        void Pickup(Transform parent);
    }
}