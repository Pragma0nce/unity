using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public bool winRed = false;
	public bool winBlue = false;
	public bool winYellow = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (winRed && winBlue && winYellow){
			Debug.Log("YOU WON THE LEVEL!");
		}
	}
}
