using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkScale : Scale {

	// Use this for initialization
	void Start () {
        startingScale = transform.localScale;
        targetScale = new Vector3(scaleSize, scaleSize, scaleSize);
    }

    public void Shrink()
    {
        StartCoroutine(ScaleObject());
    }
}
