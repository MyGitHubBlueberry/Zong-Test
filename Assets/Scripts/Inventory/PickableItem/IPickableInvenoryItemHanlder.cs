using Raycast;
using UnityEngine;

namespace Inventory.InventoryItem
{
    interface IPickableItemHanlder
    {
        IPickable Setup(Transform parent);
    }
}