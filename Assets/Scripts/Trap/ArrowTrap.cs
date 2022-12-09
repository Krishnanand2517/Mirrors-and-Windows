using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour,IInteractive
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float speed = 1;
    [SerializeField] private float delay= 0.3f;


    public IEnumerator Trigger()
    {
        yield return new WaitForSeconds(delay);
        Rigidbody2D arrow = Instantiate(projectile,transform.position,transform.rotation).GetComponent<Rigidbody2D>();
        arrow.MovePosition(transform.right * speed);
    }
}
