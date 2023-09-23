using System;
using UnityEngine;

namespace Box
{
    public class PositiveBoxResponce : MonoBehaviour, IBoxResponceUINotificator
    {
        public event EventHandler<ResponceEventArgs> OnPositiveBoxResponce;
        public event Action<string> OnResponceForUI;

        public class ResponceEventArgs : EventArgs
        {
            public Transform sphere;
            public ParticleSystem particleSystem;
            public string UIText;
        }

        [SerializeField] new ParticleSystem particleSystem;
        [SerializeField] string uiText;

        public void HandleSphereEntering(Transform sphere) => OnResponceForUI?.Invoke(uiText);
        // OnPositiveBoxResponce
        // (
        //     this, new ResponceEventArgs
        //     {
        //         sphere = sphere,
        //         particleSystem = this.particleSystem,
        //         UIText = this.UIText
        //     }
        // );
    }
}