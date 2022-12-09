using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        StaticData.canvasController = this;
        StaticData.player = GameObject.Find("Player");//Change
        
        _animator = GetComponent<Animator>();
        
    }

    public void StartFadeAnimation()
    {
        _animator.SetTrigger("dimensionFade");
    }
    
    public void MirrorFadeAnimation()
    {
        StaticData.manager.TeleportInOtherDimension(StaticData.connectedMirror);
        StaticData.manager.PlaySound(StaticData.connectedMirror);
    }
}
