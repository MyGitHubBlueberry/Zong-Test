using System;
using System.Collections.Generic;
using UnityEngine;

namespace PointSystem
{
    public class Points : MonoBehaviour
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
    }
}
