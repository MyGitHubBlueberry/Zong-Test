using System;
using UnityEngine;
using UnityEngine.UI;
using Base = Inventory;

namespace UI.Inventory
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] Button selectItemButton;
        [SerializeField] Image selectedItemImage;

        int index;
        Base.InventoryItem item;
        Base.Inventory inventory;
        Image mainItemImage;

        public Base.InventoryItem GetItem()
        {
            return inventory.GetItemInSlot(index);
        }

        public void AddItems(Base.InventoryItem item, int number)
        {
            inventory.AddToFirstEmptySlot(item);
        }

        public void RemoveItems(int number)
        {
            inventory.RemoveFromSlot(index, number);
        }

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
            mainItemImage = selectItemButton.GetComponent<Image>();
            
            selectedItemImage.gameObject.SetActive(false);
            mainItemImage.gameObject.SetActive(false);

            selectItemButton.onClick.AddListener(HandleSelection);
        }

        void HandleSelection()
        {
            inventory.SetSelectedItem(index);
            selectedItemImage.gameObject.SetActive(true);
        }
    }
}