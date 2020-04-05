using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> inventoryItems = new List<Item>();
    private UIInventory inventoryUI;
    ItemDatabase itemDatabase;

    private void Awake()
    {
        itemDatabase = FindObjectOfType<ItemDatabase>();
        inventoryUI = FindObjectOfType<UIInventory>();
    }

    private void Start()
    {
        GiveItem(1);
        GiveItem(2);
        GiveItem(3);
        GiveItem(1);
        GiveItem(2);
        GiveItem(3);
        GiveItem(1);
        GiveItem(2);
        GiveItem(3);
        GiveItem(1);
        GiveItem(2);
        GiveItem(3);
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        inventoryUI.AddItemToUI(itemToAdd);
        inventoryItems.Add(itemToAdd);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        inventoryUI.AddItemToUI(itemToAdd);
        inventoryItems.Add(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        return inventoryItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);

        if (itemToRemove != null)
        {
            inventoryItems.Remove(itemToRemove);
        }
    }

    public void OpenInventory() {
        inventoryUI.ShowInventory();
    }

    public void CloseInventory() {
        inventoryUI.HideInventory();
    }
}
