using Core.Extentions;
using Inventory;
using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] Button weaonsButton;
        [SerializeField] Button instrumentsButton;
        [SerializeField] InventorySlotUI InventorySlotPrefab;

        Base.Inventory inventory;

        void Awake() =>
            inventory = Base.Inventory.GetPlayerInventory();


        void Start()
        {
            inventory.OnInventoryUpdated += Redraw;
            Redraw();
        }

        private void Redraw()
        {
            transform.DestroyChildren();

            for (int i = 0; i < inventory.InventorySize; i++)
            {
                var itemUI = Instantiate(InventorySlotPrefab, transform);
                itemUI.Setup(inventory, i);
            }
        }
    }
}