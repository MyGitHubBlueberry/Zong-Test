using System;
using Core;
using Newtonsoft.Json.Linq;
using Saving;
using UnityEngine;

namespace Box
{
    public class Box : MonoBehaviour
    {
        IBoxResponce boxResponce;

        void Awake() => boxResponce = GetComponent<IBoxResponce>();

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(nameof(Tag.Sphere))) return;
            boxResponce.HandleSphereEntering(other.transform);
        }
    }
}