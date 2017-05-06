using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue : MonoBehaviour {

    public Controller gameController;
    public cueBall ball;
    public bool playTurn;
    public rotationCamera camera;

    private int velocity;
    private bool isIdle, isStriking;
    private float power;
    private Vector3 mouseInit;


    void Start () {
        velocity = 0;
        playTurn = true;
        isStriking = false;
        power = 0;
	}

    void Update()
    {
        if (!playTurn || isIdle)
        {
            cueIdle();
            if (!playTurn)
                isIdle = false;
            return;
        }

        if (Input.GetButtonDown("Fire1") && playTurn && GUIUtility.hotControl == 0)
        {
            mouseInit = Input.mousePosition;
            power = 0;
            isStriking = true;
        }
        else if (Input.GetButtonUp("Fire1") && playTurn && isStriking)
        {
            isStriking = false;
            velocity = 1;

        }
        if (isStriking)
            power = Mathf.Min(50, (Input.mousePosition - mouseInit).magnitude);

        if (velocity != 0)
        {
            transform.position = transform.position + (power / 10 + 5) * velocity * Time.deltaTime * camera.look;
        }
        else {
            transform.localPosition = ball.transform.position - camera.look * (1.1f + power / 150);
        }

        transform.eulerAngles = new Vector3(90, 0, camera.angle * 180 / Mathf.PI + 90);
    }

    public void cueIdle () {
        transform.position = new Vector3(0, 0, -45);
        transform.eulerAngles = Vector3.zero;
        isIdle = true;
        velocity = 0;

    }
    public void cueNotIdle() {
        isIdle = false;
    }

    int fixCollision = 1;
    void OnCollisionEnter(Collision collision)
    {
        if (fixCollision == 1)
        {
            fixCollision = 0;
        }
        else {
            Debug.Log("COLLISION: " + collision.gameObject.tag);
            if (collision.gameObject.tag.Equals("CueBall"))
            {
                ball.startMove(power);
                power = 0;
                //cueIdle();
                gameController.canPlay = false;
            }
        }
    }
}
