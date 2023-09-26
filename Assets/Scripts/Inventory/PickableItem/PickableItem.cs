using Raycast;
using UnityEngine;
using Inv = Inventory.InventoryItem;

namespace Inventory.PickableItem
{
    [RequireComponent(typeof(Rigidbody))]
    public class PickableItem : MonoBehaviour, IPickable
    {
        [SerializeField] protected float pickupDistance = 3f;

        Inv.InventoryItem item;
        Rigidbody rigidBody;
        Inventory inventory;

        public static PickableItem Setup(PickableItem prefab, Transform parent, Inv.InventoryItem inventoryItem)
        {
            PickableItem instance = Instantiate(prefab, parent);
            instance.item = inventoryItem;

            instance.rigidBody.isKinematic = true;
            instance.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            return instance;
        }

        public virtual bool HandleRaycast(RaycastHit hitInfo) =>
            hitInfo.distance < pickupDistance;

        public virtual void Pickup(Transform parent)
        {
            transform.SetParent(parent);

            rigidBody.isKinematic = true;
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            inventory.AddToFirstEmptySlot(item, true);
        }

        public virtual void Drop(Transform tempParent)
        {
            transform.parent = tempParent;
            transform.localPosition = Vector3.forward;
            transform.parent = null;

            rigidBody.isKinematic = false;

            inventory.RemoveFromSlot(inventory.SelectedItem);
        }
        
        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            inventory = Inventory.GetPlayerInventory();
        }
    }
}