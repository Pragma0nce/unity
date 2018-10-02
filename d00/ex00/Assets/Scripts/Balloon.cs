using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
	// Use this for initialization
	public float breathLevelMax = 3.5f;
	public float breathLevel = 0.5f;
	public float breathFalloff = 1.3f;

	public Vector3 maxBalloonsize = new Vector3(5.0f, 5.0f, 5.0f);
	public Vector3 minBalloonsize = new Vector3(0.2f, 0.2f, 0.2f);

	public float deflateSpeed = 2.0f;
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

			transform.localScale -= new Vector3(deflateSpeed * Time.deltaTime, deflateSpeed * Time.deltaTime, deflateSpeed * Time.deltaTime);
			breathLevel = breathFalloff/ transform.localScale.x;
			if (breathLevel > breathLevelMax){
				breathLevel = breathLevelMax;
			}

			if (Input.GetKeyDown("space") && !loseControl)
			{
				transform.localScale += new Vector3(breathLevel, breathLevel, breathLevel);
			}

			if (transform.localScale.x >= 5.1f){
				loseControl = true;
				deflateSpeed = 4f;
			}
		}
		else if (printOnce == false)
		{
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s") ;
			printOnce = true;
		}
	}
}
