using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushpower : MonoBehaviour {
public float radious = 5f;  
public GameObject Blasteffect;
public float force = 7000f;
void OnCollisionEnter (Collision other)
{
   
 
  Pickup(other);
 
}

   void Pickup(Collision Player)
 {
 Instantiate(Blasteffect, transform.position, transform.rotation);
 
 Collider[] colliders = Physics.OverlapSphere(transform.position , radious);
 FindObjectOfType<AudioManager>().Play("Explosion1");

 foreach (Collider nearbyobject in colliders)
 {
  Rigidbody rb = nearbyobject.GetComponent<Rigidbody>(); 
  if (rb != null)
  {
     rb.AddExplosionForce(force, transform.position, radious );
  }

 }
 
 Destroy(gameObject);
 
 
 }

}




 
