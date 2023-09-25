using UnityEngine;

namespace Inventory
{    
    [CreateAssetMenu(menuName = "Inventory Item/Instrument")]
    public class Instrument : InventoryItem
    {
        [SerializeField] GameObject prefab;
    }
}