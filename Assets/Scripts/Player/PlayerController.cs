using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dashAmount = 10f;
    [SerializeField] Animator animator;
    [SerializeField] TrailRenderer trailRenderer;
    Rigidbody2D playerRb;
    

    float dashTime = 0.25f;
    float dashTimer = 0;
    bool isDashButtonPressed = false;

    Vector3 moveVector;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dashTimer += Time.deltaTime;

        float moveX = 0f;
        float moveY = 0f;
        transform.localScale = new Vector3(1, 1, 1);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveX = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }

        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }

        moveVector = new Vector3(moveX, moveY);

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveVector.magnitude);

        // Dash
        if (Input.GetKeyDown(KeyCode.Space) && dashTimer >= dashTime)
        {
            isDashButtonPressed = true;
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity = moveVector * moveSpeed;

        if (isDashButtonPressed)
        {
            Vector2 dashPosition = transform.position + moveVector * dashAmount;

            playerRb.MovePosition(dashPosition);
            StartCoroutine(ShowDashTrail());
            isDashButtonPressed = false;
            dashTimer = 0;
        }
    }

    IEnumerator ShowDashTrail()
    {
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(0.05f);
        trailRenderer.emitting = false;
    }

    void Attack()
    {

    }
}
