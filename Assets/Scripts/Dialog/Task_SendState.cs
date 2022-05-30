using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SendState", menuName = "Dialog/Task/Send State")]
public class Task_SendState : DialogTask
{
    [SerializeField] string message;

    public override bool CallTask()
    {
        if (StateManager.instance != null)
        {
            Debug.LogWarning(message);
            StateManager.instance.gameObject.SendMessage(message);
            return true;
        }
        else
        {
            return false;
        }
    }

 
}
