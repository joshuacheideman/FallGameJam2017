using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour {
    public enum Pickup
    {
        Hop,
        Thrust,
        Grow,
        Shrink
    };

    public Pickup pickupType;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerEntered");

            switch(pickupType)
            {
                case Pickup.Grow:
                    other.GetComponent<GrowScale>().Grow();
                    other.GetComponent<MeshRenderer>().material.color = Color.red;

                    break;
                case Pickup.Hop:
                    Debug.Log("Hop");
                    break;
                case Pickup.Shrink:
                    other.GetComponent<ShrinkScale>().Shrink();
                    other.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    break;
                case Pickup.Thrust:
                    Debug.Log("Thrust");
                    break;
            }
        }
    }
}
