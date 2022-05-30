using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatekeeper_Character : Character
{
    [Header("DialogObjects")]
    public DialogObject TakeASeat;
    public DialogObject Follow_Instructions;
    public DialogObject afterHouse;
    public DialogObject parkEntry;
    public DialogObject parkBeforeHat;
    public DialogObject parkRecurring;
    public DialogObject tulipEntry;
    public DialogObject tulipRecurring;



    [Header("Destinations")]
    public Transform parkLocation;
    public Transform houseLocation;




    
}
