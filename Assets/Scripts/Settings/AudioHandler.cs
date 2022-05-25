using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    const int numberBackgroundMusicTracks = 3;

    public enum AUDIO_MUSIC
    {
        spooky = 0,
        none
    }

    [Header("Music")]
    [SerializeField] AudioSource musicAudioSource = null;
    [SerializeField] AudioClip[] backgroundMusicTracks = new AudioClip[numberBackgroundMusicTracks];
    [SerializeField] AUDIO_MUSIC curBackgroundMusic = AUDIO_MUSIC.none;

    [Header("SoundFX")]
    [SerializeField] AudioSource soundFXAudioSource = null;


    bool isMusicPaused = false;
    GameSettings settings = null;

    /// <summary>
    /// Links to settings and starts the music.
    /// </summary>
    private void Start()
    {
        settings = GameSettings.Instance;

        if(settings == null) { return; }
        if(musicAudioSource == null) { return; }

        SetMusicVolume(settings.GetMusicVolume());
        SetBackgroundMusic(AUDIO_MUSIC.spooky);

        if(soundFXAudioSource == null) { return; }

        SetSoundFXVolume(settings.GetSoundFXVolume());
    }
    /// <summary>
    /// pauses/unpause music.
    /// </summary>
    /// <param name="pause">Whether to pause or unpause.</param>
    public void PauseMusic(bool pause)
    {
        if (pause)
            musicAudioSource.Pause();
        else
            musicAudioSource.UnPause();
    }

    #region Setters
    /// <summary>
    /// Sets the background music and plays it.
    /// If the requested track is the same as the current one
    /// then it just returns / does not restart song.
    /// </summary>
    /// <param name="requestedTrack">Music to play.</param>
    public void SetBackgroundMusic(AUDIO_MUSIC requestedTrack)
    {
        if (musicAudioSource == null) { return; }
        if (requestedTrack == curBackgroundMusic) { return; } 

        switch (requestedTrack)
        {
            case AUDIO_MUSIC.none:
                musicAudioSource.clip = null;
                break;
            case AUDIO_MUSIC.spooky:
                musicAudioSource.clip = backgroundMusicTracks[0];
                break;
            default:
                break;
        }

        curBackgroundMusic = requestedTrack;

        if(requestedTrack == AUDIO_MUSIC.none) { return; }

        musicAudioSource.Play();

        if (isMusicPaused)
            musicAudioSource.Pause();
    }
    /// <summary>
    /// Sets music volume.
    /// </summary>
    /// <param name="newVolume">Volume.</param>
    public void SetMusicVolume(float newVolume)
    {
        if(musicAudioSource == null) { return; }
        musicAudioSource.volume = newVolume;
    }
    /// <summary>
    /// Sets soundFX volume.
    /// </summary>
    /// <param name="newVolume">Volume.</param>
    public void SetSoundFXVolume(float newVolume)
    {
        if(soundFXAudioSource == null) { return; }
        soundFXAudioSource.volume = newVolume;
    }
    #endregion
}
