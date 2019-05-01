using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    public float lerpRate;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //subtracts position of the camera (because this script it attached to the camera) from the position of the ball
        offset = ball.transform.position - transform.position;

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        //Because we CANNOT change the transform data itself, we save a copy of the transform data into a variable... then reference that variable.
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        
        //Slowly transitions from the value of pos to the value of targetPos, at a rate smoothened by the inclusion of Time.deltaTime
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }

}
