using UnityEngine;
using Inv = Inventory.InventoryItem;

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
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("8e0fc67e-6f3b-4a32-8d4e-2af075c1ca25"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("391ff3f9-f557-422e-8889-6aa556e99a84"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("391ff3f9-f557-422e-8889-6aa556e99a84"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("63188c57-4b48-48e5-a5f4-b9b46bcaa782"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("63188c57-4b48-48e5-a5f4-b9b46bcaa782"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("63188c57-4b48-48e5-a5f4-b9b46bcaa782"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("e5e1b64b-375c-4d5e-8bf2-671f4ed5bdf1"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("e5e1b64b-375c-4d5e-8bf2-671f4ed5bdf1"));
            inventory.AddToFirstEmptySlot(Inv.InventoryItem.GetFromID("6906e61c-e18a-4cee-876b-b7938a420bea"));
        }
    }
}