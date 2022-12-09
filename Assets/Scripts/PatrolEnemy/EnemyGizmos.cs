using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyGizmos : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < enemy.points.Count-1; i++)
        {
            Transform currentPoint = enemy.points[i];
            Transform nextPoint = enemy.points[i+1];
            
            Debug.DrawLine(currentPoint.position, nextPoint.position);
            
            if (enemy.type == TypePatrol.Circle && i == enemy.points.Count-2)
            {
                Debug.DrawLine(nextPoint.position, enemy.points[0].position);
            }
        }
    }
}
