using Inventory.InventoryItem;
using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;

namespace UI.Inventory
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] Image mainItemImage;
        [SerializeField] Image selectedItemImage;

        int index;
        InventoryItem item;
        Base.Inventory inventory;

        public void Setup(Base.Inventory inventory, int index)
        {
            this.inventory = inventory;
            this.index = index;
            item = inventory.GetItemInSlot(index);
            if(item is not null)
            {
                mainItemImage.sprite = item.Icon;
                mainItemImage.gameObject.SetActive(true);
                inventory.OnNewItemSelected += DisplayIfSelected;    
            }
        }

        void DisplayIfSelected(int slot)
        {
            selectedItemImage.gameObject.SetActive(index == slot);
        }

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(HandleSelection);

            selectedItemImage.gameObject.SetActive(false);
            mainItemImage.gameObject.SetActive(false);
        }

        void HandleSelection()
        {
            inventory.SetSelectedItem(index);
        }
        
        void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveAllListeners();

            if(item is not null)
                inventory.OnNewItemSelected -= DisplayIfSelected;
        }
    }
}