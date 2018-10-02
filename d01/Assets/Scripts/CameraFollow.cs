using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public playerScript_ex00 PlayerMovementScript;
	public playerScript_ex01 PlayerMovementScript2;
	private GameObject follow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovementScript != null)
			follow = GameObject.FindWithTag(PlayerMovementScript.GetCurrentPlayer());
		else if (PlayerMovementScript2 != null){
			follow = GameObject.FindWithTag(PlayerMovementScript2.GetCurrentPlayer());
		}
		transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y, -10);
		
	}
}
