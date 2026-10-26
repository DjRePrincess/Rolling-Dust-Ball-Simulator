using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    [SerializeField] private MoveTowardsCursor movementComponent;
    private MyInput myInput;
    private Rigidbody rb;

    // Move stuff for dashing
    //private float moveX;
    //private float moveY;
    private float prevX;
    private float prevY;
    private Vector2 moveDirection;

    [Header("Dash Fields")]
    [SerializeField] private bool isDashing = false;
    [SerializeField] private float dashSpeed = 5f;
    private float dashDuration = 0.25f;
    private float dashCooldown = 1f;
    void Start()
    {
        movementComponent = GetComponent<MoveTowardsCursor>();
        rb = GetComponent<Rigidbody>();

        // or instantiate to (0,0)?
        prevX = transform.position.x;
        prevY = transform.position.y;

    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        moveDirection = GetMovementDirection();
        print(moveDirection);

        // this is how you see if an action is triggered
        bool playerDashed = myInput.Player.Dash.triggered;
        if (playerDashed)
        {
            DisableMovement();
            StartCoroutine(MakePlayerDash());
        }
        else
        {
            EnableMovement();
        }
    }

    private Vector2 GetMovementDirection()
    {
        Vector2 curPos = transform.position;
        if ((prevX < curPos.x) && (prevY < curPos.y))
        {
            // player moving to NE direction
            prevX = curPos.x;
            prevY = curPos.y;
            return new Vector2(1, 1);
        }
        else if ((prevX < curPos.x) && (prevY > curPos.y))
        {
            // player moving to SE direction
            prevX = curPos.x;
            prevY = curPos.y;
            return new Vector2(1, -1);
        }
        else if ((prevX > curPos.x) && (prevY > curPos.y))
        {
            // player moving to SW direction
            prevX = curPos.x;
            prevY = curPos.y;
            return new Vector2(-1, -1);
        }
        else if ((prevX > curPos.x) && (prevY < curPos.y))
        {
            // player moving to NW direction
            prevX = curPos.x;
            prevY = curPos.y;
            return new Vector2(-1, 1);
        }
        // how to check if player goes to right. some kind of range to check to ? 
        else if (prevX < curPos.x)
        {
            // player moving to the right 
            prevX = curPos.x;
            return Vector2.right;
        }
        else if (prevX > curPos.x)
        {
            // player moving to the left 
            prevX = curPos.x;
            return Vector2.left;
        }
        else if (prevY < curPos.y)
        {
            // player moving up
            prevY = curPos.y;
            return Vector2.up;
        }
        else if (prevY > curPos.y)
        {
            prevY = curPos.y;
            return Vector2.down;
        }
        else
        {
            // this fires if player is stationary, AND if player changes direction 
            // also not touching prev var on this branch
            print("debug: returning movementDirection zero");
            return Vector2.zero;
        }
    }

    private IEnumerator MakePlayerDash()
    {
        isDashing = true;
        rb.linearVelocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);

        // ngl, idk what yield return new ACTUALLY does 
        yield return new WaitForSeconds(dashDuration);

        // to not have leftover movement after dashing
        rb.linearVelocity = Vector2.zero;
        isDashing = false;
        
    }

    private void EnableMovement()
    {
        movementComponent.enabled = true;
    }
    private void DisableMovement()
    {
        movementComponent.enabled = false;
    }

    // ----------
    // Input instantiation 

    private void Awake()
    {
        myInput = new MyInput();
    }

    private void OnEnable()
    {
        myInput.Enable();
    }

    private void OnDisable()
    {
        myInput.Disable();
    }
}
