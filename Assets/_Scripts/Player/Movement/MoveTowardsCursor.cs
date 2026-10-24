using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;

// Purpose: to make the dustball move towards the cursor
// Side Effect: The dustball changes z to be near the camera clip plane
//  The dustball starts near the bg z, then changes z on runtime
public class MoveTowardsCursor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    // Dash stuff
    private MyInput myInput;
    private float dashSpeed = 20f;

    // true for now for debugging purposes 
    private bool canDash = true;


    
    void Update()
    {
        Vector3 mousePosition = MouseScreenToWorld();
        bool playerDashed = myInput.Player.Dash.triggered;

        if (canDash && playerDashed)
        {
            print("dashed");
            GameObjMoveTowardsCursor(mousePosition, dashSpeed);
        }
        else
        {
            GameObjMoveTowardsCursor(mousePosition, moveSpeed);
        }

        
    }

    private Vector3 MouseScreenToWorld()
    {
        // Mouse class -> new input system
        // convert the raw mouse position, screen to world coord
        // make the sprite follow close to the camera z? 

        Vector2 mousePositionRaw = Mouse.current.position.ReadValue();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePositionRaw);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        return mousePosition;
    }

    private void GameObjMoveTowardsCursor(Vector3 mousePosition, float speed)
    {
        // need to access the actual transform.position, putting it in a variable and changing that, wont work 
        // make the gameobj (this script is attached to) move towards the cursor 

        Vector3 curr_pos = transform.position;
        transform.position = Vector2.MoveTowards(curr_pos, mousePosition, speed * Time.deltaTime);
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
