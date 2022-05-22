using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    public static AudioHandler Instance { get; private set; }

    const int numberBackgroundMusicTracks = 3;

    public enum AUDIO_MUSIC
    {
        spooky = 0
    }

    [Header("Music")]
    [SerializeField] AudioSource musicAudioSource = null;
    [SerializeField] AudioClip[] backgroundMusicTracks = new AudioClip[numberBackgroundMusicTracks];
    [SerializeField] int curBackgroundTrackIndex = 0;
    [SerializeField][Range(0f, 1f)] float musicVolume = 0.7f;

    [Header("SoundFX")]
    [SerializeField] AudioSource soundFXAudioSource = null;
    [SerializeField][Range(0f, 1f)] float soundFXVolume = 0.5f;

    bool isMusicPaused = false;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if(musicAudioSource == null) { return; }

        SetMusicVolume(musicVolume);
        SongRequest(AUDIO_MUSIC.spooky);

        if(soundFXAudioSource == null) { return; }

        SetSoundFXVolume(soundFXVolume);
    }

    public void SongRequest(AUDIO_MUSIC requestedTrack)
    {
        if(musicAudioSource == null) { return; }

        switch(requestedTrack)
        {
            case AUDIO_MUSIC.spooky:
                musicAudioSource.clip = backgroundMusicTracks[0];
                break;
            default:
                break;
        }

        musicAudioSource.Play();

        if (isMusicPaused)
            musicAudioSource.Pause();
    }

    public void PauseMusicToggle()
    {
        isMusicPaused = !isMusicPaused;

        if (isMusicPaused)
            musicAudioSource.Pause();
        else
            musicAudioSource.UnPause();
    }

    #region Setters
    public void SetMusicVolume(float newVolume)
    {
        Mathf.Abs(newVolume);
        Mathf.Clamp(newVolume, 0f, 1f);

        musicVolume = newVolume;

        if(musicAudioSource == null) { return; }
        musicAudioSource.volume = musicVolume;
    }

    public void SetSoundFXVolume(float newVolume)
    {
        Mathf.Abs(newVolume);
        Mathf.Clamp(newVolume, 0f, 1f);

        soundFXVolume = newVolume;

        if(soundFXAudioSource == null) { return; }
        soundFXAudioSource.volume = soundFXVolume;
    }
    #endregion
}
