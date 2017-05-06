using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCamera : MonoBehaviour {
    public Vector3 offset;
    public Vector3 look;
    public cueBall ball;
    public float angle;

    private bool topView;
    private bool canChange;
    private int distance;
    void Update()
    {
        gameObject.transform.position = GameObject.Find("CueBall").transform.position + offset;
    }

    void Start()
    {
        angle = 3.15f;
        topView = false;
        distance = 5;
        canChange = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
            toggleCamera();

        float vx = Input.GetAxis("Mouse X");
        angle += 2 * vx * Time.deltaTime;

        Vector3 v = new Vector3(distance * Mathf.Cos(angle), 3, distance * Mathf.Sin(angle));
        look = -1f / distance * v + new Vector3(0, 3f / distance, 0);

        if (topView)
        {
            transform.position = new Vector3(0, 2.3f, -9);
            transform.eulerAngles = new Vector3(90, 0, 0);
            //gameObject.transform.position = GameObject.Find("CueBall").transform.position + offset;
        }
        else {
            transform.position = transform.position * 0.85f + 0.15f * (ball.transform.position + v);
            transform.LookAt(ball.transform.position);
        }

    }

    public void fixTopView()
    {
        canChange = false;
        topView = true;
    }

    public void unfixCamera()
    {
        canChange = true;
        topView = false;
    }

    public void toggleCamera()
    {
        if (canChange)
            topView = !topView;
    }
}
