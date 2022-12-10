using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public TriggeredObject triggeredObject;
    private Coroutine activateObjectFunction;

    public int objectOnPlateCount = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        objectOnPlateCount++;

        if (objectOnPlateCount == 1)
        {
            activateObjectFunction = StartCoroutine(triggeredObject.PushEvent());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objectOnPlateCount--;
        
        if(objectOnPlateCount == 0)
        {  
            StopCoroutine(activateObjectFunction);
        }
    }
}

[Serializable]
public abstract class TriggeredObject: MonoBehaviour
{
    public abstract IEnumerator PushEvent();
}
