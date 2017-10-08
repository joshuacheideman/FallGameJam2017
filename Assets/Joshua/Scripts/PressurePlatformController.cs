using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatformController : MonoBehaviour {

	public PressurePlatform[] Switches;
	int numSwitches;
	bool[] OnSwitch;
	bool AllTrue=false;
	GameObject Door;
	// Use this for initialization
	void Start () {
		Door = this.gameObject;//put pressure platform controller onto door
		numSwitches = Switches.Length;
		OnSwitch = new bool[numSwitches]; 
		for (int i = 0; i < numSwitches; i++) {//set all values to false initially.
			OnSwitch [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		AllTrue = true;
		for (int j = 0; j < numSwitches; j++) {
			OnSwitch[j] = Switches [j].GetSwitch ();	
		}
		for (int i = 0; i < numSwitches; i++) {
			AllTrue = AllTrue && OnSwitch [i];
		}
		if (AllTrue)
			Destroy (gameObject);
	}
}
