using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour {
	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	public GameObject PlacePuzzle;
	public MeshRenderer m;
	public GameObject flashlightPrefab;
	public GameObject keyPrefab;
	public GameObject keyObj;
	public bool haveKey;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
		m = PlacePuzzle.GetComponent<MeshRenderer> ();
		m.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(carrying) {
			carry(carriedObject);
			checkDrop ();
			placeObject ();
			//rotateObject();
		} else {
			pickup();
		}
	}

	void rotateObject() {
		carriedObject.transform.Rotate(5,10,15);
	}

	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		o.transform.rotation = Quaternion.identity;
	}

	void pickup() {
		if(Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if(p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					//p.gameObject.rigidbody.isKinematic = true;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
					if (carriedObject.CompareTag ("Flashlight")) {
						carriedObject.SetActive (false);
						GameObject newFl = Instantiate (flashlightPrefab);
						Transform FirstPersonCharacter = GameObject.Find ("FirstPersonCharacter").GetComponent<Transform> ();
						newFl.transform.SetParent (FirstPersonCharacter, false);
					}
					if (carriedObject.CompareTag("Key")) {
						keyObj.SetActive (false);
						GameObject newKey = Instantiate (keyPrefab);
						Transform FirstPersonCharacter = GameObject.Find ("FirstPersonCharacter").GetComponent<Transform> ();
						newKey.transform.SetParent (FirstPersonCharacter, false);
						haveKey = true;
					}

					if (haveKey) {
						if (carriedObject.CompareTag ("Door")) {
							GameObject door = GameObject.Find ("Door");
							Debug.Log ("Door Detected");
							Destroy (door);
						}
					}
				}
			}
		}
	}

	void checkDrop() {
		if(Input.GetKeyDown (KeyCode.E)) {
			dropObject();
		}
	}

	void dropObject() {
		carrying = false;
		//carriedObject.gameObject.rigidbody.isKinematic = false;
		carriedObject.gameObject.GetComponent<Rigidbody> ().useGravity = true;
		carriedObject = null;
	}

	void placeObject(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			Debug.Log ("test");
			float shortestDistance = float.MaxValue;
			GameObject closestEmpty = null;
		
				float dist = Vector3.Distance (transform.position, PlacePuzzle.transform.position);

				if (dist < shortestDistance) {
					//check if it's already occupied
					shortestDistance = dist;
					closestEmpty = PlacePuzzle;
					
					
					//end check if occupied
				}

			carrying = false;
			m.enabled = true;

			carriedObject.SetActive (false);
			carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			carriedObject.transform.position = closestEmpty.transform.position;


		}
	}
}