
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    public Transform Player1;
    public Text scoretext;
	
	// Update is called once per frame
	void Update () {
       scoretext.text = Player1.position.z.ToString("0");
        
	}
}
