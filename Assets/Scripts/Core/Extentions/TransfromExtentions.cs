using UnityEngine;

namespace Core.Extentions
{
   public static class TransfromExtentions
   {
      public static void DestroyChildren(this Transform t)
      {
         foreach(Transform child in t)
         {
            Object.Destroy(child.gameObject);
         }
      }
   }
}
