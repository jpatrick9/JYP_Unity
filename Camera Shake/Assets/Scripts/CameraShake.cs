using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Transform camTrans;
    public float shakeTime;
    public float shakeRange;
    Vector3 originalPosition;

	// Use this for initialization
	void Start () {
        
        camTrans = Camera.main.transform;
        originalPosition = camTrans.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShakeCamera());
        }
	}

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeTime)
        {
            //camTrans.position = originalPosition + Random.insideUnitSphere * shakeRange ;
            Vector3 pos = Vector3.Lerp(originalPosition, originalPosition + (Random.insideUnitSphere * shakeRange), .3f);
            //OR
            //Vector3 pos = originalPosition + Random.insideUnitSphere * shakeRange;

            pos.z = originalPosition.z;
            camTrans.position = pos;

            elapsedTime += Time.deltaTime;

            yield return null;

        }

        camTrans.position = originalPosition;
    }

}
