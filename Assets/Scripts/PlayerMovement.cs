using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody rb;

    private float h;
    private bool slided;
    private bool sliding;
    bool stop;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetMovement();
        }
    }

    private void FixedUpdate()
    {
        if (slided)
        {
            AutoWalk(WalkDirection());
        }

     //   if(sliding) stop = false;

     //   if(stop) ZeroOutMove();

    }

    void ZeroOutMove()
    {
        Debug.Log("sleep");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void ResetMovement()
    {
        stop = true;
    }

    void AutoWalk(bool direction)
    {
        if (direction)
            rb.velocity = new Vector3(-1 * moveSpeed, rb.velocity.y, 0);
        else
            rb.velocity = new Vector3(1 * moveSpeed, rb.velocity.y, 0);

    }

    bool WalkDirection()
    {
        if (h < 0)
        {
            transform.rotation = Quaternion.LookRotation(-Vector3.right, Vector3.up);
            return true;
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            return false;
        }
        transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
        return false;
    }

    public void InputConverter(float single)
    {
        if (single != 0)
        {
            slided = true;
            sliding = true;
        }
        else sliding = false;

        float lastValue, currentValue;

        currentValue = single;

        if (currentValue != 0)
        {
            lastValue = currentValue;
            h = lastValue;
        }
    }

}
