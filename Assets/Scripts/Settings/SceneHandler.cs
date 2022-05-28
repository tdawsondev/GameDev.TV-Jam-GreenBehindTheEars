using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    #region Singleton

    public static SceneHandler instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one SceneHandler Object");
        }
        instance = this;
    }
    #endregion


    GameSettings settings = null;
    public Animator transtition;

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
        StartCoroutine(LoadLevel_Routine(levelName));
    }

    public void RestartLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
    }


    IEnumerator LoadLevel_Routine(LEVELS levelName)
    {
        Debug.Log("clicked");
        transtition.SetTrigger("Start");
        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene((int)levelName);
    }
}
