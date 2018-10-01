using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {

	private Vector3 originalPosition;
	public Ball ball;
	public GameObject hole;
	private float power;
	private int score = -15;

	bool startShot = false;

	// Use this for initialization
	void Start () {
		originalPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space") && ball.speed == 0){

			if (startShot == false){
				originalPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y);
				startShot = true;
			}

			if (ball.transform.position.y < hole.transform.position.y)
				transform.Translate(Vector3.down * Time.deltaTime * 2f, Space.World);
			else 
				transform.Translate(Vector3.up * Time.deltaTime * 2f, Space.World);
		} else 
		{
			if (startShot == true)
			{
				if (ball.transform.position.y < hole.transform.position.y)
				{
					power = Mathf.Clamp(originalPosition.y - transform.position.y, 0.3f, 4.0f);
					ball.Roll(power * 4);
				}
				else {
					power = Mathf.Clamp(originalPosition.y - transform.position.y, -4.0f, -0.3f);
					ball.Roll(power * 4);
				}
				score += 5;
				Debug.Log("Score: " + score);
				startShot = false;
			}

			transform.position = originalPosition;
			if (ball.speed == 0){
				if (ball.transform.position.y < hole.transform.position.y)
					transform.position = ball.transform.position - new Vector3(0.25f, -0.3f, 0.0f);
				else 
					transform.position = ball.transform.position + new Vector3(-0.25f, 1f, 0.0f);
			}
		}
	}
}
