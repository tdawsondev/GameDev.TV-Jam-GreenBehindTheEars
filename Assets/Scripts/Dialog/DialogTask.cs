using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogTask : ScriptableObject
{
    /// <summary>
    /// Calls the task. Returns true if successful.
    /// </summary>
    /// <returns></returns>
    public abstract bool CallTask();
}
