using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExitDialog", menuName = "Dialog/Task/Exit Dialog")]
public class Task_ExitDialog : DialogTask
{
    public override bool CallTask()
    {
        Conversation.instance.CloseDialog();
        return true; // returns true after exit
    }

}
