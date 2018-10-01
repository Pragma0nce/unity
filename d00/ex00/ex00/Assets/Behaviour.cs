using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {
	// Use this for initialization
	public float breathLevelMax = 1.5f;
	public float breathLevel = 0.5f;
	public float breathFalloff = 1.2f;

	public Vector3 maxBalloonsize = new Vector3(5.0f, 5.0f, 5.0f);
	public Vector3 minBalloonsize = new Vector3(0.2f, 0.2f, 0.2f);

	public float deflateSpeed = 0.05f;
	bool gameOver = false;
	bool loseControl = false;
	bool printOnce = false;

	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameOver){
			if (transform.localScale.x <= minBalloonsize.x){
				transform.localScale = minBalloonsize;
				gameOver = true;
			}

			transform.localScale -= new Vector3(deflateSpeed, deflateSpeed, deflateSpeed);
			breathLevel = breathFalloff/ transform.localScale.x;
			if (breathLevel > breathLevelMax){
				breathLevel = breathLevelMax;
			}

			if (Input.GetKeyDown("space") && !loseControl)
			{
				transform.localScale += new Vector3(breathLevel, breathLevel, breathLevel);
			}

			if (transform.localScale.x >= 5.4f){
				loseControl = true;
				deflateSpeed = 0.1f;
			}
		}
		else if (printOnce == false)
		{
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s") ;
			printOnce = true;
		}
	}
}
