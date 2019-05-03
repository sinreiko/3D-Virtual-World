using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	public GameObject RespawnPt; 

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20) {
			transform.position = RespawnPt.transform.position;
		}
	}
}
