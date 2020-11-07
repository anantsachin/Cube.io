using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedinplane : MonoBehaviour {
public GameObject Speedup;
public float multiplier = 2f;
public float duration = 1.5f;
void OnTriggerEnter (Collider other)
{
   if (other.CompareTag("Player"))
 {
  StartCoroutine( Pickup(other));
 }
}

   IEnumerator Pickup(Collider Player)
 {
 Instantiate(Speedup, transform.position, transform.rotation);
 FindObjectOfType<AudioManager>().Play("speed");
 Player.GetComponent<player1>().forwardForce *= multiplier;
 
 yield return new WaitForSeconds(duration); 

 Player.GetComponent<player1>().forwardForce /= multiplier;
 
 
 }

   
}
