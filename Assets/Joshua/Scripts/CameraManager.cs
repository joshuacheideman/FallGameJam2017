using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	public CameraToPlayer[] OurPlayers;
	int numPlayers;
	int curPlayer;
	GameObject Camera;
	PlayerMovement PlayerMove;
	Rigidbody PlayerRigidbody;
	// Use this for initialization
	void Start()
	{
		numPlayers = OurPlayers.Length;
		curPlayer = 0;
		DisableAllPlayers ();
		EnableFirstPlayer ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("CameraSwitch")) {
			if (curPlayer < numPlayers - 1)//get next player and disable current player movement 
			{
				PlayerMove = OurPlayers [curPlayer].Player.GetComponent<PlayerMovement> ();
				PlayerRigidbody = OurPlayers [curPlayer].Player.GetComponent<Rigidbody> ();
				PlayerRigidbody.Sleep ();
				PlayerMove.enabled = false;
				Camera = OurPlayers [curPlayer].Camera;
				Camera.SetActive (false);
				curPlayer++;
				PlayerMove = OurPlayers [curPlayer].Player.GetComponent<PlayerMovement> ();
				PlayerMove.enabled = true;
				Camera = OurPlayers [curPlayer].Camera;
				Camera.SetActive (true);
			}
			else if (curPlayer == numPlayers - 1)  //On last player switch to first player 
			{ 
				PlayerMove = OurPlayers [curPlayer].Player.GetComponent<PlayerMovement> ();
				PlayerRigidbody = OurPlayers [curPlayer].Player.GetComponent<Rigidbody> ();
				PlayerRigidbody.Sleep ();
				PlayerMove.enabled = false;
				Camera = OurPlayers [curPlayer].Camera;
				Camera.SetActive (false);
				curPlayer = 0;
				PlayerMove = OurPlayers [curPlayer].Player.GetComponent<PlayerMovement> ();
				PlayerMove.enabled = true;
				Camera = OurPlayers [curPlayer].Camera;
				Camera.SetActive (true);
			}
		}
	}
	void DisableAllPlayers()
	{
		for (int i = 0; i < numPlayers; i++) 
		{
			PlayerMove = OurPlayers [i].Player.GetComponent<PlayerMovement> ();
			PlayerMove.enabled = false;
			Camera = OurPlayers [i].Camera;
			Camera.SetActive (false);
		}
	}
	void EnableFirstPlayer()
	{
		PlayerMove = OurPlayers [0].Player.GetComponent<PlayerMovement> ();
		PlayerMove.enabled = true;
		Camera = OurPlayers [0].Camera;
		Camera.SetActive (true);
	}
}
