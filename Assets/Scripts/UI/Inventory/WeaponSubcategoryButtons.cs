using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;
using System;
using Inventory;


namespace UI.Inventory
{
    public class WeaponSubcategoryButtons : MonoBehaviour
    {
        public event Action<WeaponSubcategory> OnSubcategoryChanged;

        [SerializeField] InventoryCategoryButtons categoryButtons;
        [SerializeField] Button wolfStoneButton;
        [SerializeField] Button lizardCrystalButton;
        [SerializeField] Button crushSkullButton;

        void Awake()
        {
            wolfStoneButton.onClick.AddListener(() => OnSubcategoryChanged?.Invoke(WeaponSubcategory.WolfStone));
            lizardCrystalButton.onClick.AddListener(() => OnSubcategoryChanged?.Invoke(WeaponSubcategory.LizardCrystal));
            crushSkullButton.onClick.AddListener(() => OnSubcategoryChanged?.Invoke(WeaponSubcategory.CrushSkullSteel));
        }

        void Start()
        {
            categoryButtons.OnCategoryChanged += HandleButtonsVisibility;

            gameObject.SetActive(false);
        }

        void HandleButtonsVisibility(InventoryCategory category) =>
            gameObject.SetActive(category == InventoryCategory.Weapons);

    }
}