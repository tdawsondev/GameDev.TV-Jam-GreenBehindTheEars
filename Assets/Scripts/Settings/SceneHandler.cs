using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    GameSettings settings = null;

    public enum LEVELS
    {
        title = 0,
        ghostTownOverworld = 1,
        kabungusTest = 2,
        dreamsTest = 3
    }

    private void Start()
    {
        settings = GameSettings.Instance;
    }

    public void LoadLevel(LEVELS levelName)
    {
        int buildIndex = -1;

        switch(levelName)
        {
            case LEVELS.title:
                SaveSystem.DeleteAllTemps(); // All Temps deleted when going to main menu
                buildIndex = 0;
                break;
            case LEVELS.ghostTownOverworld:
                buildIndex = 1;
                break;
            case LEVELS.kabungusTest:
                settings.SetMusic(AudioHandler.AUDIO_MUSIC.town);
                buildIndex = 2;
                break;
            case LEVELS.dreamsTest:
                buildIndex = 3;
                break;
            default:
                break;
        }

        if(buildIndex == -1) { return; }

        SceneManager.LoadScene(buildIndex);
    }

    public void RestartLevel()
    {

        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
    }

}
