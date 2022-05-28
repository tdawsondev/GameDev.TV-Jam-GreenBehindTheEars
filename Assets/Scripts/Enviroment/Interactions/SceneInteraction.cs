using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInteraction : Interactable
{
    public SceneHandler.LEVELS level;
    public override void Interact()
    {
        GameSettings.Instance.GetSceneHandler().LoadLevel(level);
    }


}
