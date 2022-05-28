using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region Singleton

    public static StateManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one StateManager Object");
        }
        instance = this;
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
