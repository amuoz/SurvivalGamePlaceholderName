using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {
    [SerializeField]
    private SlotPanel[] slotPanels;

    void Start () {
        gameObject.SetActive(false); 
    }
    public void AddItemToUI(Item item)
    {
        foreach(SlotPanel sp in slotPanels)
        {
            if (sp.ContainsEmptySlot())
            {
                Debug.Log("Found empty slot");
                sp.AddNewItem(item);
                break;
            }
        }
    }

    public void ShowInventory()
    {
        gameObject.SetActive(true);
    }
    
    public void HideInventory()
    {
        gameObject.SetActive(false);
    }
}
