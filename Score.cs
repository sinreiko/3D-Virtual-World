using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	Text scoreDisplay;
	SceneController sc;

	// Use this for initialization
	void Start () {
		scoreDisplay = GetComponent<Text> ();
		sc = SceneController.instance;

	}
	
	// Update is called once per frame
	void Update () {
		scoreDisplay.text = "Score: " + sc._score;
	}



}
