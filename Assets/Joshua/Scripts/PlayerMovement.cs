using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	float movementHoriz;
	float movementVert;
	float speed = 5.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		movementHoriz = Input.GetAxis ("Horizontal");
		movementVert = Input.GetAxis ("Vertical");
		rb.AddForce(movementHoriz*speed,0.0f,movementVert*speed);
	}
}
