using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDesk : MonoBehaviour
{
    public int timeForDisactivate;
    public string text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var pos = transform.position;
        StaticData.dashBoardManager.ShowDashBoard(new Vector2(pos.x + 1,pos.y +1),text,timeForDisactivate);
    }
}
