using System;
using System.Collections;
using System.ComponentModel;
using Core.Extentions;
using Inventory;
using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] InventoryCategoryButtons categoryButtons;
        [SerializeField] InventorySlotUI InventorySlotPrefab;
        [SerializeField] WeaponSubcategoryButtons buttons;

        Base.Inventory inventory;

        void Awake() =>
            inventory = Base.Inventory.GetPlayerInventory();


        void Start()
        {
            inventory.OnInventoryUpdated += Redraw;
            buttons.OnSubcategoryChange += Redraw;

            Redraw(InventoryCategory.All);
        }
        
        void Redraw(WeaponSubcategory subcategory)
        {
            transform.DestroyChildren();

            RedrawSomething(inventory.FindIndexesOfItemsWhichIs(subcategory));
        }

        void Redraw(InventoryCategory category)
        {
            transform.DestroyChildren();

            switch (category)
            {
                case InventoryCategory.All: 
                    RedrawAllItems();
                    break;
                case InventoryCategory.Weapons:
                    RedrawSomething(inventory.FindIndexesOfItemsWhichIs(typeof(Weapon)));
                    break;
                case InventoryCategory.Instruments:
                    RedrawSomething(inventory.FindIndexesOfItemsWhichIs(typeof(Instrument)));
                    break;
            }
        }

        void RedrawAllItems()
        {
            for (int i = 0; i < inventory.InventorySize; i++)
            {
                var itemUI = Instantiate(InventorySlotPrefab, transform);
                itemUI.Setup(inventory, i);
            }
        }

        void RedrawSomething(int[] indexesOfSomethingToRedraw)
        {
            foreach(int index in indexesOfSomethingToRedraw)
            {
                var itemUI = Instantiate(InventorySlotPrefab, transform);
                itemUI.Setup(inventory, index);
            }
        }
    }
}