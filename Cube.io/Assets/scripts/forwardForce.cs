using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forwardForce : MonoBehaviour
{
    public float BackwordForce = -200f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void FixedUpdate ()
    {
        rb.AddForce(0, 0, BackwordForce * Time.deltaTime);
    
    }
 

}
