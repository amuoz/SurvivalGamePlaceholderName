using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftResult : MonoBehaviour, IPointerDownHandler {
    public SlotPanel slotPanel;
    public Inventory inventory;

    public void OnPointerDown(PointerEventData eventData)
    {
        slotPanel.EmptyAllSlots();
        inventory.inventoryItems.Add(GetComponent<UIItem>().item);
    }
}
