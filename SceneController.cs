using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneController : MonoBehaviour {
	public static SceneController instance;

	[SerializeField] public int _currentHealth;
	[SerializeField] public int _score;
	[SerializeField] public int _maxHealth;

	void Awake () {
		instance = this;
	}
	void Start () {
		
	}
	void Update () {
		
	}
	public int score{
		get{
			return _score;
		}
		set{ 
			if (value < 0) {
				value = 0;
			} 
			_score = value;
		}
	}
	public int currentHealth {
		get {
			return _currentHealth;
		}
		set {
			if (value < 0) {
				value = 0;
			} else if (value > 100) {
				value = 100;
			}
			_currentHealth = value;
		}
	}
		

	public int maxHealth {
		get{
			return _maxHealth;
		}
		set{
			_maxHealth = value;
		}
	}
}
