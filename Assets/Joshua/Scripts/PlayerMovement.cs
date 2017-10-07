using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	MeshRenderer BallMesh;
	float movementHoriz;
	float movementVert;
	float JumpForce;
	float speed = 5.0f;
	bool isGrounded=false;
    Vector3 offset;
	GameObject CurrentCam;
	HopBall hop;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		CurrentCam = GameObject.FindGameObjectWithTag ("MainCamera");
		offset = CurrentCam.transform.position - this.transform.position;
		BallMesh = this.gameObject.GetComponent<MeshRenderer> ();
		hop = GetComponent<HopBall> ();
	}
	
	// Update is called once per frame
	void Update () {
		movementHoriz = Input.GetAxis ("Horizontal");
		movementVert = Input.GetAxis ("Vertical");
		if (BallMesh.material.color == Color.green) //checks if ball has a green material
			hop.Hop (isGrounded,rb);
		rb.AddForce(movementHoriz*speed,0.0f,movementVert*speed);
	}
	void LateUpdate()
	{
		CurrentCam.transform.position = this.transform.position + offset;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Floor")
			isGrounded = true;
	}
}
