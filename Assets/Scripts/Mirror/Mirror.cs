using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mirror : MonoBehaviour
{
    
    [Header("Mirror Data")]
    public Dimension type;
    public AudioSource source;
    
    [Header("Connected Mirror")]
    public Mirror connectedMirror;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StaticData.connectedMirror = connectedMirror;
            StaticData.canvasController.StartFadeAnimation();
        }
    }
}

