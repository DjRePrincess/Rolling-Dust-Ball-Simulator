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
    private float moveX;
    private float moveY;
    private Vector2 moveDirection;

    [Header("Dash Fields")]
    [SerializeField] private bool isDashing = false;
    [SerializeField] private float dashSpeed = 5f;
    private float dashDuration = 1f;
    private float dashCooldown = 1f;
    void Start()
    {
        movementComponent = GetComponent<MoveTowardsCursor>();
        rb = GetComponent<Rigidbody>();

    }
    // prob need to be in fixedUpdate(), the physics dash stuff 
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        // would the move variables being decalred before start() hae consequences?
        // would this be mouse input? NOPE 
        //moveX = Input.GetAxisRaw("Horizontal");
        //moveY = Input.GetAxisRaw("Vertical");

        moveX = transform.position.x;
        moveY = transform.position.y;
        //print(moveX);

        // because this is like a 1 and 0 vector, just a direction vector
        moveDirection = new Vector2(moveX, moveY).normalized; // GetMovementDirection()
        print(moveDirection);

        // this is how you see if an action is triggered
        // doesnt the coroutine dash, need to be in fixed update()
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
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    private Vector2 GetMovementDirection()
    {

    }

    private IEnumerator MakePlayerDash()
    {
        isDashing = true;
        // cant this be the current linear velocity 
        rb.linearVelocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);

        // ngl, idk what yield return new ACTUALLY does 
        yield return new WaitForSeconds(dashDuration);
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
