
using System;
using System.Linq;
using Core;
using Core.Input;
using TMPro;
using UnityEngine;
using Inv = Inventory;

namespace UI.Inventory
{
    public class ShowHideInventoryUI : MonoBehaviour
    {
        public event Action<bool> OnInventoryShowed;
        public event Action OnInventoryBecomeAvailable;
        [SerializeField] GameInput gameInput;

        Inv.Inventory inventory;
        bool redraw;

        void Awake()
        {
            inventory = Inv.Inventory.GetPlayerInventory();

            gameInput.OnTryingToToggleInventory += ToggleVisibility;
            OnInventoryBecomeAvailable?.Invoke();
        }

        void ToggleVisibility()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            if (!gameObject.activeSelf)
            {
                inventory.OnInventoryUpdated += TellToRedrawIfThereWereChanges;
            }
            else
            {
                OnInventoryShowed?.Invoke(redraw);
                inventory.OnInventoryUpdated -= TellToRedrawIfThereWereChanges;
                redraw = false;
            }
        }

        void TellToRedrawIfThereWereChanges() => redraw = true;
    }
}