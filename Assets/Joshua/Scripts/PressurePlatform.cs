using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatform : MonoBehaviour {
	// Use this for initialization
	public bool isPressed = false;
	// Update is called once per frame
	public bool GetSwitch()
	{
			return isPressed;
	}
	void OnCollisionEnter(Collision col)
	{
			if(col.collider.gameObject.tag =="Player")
			{	
				isPressed = true;
			}	
	}
	void OnCollisionExit(Collision col)
	{
		if (col.collider.gameObject.tag == "Player") {
			isPressed = false;
		}
	}

}
