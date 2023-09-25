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

        Base.Inventory inventory;

        void Awake() =>
            inventory = Base.Inventory.GetPlayerInventory();


        void Start()
        {
            inventory.OnInventoryUpdated += Redraw;
            Redraw(InventoryCategory.All);
        }

        private void Redraw(InventoryCategory category)
        {
            transform.DestroyChildren();

            switch (category)
            {
                case InventoryCategory.All: 
                    RedrawAllItems();
                    break;
                case InventoryCategory.Weapons:
                    RedrawSomething(inventory.WeaponIndexes);
                    break;
                case InventoryCategory.Instruments:
                    RedrawSomething(inventory.InstrumentIndexes);
                    break;
            }
        }

        private void RedrawAllItems()
        {
            for (int i = 0; i < inventory.InventorySize; i++)
            {
                var itemUI = Instantiate(InventorySlotPrefab, transform);
                itemUI.Setup(inventory, i);
            }
        }

        private void RedrawSomething(int[] indexesOfSomethingToRedraw)
        {
            foreach(int index in indexesOfSomethingToRedraw)
            {
                var itemUI = Instantiate(InventorySlotPrefab, transform);
                itemUI.Setup(inventory, index);
            }
        }
    }
}