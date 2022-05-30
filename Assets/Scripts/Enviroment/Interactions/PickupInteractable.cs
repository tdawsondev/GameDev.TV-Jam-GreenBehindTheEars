using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractable : Interactable
{

    public Item item;
    public List<DialogTask> tasks;

    public override void Interact()
    {
        Inventory.instance.AddItem(item);
        PlayerInteraction.instance.RemoveInteract(this);
        foreach(DialogTask task in tasks)
        {
            task.CallTask();
        }
        Destroy(gameObject);
    }

    
}
