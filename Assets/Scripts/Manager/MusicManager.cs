using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;

public class MusicManager : MonoBehaviour
{
    public AudioSource mirrorWorldMusic;
    public AudioSource originalWorldMusic;

    public AudioSource soundsSource;
    [Header("Sounds")] 
    public AudioClip walkSound;
    public AudioClip dashSound;
    public AudioClip openDoorSound;
    public AudioClip uiClickSound;


    [Range(0,1)]public float musicVolume = 0.7f;
    [Range(0,1)]public float soundsVolume = 0.7f;
    

    void Start()
    {
        StaticData.musicManager = this;
        PlayMusic(Dimension.Original);
    }

    public void PlayMusic(Dimension dimension)
    {
        if (dimension == Dimension.Mirror)
        {
            mirrorWorldMusic.volume = musicVolume;
            originalWorldMusic.volume = 0;
        }
        else
        {
            originalWorldMusic.volume = musicVolume;
            mirrorWorldMusic.volume = 0;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        soundsSource.volume = soundsVolume;
        soundsSource.clip = clip;
        soundsSource.Play();
    }
    
}
