using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowScale : Scale {

	// Use this for initialization
	void Start () {
        startingScale = transform.localScale;
        targetScale = new Vector3(scaleSize, scaleSize, scaleSize);
    }

    public void Grow()
    {
        StartCoroutine(ScaleObject());
    }
}
