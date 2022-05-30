using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownStateManager : StateManager
{
    [SerializeField] Gatekeeper_Character gk = null;

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
            gk.SetDialog(gk.parkEntry);
        }
        if (PlayerPrefs.GetInt("GKBeforeHat") == 1)
        {
            gk.SetDialog(gk.parkBeforeHat);
        }
        if (PlayerPrefs.GetInt("GKAfterHat") == 1)
        {
            gk.SetDialog(gk.parkRecurring);
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
    }
}
