using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObject : MonoBehaviour {
	GameObject mainCamera;

	public GameObject chestOpen1;
	public GameObject chestOpen2;
	public GameObject chestOpen3;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		openup ();

	}


	void openup() {
		if (Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera> ().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {

				GameObject interact = hit.transform.gameObject;

				if (hit.collider.tag == "Chest") {

					switch (hit.collider.name) {
					case "chest_close":
						chestOpen1.SetActive (true);
						interact.SetActive (false);
						break;

					case "chest_close2":
						chestOpen2.SetActive (true);
						interact.SetActive (false);
						break;

					case "chest_close3":
						chestOpen3.SetActive (true);
						interact.SetActive (false);
						break;
					}
				}

			}
		}
	}
	
}

