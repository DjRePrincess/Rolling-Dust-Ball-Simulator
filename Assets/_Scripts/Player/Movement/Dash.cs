using System;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private MoveTowardsCursor movementComponent;
    [SerializeField] private bool canDash = false;
    void Start()
    {
        movementComponent = GetComponent<MoveTowardsCursor>();

    }
    // Update is called once per frame
    void Update()
    {
        if (canDash)
        {
            movementComponent.enabled = false;
        }
        else
        {
            movementComponent.enabled = true;
        }
    }


}
