using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public enum LEVELS
    {
        title = 0,
        ghostTownOverworld = 1,
        kabungusTest = 2,
        dreamsTest = 3
    }

    public void LoadLevel(LEVELS levelName)
    {
        int buildIndex = -1;

        switch(levelName)
        {
            case LEVELS.title:
                buildIndex = 0;
                break;
            case LEVELS.ghostTownOverworld:
                buildIndex = 1;
                break;
            case LEVELS.kabungusTest:
                buildIndex = 2;
                break;
            case LEVELS.dreamsTest:
                buildIndex = 3;
                break;
            default:
                break;
        }

        if(buildIndex == -1) { return; }

        Debug.Log($"We may want to do some fancy save / load logic before entering the new level.");

        SceneManager.LoadScene(buildIndex);
    }

    public void RestartLevel()
    {
        Debug.Log($"We may want to do some fancy save / load logic before reloading the level.");

        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
    }

}
