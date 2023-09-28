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

      public static void DestroyChildren(this Transform t, float time)
      {
         foreach(Transform child in t)
         {
            Object.Destroy(child.gameObject, time);
         }
      }
   }
}
