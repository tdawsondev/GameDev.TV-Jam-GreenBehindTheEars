using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles all player scripts;
/// </summary>
public class Player : MonoBehaviour
{
    #region Singleton

    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Player Object");
        }
        instance = this;
    }
    #endregion

    PlayerMovement pm;
    PlayerInteraction pi;

    // Start is called before the first frame update
    void Start()
    {
        pm = PlayerMovement.instance;
        pi = PlayerInteraction.instance;
    }

    public void DisablePlayerAction()
    {
        pm.DisableMovement();
        pi.DisableInteraction();
    }
    public void EnablePlayerAction()
    {
        pm.EnableMovement();
        pi.EnableInteraction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
