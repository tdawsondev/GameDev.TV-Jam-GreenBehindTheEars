using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> items;


    public Item getItemById(string id)
    {
       
        foreach(Item item in items)
        {
            if (item.ID == id.TrimEnd('\r', '\n'))
            {
                return item;
            }
        }
        return null;
    }
}
