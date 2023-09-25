using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action<int> OnNewItemSelected;
        public event Action<InventoryCategory> OnInventoryUpdated;

        public int InventorySize { get => inventorySize; }
        public int[] WeaponIndexes { get => FindIndexesOfItemsWhichIs(typeof(Weapon)); }
        public int[] InstrumentIndexes { get => FindIndexesOfItemsWhichIs(typeof(Instrument)); }

        [SerializeField] int inventorySize = 16;

        InventoryItem[] inventoryItems;
        InventoryCategory currentCategory = InventoryCategory.All;

        public static Inventory GetPlayerInventory()
        {
            var player = GameObject.FindWithTag(nameof(Tag.Player));
            return player.GetComponent<Inventory>();
        }

        public void SetSelectedItem(int slot)
        {
            OnNewItemSelected?.Invoke(slot);
        }

        public void SetInventoryCategory(InventoryCategory category)
        {
            OnInventoryUpdated?.Invoke(category);
        }

        public InventoryItem GetItemInSlot(int slot)
        {
            return inventoryItems[slot];
        }

        public void RemoveFromSlot(int slot)
        {
            inventoryItems[slot] = null;
            OnInventoryUpdated?.Invoke(currentCategory);
        }

        public bool AddToFirstEmptySlot(InventoryItem item)
        {
            int i = FindEmptySlot();

            if (i < 0) return false;

            inventoryItems[i] = item;

            OnInventoryUpdated?.Invoke(currentCategory);

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

        int[] FindIndexesOfItemsWhichIs(Type t)
        {
            return inventoryItems.Select((item, index) => new { item, index })
                   .Where(pair => pair.item is not null && pair.item.GetType() == t)
                   .Select(pair => pair.index)
                   .ToArray();
        }
    }
}