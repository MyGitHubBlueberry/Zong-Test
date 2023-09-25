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
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("c7070e50-8ec0-4fcf-9a28-e7d1248d34e9"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("29cc407a-9c55-49d1-b4fe-5984ab74c2a2"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("a10bd248-2e87-4cf2-ae39-a3c072ba4923"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("a10bd248-2e87-4cf2-ae39-a3c072ba4923"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("a10bd248-2e87-4cf2-ae39-a3c072ba4923"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("2d889eb8-f302-455b-8787-60e37e7a49c7"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("2d889eb8-f302-455b-8787-60e37e7a49c7"));
            inventory.AddToFirstEmptySlot(InventoryItem.GetFromID("2d889eb8-f302-455b-8787-60e37e7a49c7"));
        }
    }
}