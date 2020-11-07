
using UnityEngine;

public class sidefall : MonoBehaviour {
public Rigidbody rc;
    
          void Start() {
 
 gameObject.GetComponent<MeshRenderer>().enabled = true;
 
 }
 
 void OnCollisionEnter(Collision collision) {
 
 gameObject.GetComponent<MeshRenderer>().enabled = false;
 FindObjectOfType<AudioManager>().Play("Explosion1");
 }


    // Update is called once per frame
    void Update()
    {
      
    }

}
