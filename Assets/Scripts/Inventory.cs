using System;
using Core;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action<int> OnNewItemSelected;
        public event Action OnInventoryUpdated;

        [SerializeField] int inventorySize = 16;

        public int InventorySize { get => inventorySize; }

        InventoryItem[] inventoryItems;

        public static Inventory GetPlayerInventory()
        {
            var player = GameObject.FindWithTag(nameof(Tag.Player));
            return player.GetComponent<Inventory>();
        }

        public void SetSelectedItem(int slot)
        {
            OnNewItemSelected?.Invoke(slot);
        }

        public InventoryItem GetItemInSlot(int slot)
        {
            return inventoryItems[slot];
        }

        public void RemoveFromSlot(int slot, int number)
        {
            inventoryItems[slot] = null;
            OnInventoryUpdated?.Invoke();
        }
        public bool AddToFirstEmptySlot(InventoryItem item)
        {
            int i = FindEmptySlot();

            if (i < 0) return false;

            inventoryItems[i] = item;

            OnInventoryUpdated?.Invoke();

            return true;
        }


        void Awake()
        {
            inventoryItems = new InventoryItem[inventorySize];
        }

        int FindEmptySlot()
        {
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}