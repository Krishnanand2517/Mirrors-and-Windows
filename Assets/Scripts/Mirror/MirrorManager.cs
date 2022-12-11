using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MirrorManager : MonoBehaviour
{
    [Header("Mirror Sounds")]
    public AudioClip mirrorDimensionEnterSound;
    public AudioClip originalDimensionEnterSound;

    private void Start()
    {
        StaticData.manager = this;
    }
    public void TeleportInOtherDimension(Mirror connectedMirror)
    {
        var mirror = connectedMirror.transform;
        StaticData.player.transform.position = mirror.position + Vector3.down ;
    }
    public void PlaySound(Mirror mirror)
    {
        if (mirror.type == Dimension.Mirror)
        {
            mirror.source.clip = mirrorDimensionEnterSound;
            StaticData.musicManager.PlayMusic(Dimension.Mirror);
        }
        else
        {
            mirror.source.clip = originalDimensionEnterSound;
            StaticData.musicManager.PlayMusic(Dimension.Original);
        }
        mirror.source.Play();
    }
}
public enum Dimension
{
    Mirror,
    Original
}
