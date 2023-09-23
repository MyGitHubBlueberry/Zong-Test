using System;
using UnityEngine;

namespace Box
{
    public class BackToCheckpointBoxResponce : MonoBehaviour, IBoxResponce
    {
        public event Action OnBackToCheckpointBoxResponce;
        public void HandleSphereEntering(Transform sphere) => OnBackToCheckpointBoxResponce?.Invoke();
    }
}