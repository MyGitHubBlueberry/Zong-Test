using System;
using Inventory;
using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;

namespace UI.Inventory
{

    public partial class InventoryCategoryButtons : MonoBehaviour
    {
        public event Action<InventoryCategory> OnCategoryChanged;
        [SerializeField] Button allButton;
        [SerializeField] Button weaponsButton;
        [SerializeField] Button instrumentsButton;

        void Awake()
        {
            allButton.onClick.AddListener(() => OnCategoryChanged?.Invoke(InventoryCategory.All));
            weaponsButton.onClick.AddListener(() => OnCategoryChanged?.Invoke(InventoryCategory.Weapons));
            instrumentsButton.onClick.AddListener(() => OnCategoryChanged?.Invoke(InventoryCategory.Instruments));
        }
    }
}