using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class PlayerJump : MonoBehaviour
{
    #region Jump Detection
    private Rigidbody rb;
    public Transform jumpDetector;
    public float detectRadius = 0.1f;
    public float jumpForce;
    bool groundDetected;
    bool jumped;
    #endregion

    [Separator]
    #region Ground Detection
    [SerializeField] private bool onGround;
    public Transform groundDetector;
    public float jumpRayLength;
    public LayerMask groundMask;
    CustomGravity customGravity;
    #endregion

    private void Start()
    {
        customGravity = GetComponent<CustomGravity>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GroundChecker();
        JumpDetector();
       
        if(!groundDetected)
        {
            if(!jumped)
            {
            Jump();
            }
        }
    }

    void Jump()
    {
        jumped = true;
        rb.velocity += new Vector3(0f, jumpForce, 0f);
    }

    void JumpDetector()
    {
        groundDetected = Physics.CheckSphere(jumpDetector.position, detectRadius, groundMask);
    }

    void GroundChecker()
    {
        if(Physics.Raycast(groundDetector.position, Vector3.down, jumpRayLength,  groundMask))
        { 
            // on ground
            customGravity.GravityScale(1);
            onGround = true;
            jumped = false;

            Vector3 curVelo = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.velocity = curVelo;

        }
        else
        {
            // on air
            customGravity.GravityScale(8);
            onGround = false;
        }
    }

}
