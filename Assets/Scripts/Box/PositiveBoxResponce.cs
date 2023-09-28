using System;
using Core.Extentions;
using Newtonsoft.Json.Linq;
using Saving;
using UnityEngine;

namespace Box
{
    public class PositiveBoxResponce : MonoBehaviour, IBoxResponceUINotificator, IBoxResponcePartSystNotificator, IAddPoints, ISaveable, IBoxResponceSFXNotificator
    {
        public event Action<string> OnResponceForUI;
        public event Action OnResponceForParticleSystem;
        public event Action<int> OnPointsAdded;
        public event Action OnResponceForAudioSource;

        [SerializeField] string uiText;
        [Range(0, 100)]
        [SerializeField] int rewardPoints;

        bool wasUsed;

        public void HandleSphereEntering(Transform sphere)
        {
            if(wasUsed) return;

            OnResponceForUI?.Invoke(uiText);
            OnResponceForParticleSystem?.Invoke();
            OnResponceForAudioSource?.Invoke();
            OnPointsAdded?.Invoke(rewardPoints);

            wasUsed = true;
        }


        public JToken CaptureAsJToken()
        {
            return JToken.FromObject(wasUsed);
        }

        public void RestoreFromJToken(JToken state)
        {
            wasUsed = state.ToObject<bool>();
            if(!wasUsed) transform.DestroyChildren();
        }
    }
}