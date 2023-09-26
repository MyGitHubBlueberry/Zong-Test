using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Inventory.InventoryItem;
using UnityEngine;
using Inv = Inventory.InventoryItem;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public event Action<int> OnNewItemSelected;
        public event Action OnInventoryUpdated;

        public int InventorySize { get => inventorySize; }
        public int SelectedItem { get; private set; }

        [SerializeField] int inventorySize = 16;

        Inv.InventoryItem[] inventoryItems;

        public static Inventory GetPlayerInventory()
        {
            var player = GameObject.FindWithTag(nameof(Tag.Player));
            return player.GetComponent<Inventory>();
        }
        
        public bool HasSpace()
        {
            return FindEmptySlot() > 0;
        }

        public void SetSelectedItem(int slot)
        {
            SelectedItem = slot;
            OnNewItemSelected?.Invoke(slot);
        }

        public void SetInventoryCategory(InventoryCategory category)
        {
            OnInventoryUpdated?.Invoke();
        }

        public Inv.InventoryItem GetItemInSlot(int slot)
        {
            return inventoryItems[slot];
        }

        public void RemoveFromSlot(Inv.InventoryItem item)
        {
            int slot = Array.IndexOf(inventoryItems, item);
            if (slot != -1) RemoveFromSlot(slot);
        }

        public void RemoveFromSlot(int slot)
        {
            inventoryItems[slot] = null;
            OnInventoryUpdated?.Invoke();
        }

        public bool AddToFirstEmptySlot(Inv.InventoryItem item)
        {
            return AddToFirstEmptySlot(item, false);
        }

        public bool AddToFirstEmptySlot(Inv.InventoryItem item, bool selectItem)
        {
            int i = FindEmptySlot();

            if (i < 0) return false;

            inventoryItems[i] = item;

            OnInventoryUpdated?.Invoke();
            if (selectItem) SetSelectedItem(i);

            return true;
        }
        
        public int[] FindIndexesOfItemsWhichIs(WeaponSubcategory weaponSubcategory)
        {
            int[] weaponIndexes = FindIndexesOfItemsWhichIs(typeof(WeaponInventoryItem));
            List<int> indexes = new List<int>();

            for (int i = 0; i < weaponIndexes.Length; i++)
            {
                WeaponInventoryItem weapon = (WeaponInventoryItem)GetItemInSlot(weaponIndexes[i]);
                if (weapon.Subcategory == weaponSubcategory)
                {
                    indexes.Add(weaponIndexes[i]);
                }

            }

            return indexes.ToArray();
        }

        public int[] FindIndexesOfItemsWhichIs(Type type)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < inventoryItems.Length; i++)
                if (inventoryItems[i] is not null && inventoryItems[i].GetType() == type)
                    indexes.Add(i);

            return indexes.ToArray();
        }

        void Awake()
        {
            inventoryItems = new Inv.InventoryItem[inventorySize];
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