using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatekeeper_Character : Character
{
    [Header("DialogObjects")]
    public DialogObject TakeASeat;




    public void SetDialog(DialogObject dObj)
    {
        DialogueInteractable di = null;
        if(interactable.GetType() == typeof(DialogueInteractable))
        {
            di = (DialogueInteractable)interactable;
        }
        if(di != null)
        {
            di.dialog = dObj;
        }
    }
}
