using System;
using UnityEngine;

namespace Box
{
    public class PositiveBoxResponce : MonoBehaviour, IBoxResponceUINotificator, IBoxResponcePartSystNotificator
    {
        public event Action<string> OnResponceForUI;
        public event Action OnResponceForParticleSystem;

        [SerializeField] string uiText;

        public void HandleSphereEntering(Transform sphere)
        {
            OnResponceForUI?.Invoke(uiText);
            OnResponceForParticleSystem?.Invoke();
        }
    }
}