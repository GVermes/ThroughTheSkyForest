using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;

        float t = 0.5f;

        while (t > 0)
        {
            t -= Time.deltaTime;
            transform.localPosition = Random.insideUnitSphere * (t/4);
            yield return null;
        }

        transform.localPosition = originalPos;

    }
}
