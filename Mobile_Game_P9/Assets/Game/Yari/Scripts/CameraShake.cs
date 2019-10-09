﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magniutde)
    {
        Vector3 originalPos = transform.localPosition;

        Debug.Log(originalPos);

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Debug.Log(originalPos);

            float x = Random.Range(-1f, 1f) * magniutde;
            float y = Random.Range(-1f, 1f) * magniutde;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = new Vector3(0, 0, 0);
    }
}
