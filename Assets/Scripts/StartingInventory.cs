using UnityEngine;

namespace Inventory
{
    [RequireComponent(typeof(Inventory))]
    public class StartingInventory : MonoBehaviour
    {
        Inventory inventory;

        void Awake() =>
            inventory = GetComponent<Inventory>();

        void Start()
        {
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("34ed4a4a-2975-423a-8bcc-6ff69afc7e71"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("d5258ad8-2448-4907-8628-76bf5baa0540"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("c2303bd0-5072-43f0-90c1-cbab817bf5cc"));
        }
    }
}