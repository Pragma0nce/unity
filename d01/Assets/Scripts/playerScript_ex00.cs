using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex00 : MonoBehaviour {

	private Rigidbody2D rigidBody2D;
	private BoxCollider2D collider;

	public float moveSpeed = 2.0f;
	public LayerMask groundLayer;
	private static string curPlayer;

	public string GetCurrentPlayer(){
		return curPlayer;
	}
	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
		curPlayer = "Blue";
	}
	
	void Jump()
	{
		if (IsOnGround())
			rigidBody2D.AddForce(new Vector2(0, 0.8f), ForceMode2D.Impulse);
	}

	bool IsOnGround()
	{
		if (collider.IsTouchingLayers(groundLayer)){
			return true;
		}
		return false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1")){
			curPlayer = "Red";
		} else if (Input.GetKeyDown("2")){
			curPlayer = "Blue";
		} else if (Input.GetKeyDown("3")){
			curPlayer = "Yellow";
		} else if (Input.GetKeyDown("r")){
			SceneManager.LoadScene("ex00");
		}

		if (curPlayer == gameObject.tag)
		{
			if (Input.GetKey("right")){
				transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
			}
			if (Input.GetKey("left")){
				transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
			}
			if (Input.GetKeyDown("space")){
				Jump();
			}
		}
	}
}
