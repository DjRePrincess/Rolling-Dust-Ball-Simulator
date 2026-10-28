using Unity.VisualScripting;
using UnityEngine;

// This script won't work on the sphere enemies now 
public class Enemy0ChangeState : MonoBehaviour
{
    //[SerializeField] private Vector3 enemyScaleIdle = new Vector3(2.5f, 2.5f, 2.5f);
    //[SerializeField] private Vector3 enemyScaleAttack = new Vector3(8.0f, 8.0f, 8.0f);
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite attackSprite;
    private int state = 1;
    private int attackState = 1;
    private int idleState = -1;

    private float stateChangeChance = 1;
    private float changeSpeed = 100f;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // print(state);

        float num = Random.Range(1, 500);
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
        // change to idle sprite via spriteRenderer
     
    }


    private void ChangeToAttackState()
    {
        // change to attack sprite 


    }
}
