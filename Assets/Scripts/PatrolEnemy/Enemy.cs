using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    public TypePatrol type;
    public float speed = 2f;
    public float waitTime = 1;

    [Header("Sprites")] 
    public Sprite forwardSprite;
    public Sprite backwardSprite;
    
    
    private int targetPointID = 1;
    private int currentPointID = 0;

    private bool isMoving = true;
    private bool isRightFaced;
    
    private SpriteRenderer renderer;
    
    private void Start()
    {
        transform.position = points[0].position;
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    int GetNextPoint(int currentPointID)
    {
        if (type == TypePatrol.Circle)
        {
            if (currentPointID == points.Count-1)
            {
                return 0;
            }
            else
            {
                return ++currentPointID;
            }
        }
        else
        {
            if (currentPointID == points.Count - 1 || currentPointID == 0)
            {
                points.Reverse();
                currentPointID = 0;
                return 1;
            }
            else
            {
                return ++currentPointID;
            }
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(!isMoving) return;
        
        
        transform.position = Vector3.MoveTowards(transform.position, points[targetPointID].position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, points[targetPointID].position) <= 0.2f)
        {
            currentPointID = targetPointID;
            targetPointID = GetNextPoint(currentPointID);
            StartCoroutine(Wait());
        }
    }

    void CheckRotate(Transform from, Transform to)
    {
        var isRightDirection = to.position.x - from.position.x > 0;
        
        if (from.position.y < to.position.y) renderer.sprite = backwardSprite;
            else renderer.sprite = forwardSprite;

        if (isRightFaced != isRightDirection)//flip
        {
            transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y);
            isRightFaced = isRightDirection;
        }

        
    }

    IEnumerator Wait()
    {
        isMoving = false;
        yield return new WaitForSeconds(waitTime);
        isMoving = true;
        CheckRotate(points[currentPointID],points[targetPointID]);
    }
}
public enum TypePatrol
{
    ForwardAndBack,
    Circle
}