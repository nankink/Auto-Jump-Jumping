using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{
    public LayerMask groundLayer;
    private bool groundDetected;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.layer == groundLayer)
        {
            groundDetected = true;
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if(other.gameObject.layer == groundLayer)
        {
            groundDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == groundLayer)
        {
            groundDetected = false;
        }
    }

    public bool GetGround()
    {
        return groundDetected;
    }
}
