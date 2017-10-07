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
                    Debug.Log("Grow");
                    other.GetComponent<Scale>().StartScaling();
                    break;
                case Pickup.Hop:
                    Debug.Log("Hop");
                    break;
                case Pickup.Shrink:
                    Debug.Log("Shrink");
                    break;
                case Pickup.Thrust:
                    Debug.Log("Thrust");
                    break;
            }
        }
    }
}
