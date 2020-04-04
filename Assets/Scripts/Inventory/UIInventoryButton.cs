using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryButton : MonoBehaviour, IPointerDownHandler {
    [SerializeField]
    private UIInventory inventoryUI;
    private bool inventoryHidden;
    
    private void Awake()
    {
        inventoryHidden = true;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (inventoryHidden)
        {
            inventoryUI.ShowInventory();
            inventoryHidden = false;
        }
        else
        {
            inventoryUI.HideInventory();
            inventoryHidden = true;
        }
    }
}
