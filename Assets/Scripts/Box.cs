using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isOpen = false;

    public void CmdInteractionFinished(GameObject other)
    {
        if (isOpen) {
            GetComponent<Inventory>().CloseInventory();
            isOpen = false;
        } else {
            GetComponent<Inventory>().OpenInventory();
            isOpen = true;
        }
    }
}
