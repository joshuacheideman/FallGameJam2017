using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
	Rigidbody PlayerRb;
	Vector3 JumpPadForce = new Vector3 (0.0f,10.0f,0.0f);
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log (col.gameObject.name);
			PlayerRb = col.gameObject.GetComponent<Rigidbody> ();
			PlayerRb.AddForce (JumpPadForce,ForceMode.Impulse);
		}
	}
}
