using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBox : MonoBehaviour {

	public GameObject character;
	static int winCount = 0;

	bool isIn = false;

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject == character) {
			if (other.bounds.Contains(transform.position))
			{
				isIn = true;
			} else {
				isIn = false;
				winCount--;
			}
		}

		if (isIn == true){
			Debug.Log("WIN COUNT: " + winCount);
			winCount++;
			isIn = false;
		}
	}

    // void OnTriggerEnter2D(Collider2D col)
    // {
    // 	if (col.gameObject == character){
    // 		Debug.Log("INSIDE BOX");
    // 		winCount++;
    // 	}
    // }

    // void OnTriggerExit2D(Collider2D col){
    // 	if (col.gameObject == character){
    // 		Debug.Log("OUTSIDE BOX");
    // 		winCount--;
    // 	}
    // }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (winCount >= 3){
			Application.Quit();
		}
	}
}
