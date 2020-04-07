using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTree : MonoBehaviour
{
    private int resourceId = 1;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void CmdInteractionFinished(GameObject other)
    {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        
        if (inventory != null) {
            inventory.GiveItem(resourceId);
        }

        Destroy(this.gameObject);
    }
}
