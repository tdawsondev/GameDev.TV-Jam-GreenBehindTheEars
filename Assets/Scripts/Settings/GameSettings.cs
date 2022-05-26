using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    public static GameSettings Instance { get; private set; }

    [Header("Audio")]
    [SerializeField] AudioHandler audioHandler = null;
    [SerializeField] [Range(0f, 1f)] float musicVolume = 0.7f;
    [SerializeField] [Range(0f, 1f)] float soundFXVolume = 0.5f;

    private bool isMusicPlaying = true;
    private bool isGamePaused = false;

    PlayerMovement playerMovement = null;
    PlayerInteraction playerInteraction = null;

    /// <summary>
    /// This is a Singleton.
    /// </summary>
    private void Awake()
    {
        SaveSystem.Init();

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #region Setters
    /// <summary>
    /// Sets the background music via the audio handler.
    /// </summary>
    /// <param name="requestedTrack">Audio track to play.</param>
    public void SetMusic(AudioHandler.AUDIO_MUSIC requestedTrack)
    {
        if(audioHandler == null) { return; }

        audioHandler.SetBackgroundMusic(requestedTrack);
    }
    /// <summary>
    /// Sets the music playing state. Pauses / unpauses via audio handler.
    /// </summary>
    /// <param name="state">Whether to play music or not.</param>
    public void SetIsMusicPlaying(bool state)
    {
        isMusicPlaying = state;

        if(audioHandler == null) { return; }

        audioHandler.PauseMusic(isMusicPlaying);
    }
    /// <summary>
    /// Sets new music volume via audio handler. Clamps value to 0 through 1.
    /// </summary>
    /// <param name="newVolume">new volume level</param>
    public void SetMusicVolume(float newVolume)
    {
        Mathf.Abs(newVolume);
        Mathf.Clamp(newVolume, 0f, 1f);

        musicVolume = newVolume;

        if (audioHandler == null) { return; }
        audioHandler.SetMusicVolume(musicVolume);
    }
    /// <summary>
    /// Sets soundFX volume via audio handler. Clamps value to 0 through 1.
    /// </summary>
    /// <param name="newVolume">new volume level</param>
    public void SetSoundFXVolume(float newVolume)
    {
        Mathf.Abs(newVolume);
        Mathf.Clamp(newVolume, 0f, 1f);

        soundFXVolume = newVolume;

        if (audioHandler == null) { return; }
        audioHandler.SetSoundFXVolume(musicVolume);
    }
    /// <summary>
    /// Tells settings if game should be paused or not.
    /// </summary>
    /// <param name="state">True == paused.</param>
    public void SetPauseState(bool state)
    {
        if(playerInteraction == null)
        {
            SetupPlayerInfo();
        }

        isGamePaused = state;

        if (isGamePaused)
        {
            playerMovement.enabled = false;
            playerInteraction.DisableInteraction();
        }
        else
        {
            playerMovement.enabled = true;
            playerInteraction.EnableInteraction();
        }

    }

    private void SetupPlayerInfo()
    {
        playerMovement = PlayerMovement.instance;
        playerInteraction = PlayerInteraction.instance;
    }

    #endregion

    #region Getters
    /// <summary>
    /// Whether the game is currently paused.
    /// </summary>
    /// <returns>True == game is paused.</returns>
    public bool GetPauseState()
    {
        return isGamePaused;
    }
    /// <summary>
    /// Returns whether music is currently playing.
    /// </summary>
    /// <returns>True == music playing.</returns>
    public bool GetIsMusicPlaying()
    {
        return isMusicPlaying;
    }
    /// <summary>
    /// Current music volume.
    /// </summary>
    /// <returns>Between 0 and 1.</returns>
    public float GetMusicVolume()
    {
        return musicVolume;
    }
    /// <summary>
    /// Current soundFX volume.
    /// </summary>
    /// <returns>Between 0 and 1.</returns>
    public float GetSoundFXVolume()
    {
        return soundFXVolume;
    }


    #endregion

}
