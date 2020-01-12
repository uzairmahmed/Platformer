using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{   Rigidbody rb;
    Collider cl;

    public float speed;
    public float jumpHeight;

    float distToGround;
    bool isG;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();

        distToGround = cl.bounds.extents.y;
    }

    void FixedUpdate()
    {
        isG = IsGrounded();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveJump = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 airMovement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);

        rb.AddTorque(movement * speed);
        rb.AddForce(airMovement * speed/2);

        if ((moveJump != 0) && (IsGrounded())) rb.AddForce(jump);

    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.55f);
    }
}
