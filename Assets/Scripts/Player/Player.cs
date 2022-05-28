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

    [SerializeField] GameObject pauseMenuUI = null;
    [SerializeField] ButtonHandler buttonHandler = null;

    PlayerMovement pm;
    PlayerInteraction pi;

    GameSettings settings = null;
    


    // Start is called before the first frame update
    void Start()
    {
        settings = GameSettings.Instance;
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

    public void OnTEST()
    {
        Debug.Log($"Test function initiated!!!");
        GameSettings.Instance.GetSceneHandler().LoadLevel(SceneHandler.LEVELS.BoatScene);
    }

    public void OnPause()
    {
        if (settings == null) { return; }
        settings.SetPauseState(true);

        if (pauseMenuUI == null) { return; }
        pauseMenuUI.SetActive(true);
        
        if(buttonHandler == null) { return; }
        buttonHandler.SetSelected();

    }

}
