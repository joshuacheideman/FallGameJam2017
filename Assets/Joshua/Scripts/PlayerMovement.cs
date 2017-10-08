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
	bool isGrounded;
    Vector3 offset;
	public GameObject CurrentCam;
	CameraManager CamMang;
	HopBall hop;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		offset = CurrentCam.transform.position - this.transform.position;
		BallMesh = this.gameObject.GetComponent<MeshRenderer> ();
		hop = GetComponent<HopBall> ();
		isGrounded = false;
	}
	
	// Update is called once per frame
	void Update () {
		movementHoriz = Input.GetAxis ("Horizontal");
		movementVert = Input.GetAxis ("Vertical");
		if (BallMesh.material.color == Color.green) //checks if ball has a green material
			hop.Hop (isGrounded,rb);
		if (BallMesh.material.color == Color.blue)
			speed = 8.0f;
		else
			speed = 5.0f;
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
				rb.velocity = new Vector3 (axis_velocity, rb.velocity.y, rb.velocity.z);
			else if(axis_velocity>=0 && rb_velocity_axis<0)
				rb.velocity = new Vector3 (-axis_velocity, rb.velocity.y, rb.velocity.z);
		}
		else {
			if (axis_velocity >= 0 && rb_velocity_axis > 0)
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, axis_velocity);
			else if(axis_velocity>=0 && rb_velocity_axis<0)
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, -axis_velocity);
		}
	}
	void LateUpdate()
	{
		CurrentCam.transform.position = this.transform.position + offset;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Floor")
		{
			isGrounded = true;
		}
	}
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "Floor")
		{
			isGrounded = false;
		}
	}
}
