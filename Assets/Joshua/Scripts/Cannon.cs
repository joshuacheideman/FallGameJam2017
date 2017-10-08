using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	public Transform CannonFire;
	Rigidbody PlayerRb;
	float FireSpeed = 20.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") 
		{
			col.gameObject.transform.position = new Vector3 (CannonFire.transform.position.x, CannonFire.transform.position.y, CannonFire.transform.position.z);
			PlayerRb = col.gameObject.GetComponent<Rigidbody> ();
			Debug.Log (CannonFire.forward);
			PlayerRb.AddForce (CannonFire.forward * FireSpeed,ForceMode.Impulse);
		}
	}
}
