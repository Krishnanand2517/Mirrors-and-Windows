using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip mirrorWorldMusic;
    public AudioClip originalWorldMusic;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        StaticData.musicManager = this;
        PlayMusic(Dimension.Original);
    }

    public void PlayMusic(Dimension dimension)
    {
        if (dimension == Dimension.Mirror)
        {
            source.clip = mirrorWorldMusic;
        }
        else
        {
            source.clip = originalWorldMusic;
        }
        
        source.Play();
    }
}
