using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, .2f);
        transform.Rotate(Vector3.up, 1f);
        transform.Rotate(Vector3.forward, .2f);

        //rotY = gameObject.transform.rotation.y;
        //rotZ = gameObject.transform.rotation.z;
        //gameObject.transform.rotation.y = 1.0f;
    }
}
