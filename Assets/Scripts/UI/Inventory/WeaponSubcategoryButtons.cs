using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;
using System;
using Inventory;


namespace UI.Inventory
{
    public class WeaponSubcategoryButtons : MonoBehaviour
    {
        public event Action<WeaponSubcategory> OnSubcategoryChange;

        [SerializeField] Transform buttonsHolder;
        [SerializeField] Button wolfStoneButton;
        [SerializeField] Button lizardCrystalButton;
        [SerializeField] Button crushSkullButton;

        void Awake()
        {
            wolfStoneButton.onClick.AddListener(() => OnSubcategoryChange?.Invoke(WeaponSubcategory.WolfStone));
            lizardCrystalButton.onClick.AddListener(() => OnSubcategoryChange?.Invoke(WeaponSubcategory.LizardCrystal));
            crushSkullButton.onClick.AddListener(() => OnSubcategoryChange?.Invoke(WeaponSubcategory.CrushSkullSteel));
        }

        void Start() =>
            Base.Inventory.GetPlayerInventory().OnInventoryUpdated += HandleButtonsVisibility;

        private void HandleButtonsVisibility(InventoryCategory category) =>
            buttonsHolder.gameObject.SetActive(category == InventoryCategory.Weapons);

    }
}