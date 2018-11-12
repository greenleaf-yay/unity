using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Transform shakeCam;
    public bool shakeRot = false;

    private Vector3 originPos;
    private Quaternion originRot;
    
    void Start()
    {
        originPos = shakeCam.localPosition;
        originRot = shakeCam.localRotation;
    }

    public IEnumerator ShakeCamera(float duration = 0.05f
        , float magnitudePos = 0.03f, float magnitudeRot = 0.1f)
    {
        float passTime = 0.0f;
        while (passTime < duration)
        {
            Vector3 shakePos = Random.insideUnitSphere;
            shakeCam.localPosition = shakePos * magnitudePos;
            if (shakeRot)
            {
                Vector3 shakeRot = new Vector3(0, 0, Mathf
                  .PerlinNoise(Time.time * magnitudeRot, 0.0f));
                shakeCam.localRotation = Quaternion
                    .Euler(shakeRot);
            }
            passTime += Time.deltaTime;
            yield return null;
        }
        shakeCam.localPosition = originPos;
        shakeCam.localRotation = originRot;
    }
}
