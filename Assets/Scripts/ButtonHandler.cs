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

    private void Start()
    {
        if(startAsSelected == null) { return; }

        startAsSelected.Select();
    }

    public void Play()
    {
        Debug.Log($"Going to dreams test level.");
        sceneHandler.LoadLevel(SceneHandler.LEVELS.dreamsTest);
    }

    public void Exit()
    {
        Debug.Log($"Currently just quits the application. May want to put up a confirmation prompt before exiting.");
        Application.Quit();
    }

}
