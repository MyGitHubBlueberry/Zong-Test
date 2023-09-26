using UnityEngine;

namespace Raycast
{
    public class CameraRaycaster : MonoBehaviour
    {
        [SerializeField] float raycastDistance = 30f;

        public IRaycastable CurrentRaycastable { get; private set; }

        void Update()
        {
            if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, raycastDistance)) return;

            if (hitInfo.transform.TryGetComponent(out IRaycastable raycastable))
            {
                CurrentRaycastable = raycastable.HandleRaycast(hitInfo) 
                ? raycastable
                : null;
            }
            else
            {
                CurrentRaycastable = null;
            }
        }
    }
}
