using Unity.VisualScripting;
using UnityEngine;

public class Enemy0ChangeState : MonoBehaviour
{
    [SerializeField] private Vector3 enemyScaleIdle = new Vector3(2.5f, 2.5f, 2.5f);
    [SerializeField] private Vector3 enemyScaleAttack = new Vector3(8.0f, 8.0f, 8.0f);
    private int state = 1;
    private int attackState = 1;
    private int idleState = -1;

    private float stateChangeChance = 1;
    private float changeSpeed = 100f;

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
        gameObject.transform.localScale = enemyScaleIdle;

        // gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, enemyScaleIdle, changeSpeed * Time.deltaTime);
    }


    private void ChangeToAttackState()
    {
        gameObject.transform.localScale = enemyScaleAttack;

        // idk about lerping, because this method is fired once only, lerp needs to be on actual update()
        // gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, enemyScaleAttack, changeSpeed * Time.deltaTime);


    }
}
