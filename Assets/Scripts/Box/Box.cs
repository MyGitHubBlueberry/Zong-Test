using System;
using Core;
using Newtonsoft.Json.Linq;
using Saving;
using UnityEngine;

namespace Box
{
    public class Box : MonoBehaviour, ISaveable
    {
        public bool WasUsed { get => wasUsed; }
        
        bool wasUsed;
        IBoxResponce boxResponce;

        void Awake() => boxResponce = GetComponent<IBoxResponce>();

        void OnTriggerEnter(Collider other)
        {
            if (!wasUsed && other.CompareTag(nameof(Tag.Sphere)))
            {
                boxResponce.HandleSphereEntering(other.transform);
                wasUsed = true;
            }
        }

        public virtual JToken CaptureAsJToken()
        {
            return JToken.FromObject(wasUsed);
        }

        public virtual void RestoreFromJToken(JToken state)
        {
            wasUsed = state.ToObject<bool>();
        }

    }
}