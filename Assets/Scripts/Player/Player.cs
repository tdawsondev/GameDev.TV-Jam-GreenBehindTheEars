using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Handles all player scripts;
/// </summary>
public class Player : MonoBehaviour
{
    #region Awake

    public static Player instance;
    private PlayerInputActions inputActions;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Player Object");
        }
        instance = this;
        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputActions.Player.TEST.performed += OnTEST;
        inputActions.Player.TEST.Enable();
        inputActions.Player.Pause.performed += OnPause;
        inputActions.Player.Pause.Enable(); 
    }
    private void OnDisable()
    {
        inputActions.Player.TEST.performed -= OnTEST;
        inputActions.Player.TEST.Disable();
        inputActions.Player.Pause.performed -= OnPause;
        inputActions.Player.Pause.Disable();
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

    public void OnTEST(InputAction.CallbackContext context)
    {
        Debug.Log($"Test function initiated!!!");
        SceneHandler.instance.LoadLevel(SceneHandler.LEVELS.BoatScene);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log($"Trying to pause.");

        if (settings == null) { return; }
        settings.SetPauseState(true);

        if (pauseMenuUI == null) { return; }
        pauseMenuUI.SetActive(true);

        if (buttonHandler == null) { return; }
        buttonHandler.SetSelected();

    }

}
