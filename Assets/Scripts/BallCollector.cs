using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollector : MonoBehaviour {
    public Controller gameController;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "YellowBall")
        {
            gameController.checkFoul = false;
            Destroy(collision.gameObject);

            //if (gameController.player1.getColour() == "Yellow")
            //{
            //    gameController.playerSwitch();
            //}
            //else if (gameController.player2.getColour() == "Yellow")
            //{
            //    gameController.playerSwitch();
            //}

            if (gameController.playerTurn == gameController.player1.getName())
            {
                if (gameController.player1.getColour() == "unknown")
                {
                    gameController.player1.setColour("Yellow");
                    gameController.player2.setColour("Red");
                }
                else {
                    if (gameController.player1.getColour() != "Yellow")
                    {
                        gameController.playerSwitch();
                    }
  
                }
            }
            else if (gameController.playerTurn == gameController.player2.getName())
            {
                if (gameController.player2.getColour() == "unknown")
                {
                    gameController.player2.setColour("Yellow");
                    gameController.player1.setColour("Red");
                }
                else {
                    if (gameController.player2.getColour() != "Yellow")
                    {
                        gameController.playerSwitch();
                    }

                }
            }
        }
        if (collision.gameObject.tag == "RedBall")
        {
            gameController.checkFoul = false;
            Destroy(collision.gameObject);
            //if (gameController.player1.getColour() == "Red") {
            //    gameController.playerSwitch();
            //}
            //else if (gameController.player2.getColour() == "Red")
            //{
            //    gameController.playerSwitch();
            //}



            if (gameController.playerTurn == gameController.player1.getName())
            {
                if (gameController.player1.getColour() == "unknown")
                {
                    gameController.player1.setColour("Red");
                    gameController.player2.setColour("Yellow");

                }
                else {
                    if (gameController.player1.getColour() != "Red")
                    {
                        gameController.playerSwitch();
                    }

                }
            }
            else if (gameController.playerTurn == gameController.player2.getName())
            {
                if (gameController.player2.getColour() == "unknown")
                {
                    gameController.player2.setColour("Red");
                    gameController.player1.setColour("Yellow");

                }
                else {
                    if (gameController.player2.getColour() != "Red")
                    {
                        gameController.playerSwitch();
                    }

                }
            }
        }

        if (collision.gameObject.tag == "CueBall")
        {
            gameController.checkFoul = false;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            collision.gameObject.transform.position = new Vector3(-0.644f, 0.7932f, -9);
            gameController.playerSwitch();
        }

        if (collision.gameObject.tag == "8Ball")
        {
            gameController.checkFoul = false;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            collision.gameObject.transform.position = new Vector3(-0.644f, 0.7932f, -9);

            if (gameController.ignore8BallRed)
            {
                if (gameController.player1.getColour() == "Red")
                {
                    gameController.winner = gameController.player1.getName();
                }
                else {
                    gameController.winner = gameController.player2.getName();

                }

            }
            else if (gameController.ignore8BallYellow)
            {
                if (gameController.player1.getColour() == "Yellow")
                {
                    gameController.winner = gameController.player1.getName();
                }
                else {
                    gameController.winner = gameController.player2.getName();

                }
            }
            else
            {
                if (gameController.playerTurn == gameController.player1.getName())
                {
                    gameController.winner = gameController.player2.getName();
                }
                else {
                    gameController.winner = gameController.player1.getName();

                }
            }


        }

    }
}
