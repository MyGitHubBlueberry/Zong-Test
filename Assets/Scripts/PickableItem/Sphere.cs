using System;
using System.Collections.Generic;
using Core;
using Newtonsoft.Json.Linq;
using Raycast;
using Saving;
using UI;
using UnityEngine;

namespace PickableItem
{
    public class Sphere : MonoBehaviour, IPickable, IMainUIShowTrigger, IAddPoints, ISaveable, IGameSaver
    {
        public event Action OnPlayerLooksAtTheSphere;
        public event Action<int> OnPointsAdded;
        public event Action OnGameSave;
        public event Action OnMainUIShowRequest;

        [SerializeField] float pickupDistance;
        [Range(1, 100)]
        [SerializeField] int pointsToRewardOnFirstPickup;

        Rigidbody rb;
        bool wasPickedup;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            bool haveParent = transform.position != transform.localPosition;
            wasPickedup = haveParent;
        }

        public bool HandleRaycast(RaycastHit hitInfo)
        {
            OnPlayerLooksAtTheSphere?.Invoke();
            return hitInfo.distance < pickupDistance; ;
        }

        public void Pickup(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;

            rb.isKinematic = true;

            if (!wasPickedup)
            {
                OnMainUIShowRequest?.Invoke();
                OnPointsAdded?.Invoke(pointsToRewardOnFirstPickup);
                wasPickedup = true;
                OnGameSave?.Invoke();
            }
        }

        public void Drop(Transform tempParent)
        {
            transform.parent = tempParent;
            transform.localPosition = Vector3.forward;
            transform.parent = null;

            rb.isKinematic = false;
        }

        public JToken CaptureAsJToken()
        {
            JObject state = new JObject();
            IDictionary<string, JToken> stateDict = state;

            stateDict[nameof(transform.position)] = transform.position.ToToken();
            stateDict[nameof(wasPickedup)] = JToken.FromObject(wasPickedup);
            
            return state;
        }

        public void RestoreFromJToken(JToken state)
        {
            if (state is JObject stateObject)
            {
                IDictionary<string, JToken> stateDict = stateObject;

                transform.position = stateDict[nameof(transform.position)].ToVector3();
                wasPickedup = stateDict[nameof(wasPickedup)].ToObject<bool>();
            }
        }
    }
}



//  public JToken CaptureAsJToken()
//         {
//             JObject state = new JObject();
//             IDictionary<string, JToken> stateDict = state;

//             stateDict[nameof()] = ;
//             stateDict[nameof()] = ;

//             return state;
//         }

//         public void RestoreFromJToken(JToken state)
//         {
//             if (state is JObject stateObject)
//             {
//                 IDictionary<string, JToken> stateDict = stateObject;

//                  = stateDict[nameof()];
//                  = stateDict[nameof()];

//             }
//         }