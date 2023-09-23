using System.Numerics;
using UnityEngine;

namespace Box
{
    public interface IBoxResponce
    {
        void HandleSphereEntering(Transform sphere);
    }
}