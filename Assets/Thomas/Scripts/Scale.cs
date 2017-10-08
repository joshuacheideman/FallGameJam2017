using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scale : MonoBehaviour {
    [SerializeField]
    protected float scaleTime;
    [SerializeField]
    protected float scaleSize;

    protected Vector3 startingScale;
    protected Vector3 targetScale;

    public IEnumerator ScaleObject()
    {
        for (float t = 0; t < 1; t += Time.deltaTime / scaleSize)
        {
            transform.localScale = Vector3.Lerp(startingScale, targetScale, t);

            yield return null;
        }
    }
}
