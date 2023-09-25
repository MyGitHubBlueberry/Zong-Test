using System;
using Inventory;
using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;

namespace UI.Inventory
{

    public partial class InventoryCategoryButtons : MonoBehaviour
    {
        [SerializeField] Button allButton;
        [SerializeField] Button weaponsButton;
        [SerializeField] Button instrumentsButton;

        Base.Inventory inventory;

        void Awake()
        {
            inventory = Base.Inventory.GetPlayerInventory();

            allButton.onClick.AddListener(() => HandleCategorySelection(InventoryCategory.All));
            weaponsButton.onClick.AddListener(() => HandleCategorySelection(InventoryCategory.Weapons));
            instrumentsButton.onClick.AddListener(() => HandleCategorySelection(InventoryCategory.Instruments));
        }

        private void HandleCategorySelection(InventoryCategory category) =>
            inventory.SetInventoryCategory(category);
    }
}