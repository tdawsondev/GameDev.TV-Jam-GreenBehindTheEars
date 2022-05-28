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
        BoatScene = 2,
        PlayerHouse = 3,
        WinterHouse = 4,
        GravekeeperHouse = 5
    }

    private void Start()
    {
        settings = GameSettings.Instance;
    }

    public void LoadLevel(LEVELS levelName)
    { 
        SceneManager.LoadScene((int)levelName);
    }

    public void RestartLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
    }

}
