using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour {
	public Slider healthFill;
	public float maxHealth = 100;
	public float currentHealth = 10;
//	int maxHealth{
//		get{
//			return SceneController.instance._maxHealth;
//		}
//		set{ 
//			SceneController.instance._maxHealth = value;
//		}
//	}
			
//	int currentHealth{
//		get{ 
//			return SceneController.instance._currentHealth;
//		}
//		set{ 
//			SceneController.instance._currentHealth = value;
//		}
//	}
//	public int currentHealth;
//	public const int maxHealth = 100;
//	public int currentHealth = maxHealth;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		healthFill.value = (float)currentHealth / (float)maxHealth;

		if (currentHealth > 100) {
			currentHealth = 100;
		}
	}
}
