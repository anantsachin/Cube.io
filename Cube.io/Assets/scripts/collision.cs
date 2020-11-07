
using UnityEngine;

public class collision : MonoBehaviour {

 public Test movement;		// A reference to our PlayerMovement script
 
	// This function runs when we hit another object.
	// We get information about the collision and call it "collisionInfo".
	void OnCollisionEnter (Collision collisionInfo)
	{
		// We check if the object we collided with has a tag called "Obstacle".
		if (collisionInfo.collider.tag == "obstacle")
		{
		movement.enabled = false;
                FindObjectOfType<GameControl>().EndGame();
                
		}
	}

}
