using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Collider cl;

    public GameObject spawnPlatform;
    public GameObject endPlatform;

    public float acceleration = 100;
    public float maxSpeed = 5;
    public Vector3 groundSpeed;
    public float turnSpeed = 5;
    public float jumpHeight = 3;
    public float airSpeed = 3;

    public float h;
    public float v;
    private float j;

    public float distToGround;

    public bool onground;

    public int deaths = 0;

    public float pwr = 10f;
    public float rad = 10f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();

        //distToGround = cl.bounds.extents.y;
    }

    void FixedUpdate()
    {
        //Gets and updates each input per axis
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        j = Input.GetAxisRaw("Jump");

        Move();
    }

    void Move()
    {
        //turn to whatever side its aiming
        if (h > 0)
            rb.AddForce(new Vector3(100, 0, 0));
        else if (h < 0)
            rb.AddForce(new Vector3(-100, 0, 0));

        if (v > 0)
            rb.AddForce(new Vector3(0, 0, 100));
        else if (v < 0)
            rb.AddForce(new Vector3(0, 0, -100));
        
        if (j>0)
            rb.AddExplosionForce(1000, transform.position, 5f, 3f); 
    }



    bool IsGrounded()
    {
        int distToGround = 0;
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.6f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            deaths++;
            transform.position = spawnPlatform.transform.position + new Vector3(-0.75f, 0.5f, -0.75f);
        }
    }

}
