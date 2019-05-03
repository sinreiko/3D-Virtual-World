using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {
	public MoveObjects moveObjects;
	public float newPosition;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		checkPuzzle ();
	}

	void checkPuzzle(){
		if (moveObjects.m.enabled == true) {
			Debug.Log ("yes enabled");
			transform.position = new Vector3(transform.position.x, transform.position.y+5, transform.position.z );
		}
	}
}
