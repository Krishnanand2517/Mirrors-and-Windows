using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    private TMP_Text textObj;
    private string text;

    public float delay = 0.2f;

    public string animatedText
    {
        get { return text; }
        set 
        { 
            text = value;
            textObj.text = "";
            StopAllCoroutines();
            StartCoroutine("TextAnimationCorutine");
        }
    }
    private void Start()
    {
        textObj = GetComponent<TMP_Text>();
    }

    IEnumerator TextAnimationCorutine()
    {
        for (int i = 0; i < animatedText.Length; i++)
        {
            textObj.text += animatedText[i];
            yield return new WaitForSeconds(delay);
            
        }
    }
}
