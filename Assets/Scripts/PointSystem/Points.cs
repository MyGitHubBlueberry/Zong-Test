using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Saving;
using UnityEngine;

namespace PointSystem
{
    public class Points : MonoBehaviour, ISaveable
    {
        public event Action<int> OnPointsAdded;
        int points;

        void Awake()
        {
            IEnumerable<IAddPoints> allInterfaces = Core.Static.GetInstancesOfImplementingType<IAddPoints>();

            foreach(var instance in allInterfaces)
                instance.OnPointsAdded += AddPoints;
        }

        void AddPoints(int points)
        {
            this.points += points;

            OnPointsAdded?.Invoke(this.points);
        }

        public JToken CaptureAsJToken()
        {
            return JToken.FromObject(points);
        }

        public void RestoreFromJToken(JToken state)
        {
            points = state.ToObject<int>();
            OnPointsAdded?.Invoke(points);
        }
    }
}
