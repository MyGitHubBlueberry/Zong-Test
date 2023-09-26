using Inv = Inventory.PickableItem;
using Raycast;
using UnityEngine;

namespace Inventory.InventoryItem
{
    [CreateAssetMenu(menuName = "Inventory Item/Weapon")]
    public class WeaponInventoryItem : InventoryItem, IPickableItemHanlder
    {
        public WeaponSubcategory Subcategory { get => subcategory; }

        [SerializeField] WeaponSubcategory subcategory;
        [SerializeField] Inv.Weapon prefab;

        public IPickable Setup(Transform parent)
        {
            return Inv.PickableItem.Setup(prefab, parent, this);
        }
    }
}