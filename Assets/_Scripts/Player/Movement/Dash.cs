using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();


        //rb.AddForce();

    // Update is called once per frame
    void Update()
    {
        
    }
}
