using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followm : MonoBehaviour {
 
public Transform Meteior;
public Vector3 offset;

    // Update is called once per frame
    void Update() 
    {

    transform.position = Meteior.position + offset;
        
    }
}
