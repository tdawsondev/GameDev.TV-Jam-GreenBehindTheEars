using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStateManager : StateManager
{
    [SerializeField] Interactable seatInteraction = null;
    [SerializeField] Gatekeeper_Character gk = null;

    public void ActivateSeat()
    {
        seatInteraction.enabled = true;
        gk.SetDialog(gk.TakeASeat);
    }
}
