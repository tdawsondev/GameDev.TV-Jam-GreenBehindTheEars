using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInteraction : Interactable
{
    public SceneHandler.LEVELS level;
    public override void Interact()
    {
        SceneHandler.instance.LoadLevel(level);
    }


}
