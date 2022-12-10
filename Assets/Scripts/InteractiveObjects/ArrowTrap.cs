using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ArrowTrap : TriggeredObject
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float delayBetweenShots = 0.3f;
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private Transform gunPoint;

    public override IEnumerator PushEvent()
    {
        while (true)
        {
            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(gunPoint.right * projectileSpeed);
            clone.transform.right = gunPoint.right;
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }
    
}
