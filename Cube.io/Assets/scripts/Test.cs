
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Test : MonoBehaviour
{
    public Rigidbody rb;
    private float dirX;
    public float movespeed = 100f;
    public float forwardForce = 2000f;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      rb.AddForce(0, 0, forwardForce );

        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * movespeed ;
        rb.velocity = new Vector3(dirX, rb.velocity.y);
        
 if (rb.position.y < -1f)
{
          FindObjectOfType<GameControl>().EndGame();
         
          }
	

    }
          
}
