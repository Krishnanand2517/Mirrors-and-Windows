using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public TriggeredObject triggeredObject;

    private Coroutine activateObjectFunction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        activateObjectFunction = StartCoroutine(triggeredObject.PushEvent());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StopCoroutine(activateObjectFunction);
    }
}

[Serializable]
public abstract class TriggeredObject: MonoBehaviour
{
    public abstract IEnumerator PushEvent();
}
