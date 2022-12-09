using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    [SerializeField] IInteractive triggeredObject; 
    
    private bool isTriggerid;

    private void OnTriggerStay(Collider other)
    {
        isTriggerid = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggerid = false;
    }
}

interface IInteractive
{
    IEnumerator Trigger();
}
