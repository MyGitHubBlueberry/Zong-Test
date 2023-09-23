using Core;
using UnityEngine;

namespace Box
{
    public class Box : MonoBehaviour
    {
        IBoxResponce boxResponce;

        void Awake() => boxResponce = GetComponent<IBoxResponce>();

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(Tag.Sphere))) boxResponce.HandleSphereEntering(other.transform);
        }
    }
}