using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    public Controller gameController;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "YellowBall" || collision.gameObject.tag == "RedBall")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            collision.gameObject.transform.position = new Vector3(0, 0.7932f, -9);
        }

        if (collision.gameObject.tag == "8Ball")
        {
            //player loses
        }

        if (collision.gameObject.tag == "CueBall")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            collision.gameObject.transform.position = new Vector3(-0.644f, 0.7932f, -9);
            gameController.playerSwitch();
        }


    }
}
