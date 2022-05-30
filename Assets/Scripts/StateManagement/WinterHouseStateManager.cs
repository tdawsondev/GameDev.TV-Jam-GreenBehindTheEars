using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterHouseStateManager : StateManager
{
    public GameObject winterObject;
    [SerializeField] Winter_Character winter;
    public Interactable doorInteractable;

    protected override void Start()
    {
        base.Start();
        if (PlayerPrefs.GetInt("AfterHouseConvo") == 1 && PlayerPrefs.GetInt("AfterInsideHouse1") != 1)
        {
            DoStuff();
        }
        else
        {
            winterObject.SetActive(false);
        }
    }

    public void DoStuff()
    {
        winterObject.SetActive(true);
        doorInteractable.SetDisable();
        winter.SetDialog(winter.inHouse);
    }

    public void AfterHouseEnd()
    {
        PlayerPrefs.SetInt("AfterInsideHouse1", 1);
        SceneHandler.instance.LoadLevel(SceneHandler.LEVELS.ghostTownOverworld);
    }
}
