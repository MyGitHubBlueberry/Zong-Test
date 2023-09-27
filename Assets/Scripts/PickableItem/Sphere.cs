using System;
using Raycast;
using UI;
using UnityEngine;

namespace PickableItem
{
    public class Sphere : MonoBehaviour, IPickable, IMainUIShowTrigger, IAddPoints
    {
        public event Action OnPlayerLooksAtTheSphere;
        public event Action<int> OnPointsAdded;

        [SerializeField] float pickupDistance;
        [Range(1, 100)]
        [SerializeField] int pointsToRewardOnFirstPickup;

        Rigidbody rb;
        bool wasPickedup;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            bool haveParent = transform.position != transform.localPosition;
            wasPickedup = haveParent;
        }

        public bool HandleRaycast(RaycastHit hitInfo)
        {
            OnPlayerLooksAtTheSphere?.Invoke();
            return hitInfo.distance < pickupDistance; ;
        }

        public void Pickup(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;

            rb.isKinematic = true;

            if (!wasPickedup)
            {
                OnPointsAdded?.Invoke(pointsToRewardOnFirstPickup);
                wasPickedup = true;
            }
        }

        public void Drop(Transform tempParent)
        {
            transform.parent = tempParent;
            transform.localPosition = Vector3.forward;
            transform.parent = null;

            rb.isKinematic = false;
        }
    }
}

