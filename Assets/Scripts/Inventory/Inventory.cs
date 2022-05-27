using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

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

    public ItemDatabase database;
    public List<Item> items;

    private void Start()
    {
        LoadInventoryTemp(); // we should probably move this later
    }


    public void AddItem(Item i)
    {
        items.Add(i);
        HUDController.instance.AddItemNotification(i);
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

    /// <summary>
    /// Check player inventory for an item based on the string Item.itemName variable.
    /// </summary>
    /// <param name="requestedItemName"></param>
    /// <returns>True if string matches item name in player inventory.</returns>
    public bool CheckForItem(string requestedItemName)
    {
        if(items.Count == 0) { Debug.Log($"Item list is empty."); return false; }

        foreach(Item item in items)
        {
            if (item.itemName == requestedItemName)
                return true;
        }

        return false;

    }

    /// <summary>
    /// Input Key For inventory
    /// </summary>
    /// <param name="value"></param>
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

    public void SaveInventoryTemp()
    {
        string saveData = "";
        foreach(Item i in items)
        {
            saveData = saveData+ i.ID + '\n';
        }
        SaveSystem.TempSave(saveData, "inventoryTempSave");
    }

    public void LoadInventoryTemp()
    {
        items = new List<Item>();
       string saveData = SaveSystem.LoadTemp("inventoryTempSave");
        if(saveData != null && saveData != "")
        {
            foreach(var str in saveData.Split('\n'))
            {
                if(str != "")
                {
                    Item item = database.getItemById(str);
                    if (item != null)
                    {
                        items.Add(item);
                    }
                }
            }
        }
    }

    public void SaveInventory()
    {
        string saveData = "";
        foreach (Item i in items)
        {
            saveData = saveData + i.ID + '\n';
        }
        SaveSystem.Save(saveData, "inventoryTempSave");
    }

    public void LoadInventory()
    {
        items = new List<Item>();
        string saveData = SaveSystem.Load("inventoryTempSave");
        if (saveData != null && saveData != "")
        {
            foreach (var str in saveData.Split('\n'))
            {
                if (str != "")
                {
                    Item item = database.getItemById(str);
                    if (item != null)
                    {
                        items.Add(item);
                    }
                }
            }
        }
    }
}
