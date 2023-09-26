using Inv = Inventory.PickableItem;
using Raycast;
using UnityEngine;


namespace Inventory.InventoryItem
{
    [CreateAssetMenu(menuName = "Inventory Item/Instrument")]
    public class InstrumentInventoryItem : InventoryItem, IPickableItemHanlder
    {
        [SerializeField] Inv.Instrument prefab;
        public IPickable Setup(Transform parent)
        {
            return Inv.PickableItem.Setup(prefab, parent, this);
        }
    }
}