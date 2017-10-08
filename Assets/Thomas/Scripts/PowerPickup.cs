using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour {
    public enum Pickup
    {
        Hop,
        Speed,
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
            switch(pickupType)
            {
                case Pickup.Grow:
                    other.GetComponent<GrowScale>().Grow();
                    other.GetComponent<MeshRenderer>().material.color = Color.red;
                    PlayerMovement.currentPower = Pickup.Grow;
                    break;
                case Pickup.Hop:
                    other.GetComponent<MeshRenderer>().material.color = Color.green;
                    if (PlayerMovement.currentPower == Pickup.Shrink)
                        other.GetComponent<ShrinkScale>().ResetShrink();
                    else if (PlayerMovement.currentPower == Pickup.Grow)
                        other.GetComponent<GrowScale>().ResetGrow();
                    PlayerMovement.currentPower = Pickup.Hop;
                    break;
                case Pickup.Shrink:
                    other.GetComponent<ShrinkScale>().Shrink();
                    other.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    PlayerMovement.currentPower = Pickup.Shrink;
                    break;
                case Pickup.Speed:
                    other.GetComponent<MeshRenderer>().material.color = Color.blue;
                    if (PlayerMovement.currentPower == Pickup.Shrink)
                        other.GetComponent<ShrinkScale>().ResetShrink();
                    else if (PlayerMovement.currentPower == Pickup.Grow)
                        other.GetComponent<GrowScale>().ResetGrow();
                    PlayerMovement.currentPower = Pickup.Speed;

                    break;
            }
        }
    }
}
