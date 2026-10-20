using UnityEngine;
using UnityEngine.UIElements;

// Purpose: Create a new position to move to, based on current position 
public class MakeEnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 target;

    private void Start()
    {
        target = GetNewTargetPos();
    }
    void Update()
    {
        if (transform.position != target)
        {
            EnemyMoveTo(target);
        }
        else
        {
            target = GetNewTargetPos();
        }

        print("current pos: " + transform.position);
        print("target pos: " + target);
        
    }

    private void EnemyMoveTo(Vector3 targetPos)
    {
        // i think this has to be in update(), and it actually returns a Vector new position 
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private Vector3 GetNewTargetPos()
    {
        float coord_x = Random.Range(0, Screen.width);
        float coord_y = Random.Range(0, Screen.height);

        Vector3 rawScreenPos = new Vector3(coord_x, coord_y);
        Vector3 newPos = Camera.main.ScreenToWorldPoint(rawScreenPos);

        // clamp the z position to one value
        newPos.z = transform.position.z;

        return newPos;
    }


}
