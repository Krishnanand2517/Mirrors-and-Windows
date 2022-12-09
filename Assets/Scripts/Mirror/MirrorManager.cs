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
        StaticData.player.transform.position = mirror.position + mirror.right.normalized * 2;
    }
    public void PlaySound(Mirror mirror)
    {
        if (mirror.type == Dimension.Mirror)
        {
            mirror.source.clip = mirrorDimensionEnterSound;
        }
        else
        {
            mirror.source.clip = originalDimensionEnterSound;
        }
        mirror.source.Play();
    }
}
public enum Dimension
{
    Mirror,
    Original
}
