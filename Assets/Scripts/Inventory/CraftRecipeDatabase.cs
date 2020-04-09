using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CraftRecipeDatabase : MonoBehaviour {
    public List<CraftRecipe> recipes = new List<CraftRecipe>();
    private ItemDatabase itemDatabase;

    private void Awake()
    {
        itemDatabase = GetComponent<ItemDatabase>();
        BuildCraftRecipeDatabase();
    }

    public Item CheckRecipe(int[] recipe)
    {
        foreach(CraftRecipe craftRecipe in recipes)
        {
            if (craftRecipe.requiredItems.OrderBy(i => i).SequenceEqual(recipe.OrderBy(i=>i)))
            {
                return itemDatabase.GetItem(craftRecipe.itemToCraft);
            }
        }
        return null;
    }

    void BuildCraftRecipeDatabase()
    {
        recipes = new List<CraftRecipe>()
        {
            new CraftRecipe(2,
            new int[] {
                1, 1, 0,
                0, 0, 0,
                0, 0, 0
            })
        };
    }
}
