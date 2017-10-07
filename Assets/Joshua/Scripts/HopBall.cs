using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopBall : MonoBehaviour {

	float JumpForce = 100.0f;
	public void Hop(bool isGrounded,Rigidbody rb)
	{
		if (isGrounded && Input.GetButtonDown ("Jump")) {
			Debug.Log ("Is Jumping");
			rb.AddForce (0.0f, JumpForce, 0.0f);
		}
	}
}
