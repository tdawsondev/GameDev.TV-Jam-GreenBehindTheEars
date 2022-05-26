using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractable : Interactable
{

    public Item item;

    public override void Interact()
    {
        Inventory.instance.AddItem(item);
        PlayerInteraction.instance.RemoveInteract(this);
        Destroy(gameObject);
    }

    
}
