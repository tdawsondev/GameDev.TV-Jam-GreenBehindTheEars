using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownStateManager : StateManager
{
    [SerializeField] Gatekeeper_Character gk = null;
    [SerializeField] Winter_Character winter = null;
    public GameObject winterGameObject;
    public SceneInteraction winterDoorScene;
    public DialogueInteractable winterDoorDialog;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetGKDialog();
    }

    void SetGKDialog()
    {
        gk.SetDialog(gk.Follow_Instructions); // first dialog
        if (PlayerPrefs.GetInt("PlayerHouseVisited") == 1)
        {
            gk.SetDialog(gk.afterHouse);
        }
        if (PlayerPrefs.GetInt("GKArrivePark") == 1)
        {
            gk.transform.position = gk.parkLocation.position;
            gk.SetDialog(gk.parkEntry);
        }
        if (PlayerPrefs.GetInt("GKBeforeHat") == 1)
        {
            gk.transform.position = gk.parkLocation.position;
            gk.SetDialog(gk.parkBeforeHat);
        }
        if (PlayerPrefs.GetInt("GKAfterHat") == 1)
        {
            gk.transform.position = gk.houseLocation.position;
            SetParkAfterHat();
        }
        if (PlayerPrefs.GetInt("WAfterEntry") == 1)
        {
            SetAfterWinterEntry();
        }
        if (PlayerPrefs.GetInt("GKTulipEntry") == 1)
        {
            SetAfterGKTulipEntry();
        }
        if (PlayerPrefs.GetInt("WinterTulipHouse") == 1)
        {
            WinterAfterTulips();
        }
        if (PlayerPrefs.GetInt("MovingToWinterHouse") == 1)
        {
            gk.transform.position = gk.wintersHouse.position;
            AfterArriveAtHouse();
        }
        if (PlayerPrefs.GetInt("AfterHouseConvo") == 1)
        {
            gk.transform.position = gk.houseLocation.position;
            AfterHouseConvo();
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void VistedPlayerHouse()
    {
        PlayerPrefs.SetInt("PlayerHouseVisited", 1);
    }

    public void GK_WalkToPark()
    {
        gk.SetDestination(gk.parkLocation, AfterArriveatPark);
    }
    public void GK_WalkToHouse()
    {
        gk.SetDestination(gk.houseLocation);
    }

    public void AfterArriveatPark()
    {
        PlayerPrefs.SetInt("GKArrivePark", 1);
        
        gk.SetDialog(gk.parkEntry);
    }

    public void SetParkBeforeHat()
    {
        PlayerPrefs.SetInt("GKBeforeHat", 1);
        gk.SetDialog(gk.parkBeforeHat);
    }
    public void SetParkAfterHat()
    {
        PlayerPrefs.SetInt("GKAfterHat", 1);
        gk.SetDialog(gk.parkRecurring);
        winterGameObject.SetActive(true);
    }

    public void SetAfterWinterEntry()
    {
        PlayerPrefs.SetInt("WAfterEntry", 1);
        winter.SetDialog(winter.entryTulips);
        gk.SetDialog(gk.tulipEntry);
    }

    public void SetAfterGKTulipEntry()
    {
        PlayerPrefs.SetInt("GKTulipEntry", 1);
        gk.SetDialog(gk.tulipRecurring);
    }

    public void WinterAfterTulips()
    {
        PlayerPrefs.SetInt("WinterTulipHouse", 1);
        winter.SetDialog(winter.tulipsRecurring);
        winterGameObject.SetActive(false);
        winterDoorScene.SetDisable();
        winterDoorDialog.SetEnable();
        gk.SetDialog(gk.entryGW);
    }
    public void GK_MoveToHouse()
    {
        PlayerPrefs.SetInt("MovingToWinterHouse", 1);
        gk.SetDestination(gk.wintersHouse, AfterArriveAtHouse);
        
    }
    public void AfterArriveAtHouse()
    {
        gk.SetDialog(gk.arriveWinterHouse);
        winterDoorDialog.dialog = gk.arriveWinterHouse;
    }

    public void AfterHouseConvo()
    {
        PlayerPrefs.SetInt("AfterHouseConvo", 1);
        gk.SetDestination(gk.houseLocation);
        gk.SetDialog(gk.winterHouseRecurring);
        winterDoorDialog.SetDisable();
        winterDoorScene.SetEnable();
    }
}
