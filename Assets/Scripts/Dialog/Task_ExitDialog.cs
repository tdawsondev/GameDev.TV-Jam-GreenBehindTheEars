using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExitDialog", menuName = "Dialog/Task/Exit Dialog")]
public class Task_ExitDialog : DialogTask
{
    public override bool CallTask()
    {
        Debug.Log("Exiting Dialog");
        //Dialog Manager .exit dialog or something. 
        return true; // returns true after exit
    }

}
