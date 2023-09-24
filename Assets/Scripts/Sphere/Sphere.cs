using System;
using Raycast;
using UnityEngine;

namespace Sphere
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

        public void HandleRaycast(RaycastHit hitInfo)
        {
            OnPlayerLooksAtTheSphere?.Invoke();
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