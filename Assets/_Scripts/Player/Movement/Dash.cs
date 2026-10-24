using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 forceVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // i think this is just the direction vector
        forceVector = Vector3.right;
        //rb.AddForce(forceVector * 10f, ForceMode.Impulse);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
