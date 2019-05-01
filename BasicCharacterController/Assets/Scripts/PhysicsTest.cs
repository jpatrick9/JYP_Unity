using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    float inputX, inputY;
    public float jumpForce = 500.0f, bulletSpeed = 20.0f;
    bool jump = false, shooting = false;
    public GameObject bullet;
    public Transform bulletLaunchPoint;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector3(0,0,speed);
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            shooting = true;

        }
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);
        if (jump == true)
        {
            Jump();
            jump = false;
        }

        if (shooting == true)
        {
            Shoot();
            shooting = false;
        }

    }

    void Jump()
    {
        rb.AddForce(0f,jumpForce,0f);
    }

    void Shoot()
    {
        //Instantiate(bullet, bulletLaunchPoint.position, bullet.transform.rotation);

        GameObject bulletSpawn = Instantiate(bullet, bulletLaunchPoint.position, bullet.transform.rotation);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
    }

}
