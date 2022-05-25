using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Take Item", menuName = "Dialog/Task/Take Item")]
public class Task_TakeItem : DialogTask
{
    public Item item;

    public override bool CallTask()
    {
        Inventory inventory = Inventory.instance;
        if (inventory)
        {
            return inventory.RemoveItem(item);
        }
        else
        {
            return false;
        }
    }
}
