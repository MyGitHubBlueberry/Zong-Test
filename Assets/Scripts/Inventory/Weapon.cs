namespace Inventory
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Inventory Item/Weapon")]
    public class Weapon : InventoryItem
    {
        [SerializeField] SubCategory subCategory;
        [SerializeField] GameObject prefab;

        enum SubCategory
        {
            Wolf_Stone,
            Lizard_Crystal,
            Crush_Skull_Steel,
        }
    }
}