using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] string keyName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (GameManager.instance.HasItem(keyName))
            {
                Debug.Log("Next Level");
                GameManager.instance.RemoveItem(keyName);
                GameManager.instance.FinishLevel();

            }
            else
            {
                Debug.Log("You need a key");
            }
        }
    }
}
