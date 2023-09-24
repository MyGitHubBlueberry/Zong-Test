using Core;
using Raycast;
using UnityEngine;

namespace Player
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] Transform head;
        [SerializeField] float dropItemOffset;
        CameraRaycaster raycaster;
        IPickable currentPickable;

        void Awake() =>
            raycaster = GetComponentInParent<CameraRaycaster>();

        void Start()
        {
            GameInput gameInput = GetComponentInParent<GameInput>();

            gameInput.OnTryingToPickup += Pickup;
            gameInput.OnTryingToDrop += Drop;
        }

        void Pickup()
        {
            if (currentPickable is not null) return;

            IPickable pickable = raycaster.CurrentRaycastable as IPickable;
            if (pickable is null) return;

            currentPickable = pickable;
            pickable.Pickup(transform);
        }

        private void Drop()
        {
            if (currentPickable is null) return;

            currentPickable.Drop(head);
            currentPickable = null;
        }
    }
}