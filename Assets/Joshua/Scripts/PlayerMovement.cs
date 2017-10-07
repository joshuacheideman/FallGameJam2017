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
	float slowdown = 0.1f;
	float x_velocity;
	float z_velocity;
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
		if (movementHoriz == 0) {
			x_velocity = Mathf.Abs (rb.velocity.x);
			SlowDown (x_velocity, rb.velocity.x, rb, true);
		}
		if (movementVert == 0){
			z_velocity = Mathf.Abs (rb.velocity.z);
			SlowDown (z_velocity, rb.velocity.z, rb,false);
		}
	}
	void SlowDown(float axis_velocity,float rb_velocity_axis, Rigidbody rb,bool isHorizontal)
	{
		axis_velocity -= slowdown;
		if (axis_velocity < 0)
			axis_velocity = 0;
		if (isHorizontal) {
			if(axis_velocity >=0 &&rb_velocity_axis>0)
				rb.velocity = new Vector3 (axis_velocity, 0.0f, rb.velocity.z);
			else if(axis_velocity >=0 && rb_velocity_axis<0)
				rb.velocity = new Vector3 (-axis_velocity, 0.0f, rb.velocity.z);
		}
		else {
			if (axis_velocity >= 0 && rb_velocity_axis > 0)
				rb.velocity = new Vector3 (rb.velocity.x, 0.0f, axis_velocity);
			else if (axis_velocity >= 0 && rb_velocity_axis < 0)
				rb.velocity = new Vector3 (rb.velocity.x, 0.0f, -axis_velocity);
		}
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
