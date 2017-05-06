using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balls : MonoBehaviour {

    private float posY;
    private bool resting;

    public Rigidbody rb;
    public int num;

    void Start()
    {
        posY = transform.position.y;
        rb = GetComponent<Rigidbody>();
        GameObject cueStick = GameObject.FindGameObjectsWithTag("cue")[0];
        Physics.IgnoreCollision(GetComponent<Collider>(), cueStick.GetComponent<Collider>());
    }

    void Update()
    {
        if (resting)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            return;
        }
        if (transform.position.y > posY)
        {
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        else if (transform.position.y < posY - 2)
        {
            transform.position = new Vector3(-58.4f, 40f, num * 2);
            resting = true;
        }
        if (rb.velocity.sqrMagnitude < 0.005)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else if (rb.velocity.sqrMagnitude < 0.05)
        {
            rb.velocity = 0.9f * rb.velocity;
            rb.angularVelocity = 0.9f * rb.angularVelocity;
        }
    }
}
