using System;
using System.Collections;
using System.Collections.Generic;
using Sounds;
using UnityEngine;

public class PlayerBump : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float magnitude = 2500;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerYBounce"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, magnitude * 5,0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bounce"))
        {
            float forceX = transform.position.x - collision.contacts[0].point.x;
            float forceZ = transform.position.z - collision.contacts[0].point.z;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceX,0,forceZ) * magnitude);
        }
        
    }
}
