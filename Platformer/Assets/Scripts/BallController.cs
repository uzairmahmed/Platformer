using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Collider cl;

     // you need to set this to the camera you want to use

    public float acceleration = 100;
    public float maxSpeed = 5;
    public Vector3 groundSpeed;
    public float turnSpeed = 5;
    public float jumpHeight = 3;
    public float airSpeed = 3;

    private Vector3 movement;
    private Vector2 XYmovement;
    public Vector3 airMovement;
    private float LookAngleX = 0;
    private float OldLookAngleX = 0;
    private float distToGround;
    private float jump;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();

        distToGround = cl.bounds.extents.y;
    }

    void FixedUpdate()
    {

        //###################### Movement ###############################
        float moveVert = Input.GetAxis("Vertical");
        float moveHor = Input.GetAxis("Horizontal");

        XYmovement = new Vector2(rb.velocity.x, rb.velocity.z);

        if (XYmovement.magnitude > maxSpeed)// clamping speed to max speed
        {
            XYmovement = XYmovement.normalized * maxSpeed;
            groundSpeed = new Vector3(XYmovement.x, rb.velocity.y, XYmovement.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump = jumpHeight;
        }

        airMovement = new Vector3(-moveVert, 0.0f, moveHor);
        movement = new Vector3(moveVert, jump, 0f) + groundSpeed;
        movement = transform.TransformDirection(movement);

        if (IsGrounded())
        {
            rb.AddForce(movement * acceleration);
            var Xin = Input.GetAxis("Horizontal");
            LookAngleX += Xin * turnSpeed;
            OldLookAngleX = LookAngleX;
            transform.eulerAngles = new Vector3(0f, LookAngleX, 0f);
        }
        else
        {
            rb.AddForce(new Vector3(-airMovement.x * airSpeed, airMovement.y, -airMovement.z * airSpeed));
            transform.eulerAngles = new Vector3(0f, OldLookAngleX, 0f);
        }

        jump = 0f;

    }


    bool IsGrounded()
    {
        int distToGround = 0;
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.55f);
    }
}
