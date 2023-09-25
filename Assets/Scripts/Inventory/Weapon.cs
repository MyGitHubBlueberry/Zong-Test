namespace Inventory
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Inventory Item/Weapon")]
    public class Weapon : InventoryItem
    {
        [SerializeField] WeaponSubcategory subcategory;
        [SerializeField] GameObject prefab;

        public WeaponSubcategory Subcategory { get => subcategory; }
    }
}