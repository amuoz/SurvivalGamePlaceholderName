using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Inventory store;
    private Inventory craft;
    // Start is called before the first frame update
    void Start() {
        Inventory[] inventories = GetComponents<Inventory>();
        store = inventories[0];
        craft = inventories[1];

        GiveItem(1);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OpenAll() {
        OpenStore();
        OpenCraft();
    }

    public void CloseAll() {
        CloseStore();
        CloseCraft();
    }

    public void OpenStore() {
        store.OpenInventory();
    }

    public void OpenCraft() {
        craft.OpenInventory();
    }

    public void CloseStore() {
        store.CloseInventory();
    }

    public void CloseCraft() {
        craft.CloseInventory();
    }

    public void GiveItem(int id) {
        store.GiveItem(id);
    }
}
