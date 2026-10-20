using UnityEngine;

// Purpose: Create a new position to move to, based on current position 
public class MakeEnemyMove : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 target;

    private void Start()
    {
        target = GetNewTargetPos();
    }
    void Update()
    {
        // approxiamte if close enough
        if (Vector3.Distance(transform.position, target) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            Vector3 target = GetNewTargetPos();
        }
        // get new target pos can be in an else statement 

        print("current pos: " + transform.position);
        print("target pos: " + target);
        
    }

    private void EnemyMove(Vector3 targetPos)
    {
        // i think this has to be in update(), and it actually returns a Vector new position 
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private Vector3 GetNewTargetPos()
    {
        float coord_x = Random.Range(0, Screen.width);
        float coord_y = Random.Range(0, Screen.height);
        Vector3 rawScreenPos = new Vector3(coord_x, coord_y);

        Vector3 newPos = Camera.main.ScreenToWorldPoint(rawScreenPos);

        // clamp the z position to one value
        newPos.z = transform.position.z;

        // make it so the movement isnt shakey
        newPos.x = newPos.x + 5f;
        newPos.y = newPos.y + 5f;
        // print(newPos);

        return newPos;
    }


}
