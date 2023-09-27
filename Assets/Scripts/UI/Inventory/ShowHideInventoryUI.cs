
using System;
using Core.Input;
using UnityEngine;
using Inv = Inventory;

namespace UI.Inventory
{
    public class ShowHideInventoryUI : MonoBehaviour
    {
        public Action<bool> OnInventoryShowed;
        [SerializeField] GameInput gameInput;

        Inv.Inventory inventory;
        bool redraw;

        void Awake()
        {
            inventory = Inv.Inventory.GetPlayerInventory();
            IMainUIShowTrigger.OnAnyMainUIShowRequest += UseOnlyOneCall;
        }

        private void UseOnlyOneCall()
        {
            gameInput.OnTryingToToggleInventory += ToggleVisibility;
            IMainUIShowTrigger.OnAnyMainUIShowRequest -= UseOnlyOneCall;
        }

        void ToggleVisibility()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            if(!gameObject.activeSelf)
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