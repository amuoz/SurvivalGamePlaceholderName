using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    void BuildItemDatabase()
    {
        items = new List<Item>()
        {
            new Item(1, "wheat", "Because wheat comes from trees.",
                new Dictionary<string, int>
                {
                    {"Value", 1}
                }),
            new Item(2, "Iron Axe", "An axe made of iron.",
                new Dictionary<string, int>
                {
                    {"Power", 8},
                    {"Defence", 10}
                })
        };
    }
}