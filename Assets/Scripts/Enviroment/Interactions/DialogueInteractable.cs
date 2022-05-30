using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    public DialogObject dialog;

    public override void Interact()
    {
        Conversation.instance.OpenDialog(dialog);
        PlayerInteraction.instance.RemoveInteract(this);
    }
}
