using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }

    void OnGUI()
    {

        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), new GUIContent("Bar Effect")))
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
   }
