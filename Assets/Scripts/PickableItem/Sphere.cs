using System;
using Raycast;
using UnityEngine;

namespace PickableItem
{
    public class Sphere : MonoBehaviour, IPickable
    {
        public event Action OnPlayerLooksAtTheSphere;

        [SerializeField] float pickupDistance;

        Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public bool HandleRaycast(RaycastHit hitInfo)
        {
            OnPlayerLooksAtTheSphere?.Invoke();
            return hitInfo.distance < pickupDistance;;
        }

        public void Pickup(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;

            rb.isKinematic = true;
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