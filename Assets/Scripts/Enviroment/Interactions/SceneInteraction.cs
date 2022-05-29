using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteraction : Interactable
{
    public SceneHandler.LEVELS level;
    Player thePlayer = null;

    protected override void Start()
    {
        base.Start();

        thePlayer = Player.instance;
    }

    public override void Interact()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)SceneHandler.LEVELS.ghostTownOverworld)
            thePlayer.SaveMyPosition();

        SceneHandler.instance.LoadLevel(level);
    }


}
