using Core.Input;
using UI.Inventory;
using UnityEngine;

namespace Core
{

    public class MouseLockHandler : MonoBehaviour
    {
        [SerializeField] ShowHideInventoryUI inventoryUI;

        GameInput gameInput;
        Rotator rotator;

        void Awake()
        {
            rotator = GetComponent<Rotator>();
            gameInput = GetComponent<GameInput>();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            inventoryUI.OnInventoryBecomeAvailable += () =>
            {
                gameInput.OnTryingToToggleInventory += ToggleMouseVisibility;
                ToggleMouseVisibility();
            };
        }

        private void ToggleMouseVisibility()
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            rotator.enabled = !Cursor.visible;
        }
    }
}