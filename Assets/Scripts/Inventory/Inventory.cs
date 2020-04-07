using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> inventoryItems = new List<Item>();
    [SerializeField]
    private bool craftInventory = false;
    private UIInventory inventoryUI;
    ItemDatabase itemDatabase;

    private void Awake()
    {
        itemDatabase = FindObjectOfType<ItemDatabase>();
        string inventoryName = craftInventory ? "CraftInventory" : "StoreInventory";
        GameObject hud =  GameObject.FindGameObjectWithTag("HUD");
        GameObject inventory = hud.transform.Find(inventoryName).gameObject;
        inventoryUI = inventory.GetComponent<UIInventory>();
    }

    private void Start()
    {
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
