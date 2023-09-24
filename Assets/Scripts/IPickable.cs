using UnityEngine;

public interface IPickable : IRaycastable
{
    void Drop(Transform tempParent);
    void Pickup(Transform parent);
}