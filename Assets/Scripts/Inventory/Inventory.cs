using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Inventory Object");
        }
        instance = this;
    }
    #endregion


    public List<Item> items;

    public void AddItem(Item i)
    {
        items.Add(i);
    }

    public bool RemoveItem(Item i)
    {
        if (items.Contains(i))
        {
            Debug.Log("Removing Item: " + i.name);
            items.Remove(i);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnInventory(InputValue value)
    {
        if (InventoryUI.instance.invetoryOpen)
        {
            InventoryUI.instance.CloseInventory();
        }
        else
        {
            InventoryUI.instance.ActivateInventory();
        }
        
    }
}
