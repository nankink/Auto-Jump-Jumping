using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBehaviour : MonoBehaviour
{
    public float springForce;
    bool hasSprung;
    public float springCooldown = 1;
    float currentTime;


    private void Start()
    {
        currentTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasSprung)
            {
                PlayerMovement mov = other.gameObject.GetComponent<PlayerMovement>();
         //       mov.ResetMovement();
                
                Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
                hasSprung = true;
                playerRigidbody.AddForce(Vector3.up * springForce, ForceMode.Acceleration);

            }
        }
    }

    private void Update()
    {
        if (hasSprung)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= springCooldown)
            {
                hasSprung = false;
            }
        }
    }

}
