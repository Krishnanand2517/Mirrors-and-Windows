using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGate : MonoBehaviour
{
    [SerializeField] string keyName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (GameManager.instance.HasItem(keyName))
            {
                Debug.Log("Opened");
                GameManager.instance.RemoveItem(keyName);
                Destroy(gameObject);

            }
            else
            {
                Debug.Log("You need a key");

                StaticData.dashBoardManager.ShowDashBoard(new Vector2(50, 0), "You need key to open that");
            }
        }
    }
}
