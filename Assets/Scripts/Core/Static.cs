using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public static class Static
    {
        public static IEnumerable<T> GetInstancesOfImplementingType<T>() where T : class
        {
            return GameObject.FindObjectsOfType<Component>()
                .Where(c => c is T)
                .Cast<T>();
        }
    }
}
