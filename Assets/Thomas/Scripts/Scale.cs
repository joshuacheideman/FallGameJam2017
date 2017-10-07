using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {
    [SerializeField]
    protected float scaleTime;
    [SerializeField]
    protected float scaleSize;

    Vector3 startingScale;
    Vector3 targetScale;

	// Use this for initialization
	void Start () {
        startingScale = transform.localScale;
        targetScale = new Vector3(scaleSize, scaleSize, scaleSize);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G))
        {
            StartScaling();
        }
    }

    public void StartScaling()
    {
        StartCoroutine(ScaleObject());
    }

    IEnumerator ScaleObject()
    {
        for (float t = 0; t < 1; t += Time.deltaTime / scaleSize)
        {
            transform.localScale = Vector3.Lerp(startingScale, targetScale, t);

            yield return null;
        }
    }
}
