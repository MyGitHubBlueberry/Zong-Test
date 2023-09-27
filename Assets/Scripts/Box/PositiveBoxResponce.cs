using System;
using UnityEngine;

namespace Box
{
    public class PositiveBoxResponce : MonoBehaviour, IBoxResponceUINotificator, IBoxResponcePartSystNotificator, IAddPoints
    {
        public event Action<string> OnResponceForUI;
        public event Action OnResponceForParticleSystem;
        public event Action<int> OnPointsAdded;

        [SerializeField] string uiText;
        [Range(0, 100)]
        [SerializeField] int rewardPoints;

        public void HandleSphereEntering(Transform sphere)
        {
            OnResponceForUI?.Invoke(uiText);
            OnResponceForParticleSystem?.Invoke();
            OnPointsAdded?.Invoke(rewardPoints);
        }
    }
}