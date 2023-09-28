using Base = Inventory;
using Raycast;
using UnityEngine;
using Inventory.InventoryItem;
using Inv = Inventory.PickableItem;
using Core.Input;

namespace Player
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] Transform head;
        [SerializeField] float dropItemOffset;

        CameraRaycaster raycaster;
        IPickable currentPickable;
        Base.Inventory inventory;

        void Awake()
        {
            raycaster = GetComponentInParent<CameraRaycaster>();
            inventory = Base.Inventory.GetPlayerInventory();
        }

        void Start()
        {
            GameInput gameInput = GetComponentInParent<GameInput>();

            gameInput.OnTryingToPickup += Pickup;
            gameInput.OnTryingToDrop += Drop;
            inventory.OnNewItemSelected += PickupFromInventory;
        }

        void PickupFromInventory(int slot)
        {
            if(slot == -1) return;
            IPickableItemHanlder itemHanlder = inventory.GetItemInSlot(slot) as IPickableItemHanlder;

            if(currentPickable is Inv.PickableItem) 
                    DeletePreviousPickable();

            if (itemHanlder is not null)
            {
                Drop();

                currentPickable = itemHanlder.Setup(transform);
            }
        }

        private void DeletePreviousPickable()
        {
            if (currentPickable is null) return;

            if (currentPickable is MonoBehaviour)
            {
                MonoBehaviour previousPickable = (MonoBehaviour)currentPickable;
                Destroy(previousPickable.gameObject);
            }

            currentPickable = null;
        }

        void Pickup()
        {
            IPickable pickable = raycaster.CurrentRaycastable as IPickable;
            if (pickable is null) return;

            if (currentPickable is not null)
            {
                if (currentPickable is not Inv.PickableItem
                    || !inventory.HasSpace()) 
                    return;
            }

            if(pickable is not Inv.PickableItem)
                inventory.DeselectItem();

            DeletePreviousPickable();

            currentPickable = pickable;
            currentPickable.Pickup(transform);
        }

        void Drop()
        {
            if (currentPickable is null) return;

            currentPickable.Drop(head);
            currentPickable = null;
        }
    }
}