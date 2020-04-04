using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField]
    private UIInventory inventoryUI;
    private Tooltip tooltip;
    private bool inventoryHidden;
    
    private void Awake()
    {
        inventoryHidden = true;
        tooltip = FindObjectOfType<Tooltip>();
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.GenerateTooltip("Inventory");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
