using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<string> inventory = new List<string>();
    public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PickUpItem(GameObject item)
    {
        inventory.Add(item.name);
    }

    public bool HasItem(string name)
    {
        if (inventory.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveItem(string name)
    {
        if (inventory.Contains(name))
        {
            inventory.Remove(name);
        }
        else
        {
            Debug.Log(name + " not present in inventory.");
        }
    }

    public void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER!!!!");
    }
}
