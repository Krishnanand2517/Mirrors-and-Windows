using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DashBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject dashBoard;

    private TextAnimation textAnim;
    private void Start()
    {
        StaticData.dashBoardManager = this;
        textAnim = dashBoard.GetComponentInChildren<TextAnimation>();
    }

    public void ShowDashBoard(Vector2 position, string text)
    {
        dashBoard.SetActive(true);
        dashBoard.transform.position = position;
        textAnim.animatedText = text;
        StartCoroutine(WaitSeconds(5));
    }
    IEnumerator WaitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        dashBoard.SetActive(false);
    }
}
