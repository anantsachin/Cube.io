using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {

	public GameControl gameControl;

	void OnTriggerEnter ()
	{
		gameControl.CompleteLevel();
	}

}

