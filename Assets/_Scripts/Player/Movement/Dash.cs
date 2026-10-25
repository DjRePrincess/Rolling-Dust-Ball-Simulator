using System;
using System.Collections;
using UnityEngine;

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
    [SerializeField] private float dashSpeed = 20f;
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
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

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

        //// this if else statement should be in fixed update? physics based movement in should be in fixedupdate()
        //if (isDashing)
        //{
            
        //}
        //else
        //{
        //    EnableMovement();
        //}
    }
    private void FixedUpdate()
    {
        // put isdashing check too?
    }

    private IEnumerator MakePlayerDash()
    {
        isDashing = true;
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
