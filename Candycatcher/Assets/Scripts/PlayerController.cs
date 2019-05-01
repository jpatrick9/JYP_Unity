using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    [SerializeField]
    float moveSpeed = 1.0f;
    float maxPosX = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.position.x, -maxPosX, maxPosX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        

    }
}
