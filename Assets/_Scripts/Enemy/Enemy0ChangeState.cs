using UnityEngine;

public class Enemy0ChangeState : MonoBehaviour
{
    [SerializeField] private Vector3 enemyScaleIdle = new Vector3(2.5f, 2.5f, 2.5f);
    [SerializeField] private Vector3 enemyScaleAttack = new Vector3(8.0f, 8.0f, 8.0f);
    
    [SerializeField] private SimpleTimer timer;
    private int state = 1;
    private int attackState = 1;
    private int idleState = -1;
    void Start()
    {
        // gameObject.AddComponent<SimpleTimer>(SimpleTimer timer);

        // SimpleTimer timer = gameObject.AddComponent<SimpleTimer>();

        StartTimer();
    }

    private void Update()
    {
        if (timer.timerEnded())
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

            StartTimer();
        }
    }

    // ----------------------------------------

    private void StartTimer()
    {
        // the float we pass in is random 
        float time = GetRandomTime();
        timer.setTargetTime(time);
    }

    private float GetRandomTime()
    {
        float time = Random.Range(5.0f, 10.0f);
        return time;
    }

    private void ChangeToIdleState()
    {
        // this is a vector3
        gameObject.transform.localScale = enemyScaleIdle;
    }


    private void ChangeToAttackState()
    {
        // this is a vector3
        gameObject.transform.localScale = enemyScaleAttack;
    }
}
