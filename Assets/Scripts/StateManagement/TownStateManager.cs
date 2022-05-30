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
        gk.SetDialog(gk.parkConvo);
    }
}
