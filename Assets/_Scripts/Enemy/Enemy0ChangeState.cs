using UnityEngine;

public class Enemy0ChangeState : MonoBehaviour
{
    [SerializeField] private Vector3 enemyScaleIdle = new Vector3(2.5f, 2.5f, 2.5f);
    [SerializeField] private Vector3 enemyScaleAttack = new Vector3(8.0f, 8.0f, 8.0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeToIdleState();
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
