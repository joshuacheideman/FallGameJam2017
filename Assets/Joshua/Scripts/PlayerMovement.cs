using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	float movementHoriz;
	float movementVert;
	float speed = 5.0f;
    Vector3 offset;
	GameObject CurrentCam;
	Transform CameraTransform;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		CurrentCam = GameObject.FindGameObjectWithTag ("MainCamera");
		offset = CurrentCam.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		movementHoriz = Input.GetAxis ("Horizontal");
		movementVert = Input.GetAxis ("Vertical");
		rb.AddForce(movementHoriz*speed,0.0f,movementVert*speed);
	}
	void LateUpdate()
	{
		CurrentCam.transform.position = this.transform.position + offset;
	}
}
