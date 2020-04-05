using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
