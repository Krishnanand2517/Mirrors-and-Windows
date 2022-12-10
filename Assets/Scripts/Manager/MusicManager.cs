using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MusicManager : MonoBehaviour
{
    public AudioSource mirrorWorldMusic;
    public AudioSource originalWorldMusic;

    [Range(0,1)]public float musicVolume = 0.7f;

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
}
