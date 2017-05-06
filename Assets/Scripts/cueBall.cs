using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cueBall : MonoBehaviour {

    public Controller gameController;

    public Rigidbody rb;
    public rotationCamera camera;
    public cue poolCue;

    private float posY;
    private bool idle;
    private int firstTouch;

    void Start () {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        posY = transform.position.y;
        idle = false;
        firstTouch = 0;
    }

	void Update () {
        if (idle)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            return;
        }

        if (rb.velocity.sqrMagnitude < 0.0000000000000000000000000000000000000000000000000000000000001)
        {
            //poolCue.cueNotIdle();
            //gameController.playerSwitch();
            gameController.canPlay = true;
            gameController.foul();
        }


        if (rb.velocity.sqrMagnitude < 0.005)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
           // gameController.canPlay = true;
        }
        else if (rb.velocity.sqrMagnitude < 100)
        {
            //poolCue.cueIdle();
            rb.velocity = 1.0f * rb.velocity;
            rb.angularVelocity = 1.0f * rb.angularVelocity;
        }
        if (transform.position.y > posY)
        {
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }   
    }

    public void startMove(float mag)
    {
        if (mag > 0.000f)
        {
            
            rb.AddForce((10 * mag + 40) * camera.look);
            //Debug.Log("MOVING: ");
            gameController.canPlay = false;
            gameController.checkFoul = true;
            poolCue.cueIdle();
            //gameController.playerSwitch();
        }
        else {
            //poolCue.cueNotIdle();
        }
    }
}
