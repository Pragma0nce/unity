using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

 	public float speed = 20;
 	public float timerToDelete = 100f;
 	public float invincibleTime = 0.1f;
 	
 	void OnCollisionEnter2D(Collision2D collision)
 	{
 		if (invincibleTime < 0){
 			Destroy(gameObject);
 		}
 	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * speed);
		timerToDelete -= Time.deltaTime;
		invincibleTime -= Time.deltaTime;

		if (timerToDelete < 0){
			Destroy(gameObject);
		}
	}
}
