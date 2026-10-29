using System;
using Unity.VisualScripting;
using UnityEngine;

// This script won't work on the sphere enemies now 
public class Enemy0ChangeState : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite attackSprite;

    // State stuff
    private int state = 1;
    private int attackState = 1;
    private int idleState = -1;

    private float stateChangeChance = 1;

    // Collider size stuff
    
    // doesnt change
    private float colliderSizeY = 3.5f;
    private float colliderOffsetX = -0.5f;

    // Changes
    private float idleColliderSizeX = 9f;
    private float attackColliderOffsetY = -7.95f;
    private float attackColliderSizeX = 16f;
    private float idleColliderOffsetY = -9f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        // make into an idle state 
        // and change the collider size appropiately
        state = idleState;
        ChangeToIdleState();
    }

    private void Update()
    {
        // print(state);

        float num = UnityEngine.Random.Range(1, 500);
        // print(num);
        if (num == stateChangeChance)
        {

            // could be a method for name clarity
            state = state * -1;

            // could be a switch statement for more readability 
            if (state == attackState)
            {
                ChangeToAttackState();
            }
            else if (state == idleState)
            {
                ChangeToIdleState();
            }
        }
    }

    // ----------------------------------------

    private void ChangeToIdleState()
    {
        spriteRenderer.sprite = idleSprite;
        capsuleCollider.center = new Vector3(-0.3f, -9f, 0);
        capsuleCollider.radius = 2f;
        capsuleCollider.height = 8f;
    }


    private void ChangeToAttackState()
    {
        spriteRenderer.sprite = attackSprite;
        capsuleCollider.center = new Vector3(-0.5f, -7.85f, 0);
        capsuleCollider.radius = 2.7f;
        capsuleCollider.height = 13.3f;

    }
}
