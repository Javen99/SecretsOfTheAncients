using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    
    // Variables for mobile input
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isSwiping = false;
    private float minSwipeDistance = 50f; 

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR
        // Keyboard input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
#elif UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR
        // Touch input
        HandleTouchInput();
#endif
    }

    void FixedUpdate ()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleTouchInput ()
    {
        movement = Vector2.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isSwiping = true;
                    touchStartPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        touchEndPos = touch.position;
                        Vector2 swipeDelta = touchEndPos - touchStartPos;

                        if (swipeDelta.magnitude >= minSwipeDistance)
                        {
                            DetectSwipeDirection(swipeDelta);
                            isSwiping = false;
                        }
                    } 
                    break;
                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }

    private void DetectSwipeDirection (Vector2 swipeDelta)
    {
        swipeDelta.Normalize();

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            // Horizontal Swipe
            if (swipeDelta.x > 0)
            {
                // Right Swipe
                movement = Vector2.right;
            }
            else
            {
                // Left Swipe
                movement = Vector2.left;
            }
        }
        else
        {
            // Vertical Swipe
            if (swipeDelta.y > 0)
            {
                // Up Swipe
               movement = Vector2.up;
            }
            else
            {
                // Down Swipe
                movement = Vector2.down;
            }
        }
    }
}