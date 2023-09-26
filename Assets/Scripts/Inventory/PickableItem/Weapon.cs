using Inventory;
using UnityEngine;

namespace Inventory.PickableItem
{
    public class Weapon : PickableItem, IDoDamage
    {
        [SerializeField] float damage;

        public void Damage()
        {
            // do damage logick    
        }
    }
}