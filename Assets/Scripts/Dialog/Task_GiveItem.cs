using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Give Item", menuName = "Dialog/Task/Give Item")]
public class Task_GiveItem : DialogTask
{
    public Item item;
    public override bool CallTask()
    {
        Inventory inventory = Inventory.instance;
        if (inventory)
        {
            inventory.AddItem(item);
            return true;
        }
        else
        {
            return false;
        }
    }
}
