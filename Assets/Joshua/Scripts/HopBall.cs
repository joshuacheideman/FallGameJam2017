using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopBall : MonoBehaviour {

	public float JumpForce = 250.0f;
	public void Hop(bool isGrounded,Rigidbody rb)
	{
		if (isGrounded && Input.GetButtonDown ("Jump"))
		{
			rb.AddForce (0.0f, JumpForce, 0.0f);
		}
	}
}
