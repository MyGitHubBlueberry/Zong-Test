using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory Item/New Inventory Item")]
    public class InventoryItem : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] string itemID;
        [SerializeField] Sprite icon;

        public string ItemID
        {
            get { return itemID; }
        }
        public Sprite Icon
        {
            get { return icon; }
        }

        static Dictionary<string, InventoryItem> itemLookupCache;

        public static InventoryItem GetFromID(string itemID)
        {
            if (itemLookupCache == null)
            {
                GenerageLookupCache();
            }

            if (itemID == null || !itemLookupCache.ContainsKey(itemID)) return null;
            return itemLookupCache[itemID];
        }

        private static void GenerageLookupCache()
        {
            itemLookupCache = new Dictionary<string, InventoryItem>();
            var itemList = Resources.LoadAll<InventoryItem>("");
            foreach (var item in itemList)
            {
                if (itemLookupCache.ContainsKey(item.itemID))
                {
                    Debug.LogError(string.Format("There's a duplicate ID for objects: {0} and {1}", 
                        itemLookupCache[item.itemID], item));
                    continue;
                }

                itemLookupCache[item.itemID] = item;
            }
        }

        public void OnBeforeSerialize()
        {
            if (string.IsNullOrWhiteSpace(itemID))
                itemID = Guid.NewGuid().ToString();
        }

        public void OnAfterDeserialize()
        {
            //not needed
        }
    }
}