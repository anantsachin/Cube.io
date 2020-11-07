
using UnityEngine;

public class followplayer : MonoBehaviour {
  
public Transform Player1;
public Vector3 offset;

    // Update is called once per frame
    void Update() {
    transform.position = Player1.position + offset;
        
    }
}
