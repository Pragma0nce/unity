using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float inertia;
	public float speed;
	public GameObject hole;

	public void Roll(float power)
	{
		speed = power;
	}

	// Use this for initialization
	void Start () {
		inertia = 0.05f;
		speed = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);

		if (speed > 0)
			speed -= inertia;
		else if (speed < 0)
			speed += inertia;

		if (speed > -0.1f && speed < 0.1f){
			speed = 0;
		}

		// if (speed < 0){
		// 	speed = 0;
		// }

		if (transform.position.y >= 9.5f || transform.position.y <= -3.2f){
			// transform.position = new Vector3(transform.position.x, 9.4f, transform.position.z);
			speed = -speed;
			transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
			speed = speed * 0.8f;
		}

		if (speed >= -0.3f && speed <= 0.3f){
			if (hole.transform.position.y - transform.position.y <= 0.2f && hole.transform.position.y - transform.position.y >= -0.2f){
				Destroy(this.gameObject);
			}
		}
	}
}
