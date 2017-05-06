using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    private GameObject[] redBalls;
    private GameObject[] yellowBalls;
    private GameObject[] eightBall;

    public player player1;
    public player player2;

    public cue poolCue;
    public string playerTurn;
    public bool canPlay = true;

    Rigidbody[] allBodies;

    public string winner;
    public bool ignore8BallRed = false;
    public bool ignore8BallYellow = false;

    public bool checkFoul = false;

    void Start () {
        redBalls = GameObject.FindGameObjectsWithTag("RedBall");
        yellowBalls = GameObject.FindGameObjectsWithTag("YellowBall");
        eightBall = GameObject.FindGameObjectsWithTag("8Ball");
        player1 = new player("Player 1");
        player2 = new player("Player 2");
        playerTurn = player1.getName();
        allBodies = FindObjectsOfType<Rigidbody>();



    }

    public void foul()
    {
        if (checkFoul == true) {
            playerSwitch();
            checkFoul = false;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 10, 200, 100), "Current turn belongs to:");
        GUI.Label(new Rect(20, 20, 100, 100), playerTurn);
        GUI.Label(new Rect(20, 40, 100, 100), (player1.getName() +"'s color: "));
        GUI.Label(new Rect(20, 50, 100, 100), player1.getColour());
        GUI.Label(new Rect(20, 60, 100, 100), (player2.getName() + "'s color: "));
        GUI.Label(new Rect(20, 70, 100, 100), player2.getColour());
        if (GUI.Button(new Rect(Screen.width  - 100, Screen.height - 100, 100, 50), new GUIContent("Fix Cue")))
        {
            poolCue.cueIdle();
        }
        if (winner != "")
        {
            Cursor.visible = true;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 -100, 200, 100), "<color=green><size=40>" + winner + " wins! </size></color>");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 100, 100), new GUIContent("Restart Level")))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void playerSwitch() {
        if (playerTurn == player1.getName())
        {
            playerTurn = player2.getName();
        }
        else
        {
            playerTurn = player1.getName();
        }
    }

    void findBodies() {
    foreach (Rigidbody body in allBodies)
    {
            if (body != null)
            {
                if (body.velocity.sqrMagnitude < 0.000000001f)
                {
                    //canPlay = true;
                    Debug.Log("not moving");

                    break;
                }
            }
        }
    }

    void Update () {
        //findBodies();
        redBalls = GameObject.FindGameObjectsWithTag("RedBall");
        yellowBalls = GameObject.FindGameObjectsWithTag("YellowBall");
        eightBall = GameObject.FindGameObjectsWithTag("8Ball");

        if (redBalls.Length == 0) {
            ignore8BallRed = true;
                if (eightBall.Length == 0)
                {
                if (player1.getColour() == "Red") {

                winner = player1.getName();
                 }
                 else {
                winner = player2.getName();
            }
                }

        }
        if (yellowBalls.Length == 0) {
            ignore8BallYellow = true;
            if (eightBall.Length == 0)
            {
                if (player1.getColour() == "Yellow")
                {
                    winner = player1.getName();
                }
                else {
                    winner = player2.getName();
                }
            }
        }

        if (canPlay)
        {
            poolCue.cueNotIdle();
        }
        else if (!canPlay) {
            poolCue.cueIdle();
        }




    }
}

public class player : MonoBehaviour {
    string Name;
    string ballColour = "unknown";

    public string getName() {
        return Name;
    }

    public player(string name) {
        Name = name;
    }

    public void setColour(string colour) {
        ballColour = colour;
    }
    public string getColour()
    {
        return ballColour;
    }
}