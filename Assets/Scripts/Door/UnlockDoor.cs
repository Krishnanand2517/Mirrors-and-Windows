using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] string keyName;
    [SerializeField] private Vector2 positionOffDashBoard;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (GameManager.instance.HasItem(keyName))
            {
                StaticData.musicManager.PlaySound(StaticData.musicManager.openDoorSound);
                Debug.Log("Next Level");
                GameManager.instance.RemoveItem(keyName);
                GameManager.instance.FinishLevel();

            }
            else
            {
                Debug.Log("You need a key");
                
                StaticData.dashBoardManager.ShowDashBoard(positionOffDashBoard,"You need key to open that",5);
            }
        }
    }
}
