using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe {
    public int[] requiredItems;
    public int itemToCraft;

    public CraftRecipe(int itemToCraft, int[] requiredItems)
    {
        this.requiredItems = requiredItems;
        this.itemToCraft = itemToCraft;
    }
}
