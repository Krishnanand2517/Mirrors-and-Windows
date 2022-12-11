using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private Animator _animator;

    public GameObject filterPanel;
    public TMP_Text HPText;

    private void Start()
    {
        StaticData.canvasController = this;
        StaticData.player = GameObject.Find("Player");//Change
        StaticData.player.GetComponent<PlayerController>().onHealthChanged += StaticData.canvasController.ChangeHPBar;
        _animator = GetComponent<Animator>();
        
    }

    public void StartFadeAnimation()
    {
        _animator.SetTrigger("dimensionFade");
    }
    
    public void MirrorFadeAnimation()
    {
        if (StaticData.connectedMirror.type == Dimension.Mirror)
        {
            filterPanel.SetActive(true);
        }
        else
        {
            filterPanel.SetActive(false);
        }
        StaticData.manager.TeleportInOtherDimension(StaticData.connectedMirror);
        StaticData.manager.PlaySound(StaticData.connectedMirror);
    }

    public void ChangeHPBar(int newHP)
    {
        HPText.text = "x" + newHP;
    }
}
