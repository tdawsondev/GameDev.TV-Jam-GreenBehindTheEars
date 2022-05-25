using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    [SerializeField] Button startAsSelected = null; //This button starts selected. Plays nice with controller.
    [SerializeField] SceneHandler sceneHandler = null;

    private GameSettings settings = null;

    private void Start()
    {
        settings = GameSettings.Instance;

        if (startAsSelected == null) { return; }

        startAsSelected.Select();
    }

    public void Play()
    {
        if(sceneHandler == null) { return; }
        Debug.Log($"Going to dreams test level.");
        sceneHandler.LoadLevel(SceneHandler.LEVELS.dreamsTest);
    }

    public void SetPause(bool state)
    {
        if(settings == null) { return; }
        settings.SetPauseState(state);
    }

    public void MainMenu()
    {
        if(sceneHandler == null) { return; }
        sceneHandler.LoadLevel(SceneHandler.LEVELS.title);
    }

    public void Exit()
    {
        Debug.Log($"Currently just quits the application. May want to put up a confirmation prompt before exiting.");
        Application.Quit();
    }

}
