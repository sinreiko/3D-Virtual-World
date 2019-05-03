using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Operand : MonoBehaviour {
	public float val1;
	public float val2;
	public float tot = 0;
	public string operation = "";
	public Text txtOutput;
	public InputField txtVal1;
	public InputField txtVal2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	float Add(float val1, float val2){
		float tot = val1 + val2;
		return tot;
	}

	float Minus(float val1, float val2){
		float tot = val1 - val2;
		return tot;
	}

	float Multiply(float val1, float val2){
		float tot = val1 * val2;
		return tot;
	}

	float Divide(float val1, float val2){
		float tot = val1 / val2;
		return tot;
	}

	public void Calculate(string operand){
		float val1 = float.Parse (txtVal1.text);
		float val2 = float.Parse (txtVal2.text);

		switch(operand)
		{
		case "+":
			txtOutput.text = Add (val1, val2).ToString();
			break;
		case "-":
			txtOutput.text = Minus(val1, val2).ToString();
			break;
		case "*":
			txtOutput.text = Multiply (val1, val2).ToString ();
			break;
		case "/":
			txtOutput.text = Divide (val1, val2).ToString ();
			break;
		}
		txtOutput.text = "= " + txtOutput.text;

	}
}
