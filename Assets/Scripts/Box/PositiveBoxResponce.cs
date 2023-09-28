using System;
using Core.Extentions;
using Newtonsoft.Json.Linq;
using Saving;
using UnityEngine;

namespace Box
{
    public class PositiveBoxResponce : MonoBehaviour, IBoxResponceUINotificator, IBoxResponcePartSystNotificator, IAddPoints, ISaveable
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

        public JToken CaptureAsJToken()
        {
            return JToken.FromObject(GetComponent<Box>().WasUsed);
        }

        public void RestoreFromJToken(JToken state)
        {
            if(!state.ToObject<bool>())
                transform.DestroyChildren();
        }
    }
}