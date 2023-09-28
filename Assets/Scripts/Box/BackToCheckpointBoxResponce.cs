using System;
using Saving;
using UnityEngine;

namespace Box
{
    public class BackToCheckpointBoxResponce : MonoBehaviour, IBoxResponce, IGameLoader
    {
        public event Action OnGameLoad;

        public void HandleSphereEntering(Transform sphere) => OnGameLoad?.Invoke();
    }
}