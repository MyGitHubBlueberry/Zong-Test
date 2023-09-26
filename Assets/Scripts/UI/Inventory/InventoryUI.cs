using Core.Extentions;
using Inventory;
using Inventory.InventoryItem;
using UnityEngine;
using Base = Inventory;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] InventoryCategoryButtons categoryButtons;
        [SerializeField] WeaponSubcategoryButtons subcategoryButtons;
        [SerializeField] InventorySlotUI InventorySlotPrefab;

        Base.Inventory inventory;
        InventoryCategory currentCategory = InventoryCategory.All;
        WeaponSubcategory currentWeaponSubcategory = WeaponSubcategory.WolfStone;

        void Awake() =>
            inventory = Base.Inventory.GetPlayerInventory();


        void Start()
        {
            categoryButtons.OnCategoryChanged += Redraw;
            subcategoryButtons.OnSubcategoryChanged += Redraw;

            inventory.OnInventoryUpdated += Redraw;

            Redraw(InventoryCategory.All);
        }
        
        void Redraw() =>
            Redraw(currentCategory);


        void Redraw(WeaponSubcategory subcategory)
        {
            transform.DestroyChildren();

            currentWeaponSubcategory = subcategory;

            RedrawSomething(inventory.FindIndexesOfItemsWhichIs(subcategory));
        }

        void Redraw(InventoryCategory category)
        {
            transform.DestroyChildren();

            switch (category)
            {
                case InventoryCategory.All: 
                    currentCategory = InventoryCategory.All;
                    RedrawAllItems();
                    break;
                case InventoryCategory.Weapons:
                    currentCategory = InventoryCategory.Weapons;
                    Redraw(currentWeaponSubcategory);
                    break;
                case InventoryCategory.Instruments:
                    currentCategory = InventoryCategory.Instruments;
                    RedrawSomething(inventory.FindIndexesOfItemsWhichIs(typeof(InstrumentInventoryItem)));
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